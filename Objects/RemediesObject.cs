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
  }
}
