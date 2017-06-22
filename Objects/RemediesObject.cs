using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Medicine
{
  public class Remedy
  {
    private int _id;
    private string _name;
    private string _description;
    private string _sideEffect;
    private string _image;
    private int _category_id;

    public Remedy(string name, string description, string sideEffect, string image, int categoryId, int id = 0)
    {
      _id = id;
      _name = name;
      _description = description;
      _sideEffect = sideEffect;
      _image = image;
      _category_id = categoryId;
    }
    public override bool Equals(System.Object otherRemedy)
    {
      if (!(otherRemedy is Remedy))
      {
        return false;
      }
      else
      {
        Remedy newRemedy = (Remedy) otherRemedy;
        bool idEquality = this.GetId() == newRemedy.GetId();
        bool nameEquality = this.GetName() == newRemedy.GetName();
        bool descriptionEquality = this.GetDescription() == newRemedy.GetDescription();
        bool sideEffect = this.GetSideEffect() == newRemedy.GetSideEffect();
        bool imageEquality = this.GetImage() == newRemedy.GetImage();
        bool categoryIdEquality = this.GetCategoryId() == newRemedy.GetCategoryId();
        return (idEquality && nameEquality && descriptionEquality && sideEffect && imageEquality && categoryIdEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetDescription()
    {
      return _description;
    }
    public string GetSideEffect()
    {
      return _sideEffect;
    }
    public string GetImage()
    {
      return _image;
    }
    public int GetCategoryId()
    {
      return _category_id;
    }
    public static List<Remedy> GetAll()
    {
      List<Remedy> allRemedys = new List<Remedy>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM remedies;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int remedyId = rdr.GetInt32(0);
        string remedyName = rdr.GetString(1);
        string remedyDescription = rdr.GetString(2);
        string remedySideEffect = rdr.GetString(3);
        string remedyImage = rdr.GetString(4);
        int remedyCategoryId = rdr.GetInt32(5);
        Remedy newRemedy = new Remedy(remedyName, remedyDescription, remedySideEffect, remedyImage, remedyCategoryId, remedyId);
        allRemedys.Add(newRemedy);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allRemedys;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO remedies (name, description, side_effect, image, categories_id) OUTPUT INSERTED.id VALUES (@RemedyName, @RemedyDescription, @RemedySideEffect, @RemedyImage, @RemedyCategoryId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@RemedyName";
      nameParameter.Value = this.GetName();

      SqlParameter descriptionParameter = new SqlParameter();
      descriptionParameter.ParameterName = "@RemedyDescription";
      descriptionParameter.Value = this.GetDescription();

      SqlParameter sideEffectParameter = new SqlParameter();
      sideEffectParameter.ParameterName = "@RemedySideEffect";
      sideEffectParameter.Value = this.GetSideEffect();

      SqlParameter imageParameter = new SqlParameter();
      imageParameter.ParameterName = "@RemedyImage";
      imageParameter.Value = this.GetImage();

      SqlParameter categoryIdParameter = new SqlParameter();
      categoryIdParameter.ParameterName = "@RemedyCategoryId";
      categoryIdParameter.Value = this.GetCategoryId();


      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(descriptionParameter);
      cmd.Parameters.Add(sideEffectParameter);
      cmd.Parameters.Add(imageParameter);
      cmd.Parameters.Add(categoryIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }
    public static Remedy Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM remedies WHERE id = @RemedyId;", conn);
      SqlParameter remedyIdParameter = new SqlParameter();
      remedyIdParameter.ParameterName = "@RemedyId";
      remedyIdParameter.Value = id.ToString();
      cmd.Parameters.Add(remedyIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundRemedyId = 0;
      string foundRemedyName = null;
      string foundRemedyDescription = null;
      string foundRemedySideEffect = null;
      string foundRemedyImage= null;
      int foundRemedyCategoryId = 0;

      while(rdr.Read())
      {
        foundRemedyId = rdr.GetInt32(0);
        foundRemedyName = rdr.GetString(1);
        foundRemedyDescription = rdr.GetString(2);
        foundRemedySideEffect = rdr.GetString(3);
        foundRemedyImage = rdr.GetString(4);
        foundRemedyCategoryId = rdr.GetInt32(5);
      }
      Remedy foundRemedy = new Remedy(foundRemedyName, foundRemedyDescription, foundRemedySideEffect, foundRemedyImage, foundRemedyCategoryId, foundRemedyId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundRemedy;
    }

    public void AddDisease(Disease newDisease)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO diseases_remedies (diseases_id, remedies_id) VALUES (@DiseaseId, @RemedyId);", conn);
      SqlParameter diseaseIdParameter = new SqlParameter();
      diseaseIdParameter.ParameterName = "@DiseaseId";
      diseaseIdParameter.Value = newDisease.GetId();
      cmd.Parameters.Add(diseaseIdParameter);

      SqlParameter remedyIdParameter = new SqlParameter();
      remedyIdParameter.ParameterName = "@RemedyId";
      remedyIdParameter.Value = this.GetId();
      cmd.Parameters.Add(remedyIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public List<Disease> GetDisease()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT diseases.* FROM remedies JOIN diseases_remedies ON (remedies.id = diseases_remedies.remedies_id) JOIN diseases ON (diseases_remedies.diseases_id = diseases.id) WHERE remedies.id = @RemedyId;", conn);
      SqlParameter remedyIdParameter = new SqlParameter();
      remedyIdParameter.ParameterName = "@RemedyId";
      remedyIdParameter.Value = this.GetId();

      cmd.Parameters.Add(remedyIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Disease> diseases = new List<Disease> {};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string symtoms = rdr.GetString(2);
        string image = rdr.GetString(3);
        int category_id = rdr.GetInt32(4);
        Disease newDisease = new Disease(name, symtoms, image, category_id, id);
        diseases.Add(newDisease);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return diseases;
    }

    public static List<Remedy> SearchRemedy(string inputString)
    {
      List<Remedy> AllRemedy = new List<Remedy>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM remedies WHERE name LIKE @inputString OR description LIKE @inputString OR side_effect LIKE @inputString;", conn);
      SqlParameter searchRemedyPara = new SqlParameter("@inputString", "%" + inputString + "%");

      cmd.Parameters.Add(searchRemedyPara);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string description = rdr.GetString(2);
        string side_effect = rdr.GetString(3);
        string image = rdr.GetString(4);
        int category_id = rdr.GetInt32(5);

        Remedy foundRemedy = new Remedy(name, description, side_effect, image, category_id, id);
        AllRemedy.Add(foundRemedy);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return AllRemedy;
    }



    public void Update(string name, string description, string sideEffect, string image, int category_id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE remedies SET name = @name, description = @description, side_effect = @sideEffect, image = @image, categories_id = @categories_id WHERE id = @Id;", conn);

      SqlParameter namePara = new SqlParameter("@name", name);
      SqlParameter descriptionPara = new SqlParameter("@description", description);
      SqlParameter sideEffectPara = new SqlParameter("@sideEffect", sideEffect);
      SqlParameter imagePara = new SqlParameter("@image", image);
      SqlParameter categoryIdPara = new SqlParameter("@categories_id", category_id);
      SqlParameter idPara = new SqlParameter("@Id", this.GetId());

      cmd.Parameters.Add(namePara);
      cmd.Parameters.Add(descriptionPara);
      cmd.Parameters.Add(sideEffectPara);
      cmd.Parameters.Add(imagePara);
      cmd.Parameters.Add(categoryIdPara);
      cmd.Parameters.Add(idPara);

      this._name = name;
      this._description = description;
      this._sideEffect = sideEffect;
      this._image = image;
      this._category_id = category_id;
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM remedies WHERE id = @RemeidiesId; DELETE FROM diseases_remedies WHERE remedies_id = @RemeidiesId;", conn);
      SqlParameter RemedyIdParameter = new SqlParameter();
      RemedyIdParameter.ParameterName = "@RemeidiesId";
      RemedyIdParameter.Value = this.GetId();

      cmd.Parameters.Add(RemedyIdParameter);
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
      SqlCommand cmd = new SqlCommand("DELETE FROM remedies;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
