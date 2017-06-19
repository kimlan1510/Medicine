using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Medicine
{
  public class CategoryRemedy
  {
    private int _id;
    private string _name;

    public CategoryRemedy(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }

    public override bool Equals(System.Object otherCategoryRemedy)
    {
      if(!(otherCategoryRemedy is CategoryRemedy))
      {
        return false;
      }
      else
      {
        CategoryRemedy newCategoryRemedy = (CategoryRemedy) otherCategoryRemedy;
        bool idEquality = (this.GetId() == newCategoryRemedy.GetId());
        bool nameEquality = (this.GetName() == newCategoryRemedy.GetName());
        return (idEquality && nameEquality);
      }
    }

    public static List<CategoryRemedy> GetAll()
    {
      List<CategoryRemedy> AllCategoryRemedy = new List<CategoryRemedy>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM categories_remedies;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        CategoryRemedy newCategoryRemedy = new CategoryRemedy(name, id);
        AllCategoryRemedy.Add(newCategoryRemedy);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllCategoryRemedy;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO categories_remedies (name) OUTPUT INSERTED.id VALUES (@name);", conn);

      SqlParameter namePara = new SqlParameter("@name", this.GetName());

      cmd.Parameters.Add(namePara);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static CategoryRemedy Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM categories_remedies WHERE id = @id;", conn);
      SqlParameter IdPara = new SqlParameter("@id", id.ToString());
      cmd.Parameters.Add(IdPara);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundid = 0;
      string name = null;

      while(rdr.Read())
      {
        foundid = rdr.GetInt32(0);
        name = rdr.GetString(1);
      }
      CategoryRemedy foundCategoryRemedy = new CategoryRemedy(name, foundid);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
     return foundCategoryRemedy;
    }

    public List<Remedy> GetRemedy()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM remedies WHERE categories_id = @CategoryId;", conn);
      SqlParameter CategoryRemedyIdPara = new SqlParameter("@CategoryId", this.GetId());

      cmd.Parameters.Add(CategoryRemedyIdPara);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Remedy> AllRemedy = new List<Remedy> {};
      while(rdr.Read())
      {
        int remedyId = rdr.GetInt32(0);
        string remedyName = rdr.GetString(1);
        string remedyDescription = rdr.GetString(2);
        string remedySideEffect = rdr.GetString(3);
        string remedyImage = rdr.GetString(4);
        int remedyCategoryId = rdr.GetInt32(5);
        Remedy newRemedy = new Remedy(remedyName, remedyDescription, remedySideEffect, remedyImage, remedyCategoryId, remedyId);
        AllRemedy.Add(newRemedy);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllRemedy;
    }

    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE categories_remedies SET name = @newName WHERE id = @categoryRemedyId;", conn);

      SqlParameter newNamePara = new SqlParameter("@newname", newName);
      cmd.Parameters.Add(newNamePara);

      SqlParameter categoryRemedyIdPara = new SqlParameter("@categoryRemedyId", this.GetId());
      cmd.Parameters.Add(categoryRemedyIdPara);

      this._name = newName;
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM categories_remedies WHERE id = @CategoryRemedyId; DELETE FROM remedies WHERE categories_id = @CategoryRemedyId;", conn);

      SqlParameter CategoryRemedyIdParam = new SqlParameter("@CategoryRemedyId", this.GetId());

      cmd.Parameters.Add(CategoryRemedyIdParam);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }


    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM categories_remedies;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }


  }

}
