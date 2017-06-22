using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Medicine
{
  public class Disease
  {
    private int _id;
    private string _name;
    private string _symtoms;
    private string _image;
    private int _category_id;

    public Disease(string name, string symtoms, string image, int category_id, int id = 0)
    {
      _name = name;
      _symtoms = symtoms;
      _image = image;
      _category_id = category_id;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }
    public int GetCategoryId()
    {
      return _category_id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetSymtoms()
    {
      return _symtoms;
    }
    public string GetImage()
    {
      return _image;
    }

    public override bool Equals(System.Object otherDisease)
    {
      if(!(otherDisease is Disease))
      {
        return false;
      }
      else
      {
        Disease newDisease = (Disease) otherDisease;
        bool idEquality = (this.GetId() == newDisease.GetId());
        bool nameEquality = (this.GetName() == newDisease.GetName());
        bool symtomsEquality = (this.GetSymtoms() == newDisease.GetSymtoms());
        bool imageEquality = (this.GetImage() == newDisease.GetImage());
        bool category_idEquality = (this.GetCategoryId() == newDisease.GetCategoryId());
        return (idEquality && nameEquality && imageEquality && symtomsEquality && category_idEquality);
      }
    }

    public static List<Disease> GetAll()
    {
      List<Disease> AllDisease = new List<Disease>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM diseases;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string symtoms = rdr.GetString(2);
        string image = rdr.GetString(3);
        int category_id = rdr.GetInt32(4);
        Disease newDisease = new Disease(name, symtoms, image, category_id, id);
        AllDisease.Add(newDisease);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllDisease;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO diseases (name, symtoms, image, category_id) OUTPUT INSERTED.id VALUES (@name,  @symtoms, @image, @category_id);", conn);

      SqlParameter namePara = new SqlParameter("@name", this.GetName());
      SqlParameter symtomsPara = new SqlParameter("@symtoms", this.GetSymtoms());
      SqlParameter imagePara = new SqlParameter("@image", this.GetImage());
      SqlParameter categoryIdPara = new SqlParameter("@category_id", this.GetCategoryId());

      cmd.Parameters.Add(namePara);
      cmd.Parameters.Add(symtomsPara);
      cmd.Parameters.Add(imagePara);
      cmd.Parameters.Add(categoryIdPara);
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

    public static Disease Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM diseases WHERE id = @id;", conn);
      SqlParameter IdPara = new SqlParameter("@id", id.ToString());

      cmd.Parameters.Add(IdPara);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundid = 0;
      string name = null;
      string symtoms = null;
      string image = null;
      int category_id = 0;

      while(rdr.Read())
      {
        foundid = rdr.GetInt32(0);
        name = rdr.GetString(1);
        symtoms = rdr.GetString(2);
        image = rdr.GetString(3);
        category_id = rdr.GetInt32(4);
      }
      Disease foundDisease = new Disease(name, symtoms, image, category_id, foundid);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
     return foundDisease;
    }

    public List<Remedy> GetRemedy()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT remedies.* FROM diseases JOIN diseases_remedies ON (diseases.id = diseases_remedies.diseases_id) JOIN remedies ON (diseases_remedies.remedies_id = remedies.id) WHERE diseases.id = @diseaseId;", conn);
      SqlParameter diseaseIdParam = new SqlParameter("@diseaseId", this.GetId().ToString());

      cmd.Parameters.Add(diseaseIdParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Remedy> remedies = new List<Remedy>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string description = rdr.GetString(2);
        string side_effect = rdr.GetString(3);
        string image = rdr.GetString(4);
        int categories_id = rdr.GetInt32(5);
        Remedy newRemedy = new Remedy(name, description, side_effect, image, categories_id, id);
        remedies.Add(newRemedy);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
        if (conn != null)
      {
        conn.Close();
      }
      return remedies;
    }

    public void AddRemedy(Remedy newRemedy)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO diseases_remedies (diseases_id, remedies_id) VALUES (@DiseaseId, @RemedyId);", conn);

      SqlParameter DiseaseIdParameter = new SqlParameter("@DiseaseId", this.GetId());
      SqlParameter RemedyIdParameter = new SqlParameter( "@RemedyId", newRemedy.GetId());

      cmd.Parameters.Add(DiseaseIdParameter);
      cmd.Parameters.Add(RemedyIdParameter);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

    public void Update(string name, string symtoms, string image, int category_id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE diseases SET name = @name, symtoms = @symtoms, image = @image, category_id = @category_id WHERE id = @Id;", conn);

      SqlParameter namePara = new SqlParameter("@name", name);
      SqlParameter symtomsPara = new SqlParameter("@symtoms", symtoms);
      SqlParameter imagePara = new SqlParameter("@image", image);
      SqlParameter categoryIdPara = new SqlParameter("@category_id", category_id);
      SqlParameter idPara = new SqlParameter("@Id", this.GetId());

      cmd.Parameters.Add(namePara);
      cmd.Parameters.Add(symtomsPara);
      cmd.Parameters.Add(imagePara);
      cmd.Parameters.Add(categoryIdPara);
      cmd.Parameters.Add(idPara);

      this._name = name;
      this._symtoms = symtoms;
      this._image = image;
      this._category_id = category_id;
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public static List<Disease> SearchDisease(string inputString)
    {
      List<Disease> AllDiseases = new List<Disease>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM diseases WHERE symtoms LIKE @inputString OR name LIKE @inputString;", conn);
      SqlParameter searchDiseasePara = new SqlParameter("@inputString", "%" + inputString + "%");

      cmd.Parameters.Add(searchDiseasePara);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string symtoms = rdr.GetString(2);
        string image = rdr.GetString(3);
        int category_id = rdr.GetInt32(4);

        Disease foundDisease = new Disease(name, symtoms, image, category_id, id);
        AllDiseases.Add(foundDisease);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return AllDiseases;
    }





    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM diseases WHERE id = @diseaseId; DELETE FROM diseases_remedies WHERE diseases_id = @diseaseId;", conn);
      SqlParameter diseaseIdParameter = new SqlParameter("@diseaseId", this.GetId());

      cmd.Parameters.Add(diseaseIdParameter);
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
      SqlCommand cmd = new SqlCommand("DELETE FROM diseases; DELETE FROM categories_diseases; DELETE FROM diseases_remedies;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
