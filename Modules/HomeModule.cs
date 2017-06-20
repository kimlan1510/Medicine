using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using System;
using System.Globalization;

namespace Medicine
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/ailments"] = _ => {
        List<Disease> AllAilments = Disease.GetAll();
        return View["ailments.cshtml", AllAilments];
      };
      Get["/remedies"] = _ => {
        List<Remedy> AllRemedies = Remedy.GetAll();
        return View["remedies.cshtml", AllRemedies];
      };
      Get["/admin"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<CategoryDisease> AllCategoryDisease = CategoryDisease.GetAll();
        List<CategoryRemedy> AllCategoryRemedy = CategoryRemedy.GetAll();
        List<Disease> AllAilments = Disease.GetAll();
        List<Remedy> AllRemedies = Remedy.GetAll();
        model.Add("AllCategoryDisease", AllCategoryDisease);
        model.Add("AllCategoryRemedy", AllCategoryRemedy);
        model.Add("AllAilments", AllAilments);
        model.Add("AllRemedies", AllRemedies);
        return View["admin.cshtml", model];
      };
      Post["/admin"] = _ =>{
        string name = Request.Form["remedy-name"];
        string description = Request.Form["remedy-description"];
        string side_effect = Request.Form["remedy-side-effect"];
        string image = Request.Form["remedy-image"];
        int category_id = int.Parse(Request.Form["remedy-category-id"]);
        if(name == null || description == null || side_effect == null)
        {
          Response.Write("<script>alert('You need to fill in the form.');</script>");
        }
        }



        Dictionary<string, object> model = new Dictionary<string, object>();
        List<CategoryDisease> AllCategoryDisease = CategoryDisease.GetAll();
        List<CategoryRemedy> AllCategoryRemedy = CategoryRemedy.GetAll();
        List<Disease> AllAilments = Disease.GetAll();
        List<Remedy> AllRemedies = Remedy.GetAll();
        model.Add("AllCategoryDisease", AllCategoryDisease);
        model.Add("AllCategoryRemedy", AllCategoryRemedy);
        model.Add("AllAilments", AllAilments);
        model.Add("AllRemedies", AllRemedies);
      }
    }
  }
}
