using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Medicine
{
  public class CategoryDisease
  {
    private int _id;
    private string _name;

    public CategoryDisease(string name, int id = 0)
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

    public override bool Equals(System.Object otherCategoryDisease)
    {
      if(!(otherCategoryDisease is CategoryDisease))
      {
        return false;
      }
      else
      {
        CategoryDisease newCategoryDisease = (CategoryDisease) otherCategoryDisease;
        bool idEquality = (this.GetId() == newCategoryDisease.GetId());
        bool nameEquality = (this.GetName() == newCategoryDisease.GetName());
        return (idEquality && nameEquality);
      }
    }

    public static List<CategoryDisease> GetAll()
    {
      List<CategoryDisease> AllCategoryDisease = new List<CategoryDisease>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM categories_diseases;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        CategoryDisease newCategoryDisease = new CategoryDisease(name, id);
        AllCategoryDisease.Add(newCategoryDisease);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllCategoryDisease;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO categories_diseases (name) OUTPUT INSERTED.id VALUES (@name);", conn);

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

    public static CategoryDisease Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM categories_diseases WHERE id = @id;", conn);
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
      CategoryDisease foundCategoryDisease = new CategoryDisease(name, foundid);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
     return foundCategoryDisease;
    }


    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM categories_diseases;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }


  }

}
