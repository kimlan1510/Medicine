using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using System;
using System.Windows.Forms;
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
        model.Add("AllDiseases", AllAilments);
        model.Add("AllRemedies", AllRemedies);
        return View["admin.cshtml", model];
      };
      Post["/admin/remedy"] = _ =>{
        string name = Request.Form["remedy-name"];
        string description = Request.Form["remedy-description"];
        string side_effect = Request.Form["remedy-side-effect"];
        string image = Request.Form["remedy-image"];
        int category_id = int.Parse(Request.Form["remedy-category-id"]);
        Remedy newRemedy = new Remedy(name, description, side_effect, image, category_id);
        Console.WriteLine(newRemedy.GetImage());
        newRemedy.Save();
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<CategoryDisease> AllCategoryDisease = CategoryDisease.GetAll();
        List<CategoryRemedy> AllCategoryRemedy = CategoryRemedy.GetAll();
        List<Disease> AllAilments = Disease.GetAll();
        List<Remedy> AllRemedies = Remedy.GetAll();
        model.Add("AllCategoryDisease", AllCategoryDisease);
        model.Add("AllCategoryRemedy", AllCategoryRemedy);
        model.Add("AllDiseases", AllAilments);
        model.Add("AllRemedies", AllRemedies);
        return View["admin.cshtml", model];
      };

      Post["/admin/disease"] = _ =>{
        string name = Request.Form["disease-name"];
        string symptom = Request.Form["disease-symptom"];
        string image = Request.Form["disease-image"];
        int category_id = int.Parse(Request.Form["disease-category-id"]);
        Disease newDisease = new Disease(name, symptom, image, category_id);
        newDisease.Save();
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<CategoryDisease> AllCategoryDisease = CategoryDisease.GetAll();
        List<CategoryRemedy> AllCategoryRemedy = CategoryRemedy.GetAll();
        List<Disease> AllAilments = Disease.GetAll();
        List<Remedy> AllRemedies = Remedy.GetAll();
        model.Add("AllCategoryDisease", AllCategoryDisease);
        model.Add("AllCategoryRemedy", AllCategoryRemedy);
        model.Add("AllDiseases", AllAilments);
        model.Add("AllRemedies", AllRemedies);
        return View["admin.cshtml", model];
      };

      Post["/admin/remedy/category"] = _ =>{
        string name = Request.Form["remedy-category-name"];
        CategoryRemedy newCategoryRemedy = new CategoryRemedy(name);
        newCategoryRemedy.Save();
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<CategoryDisease> AllCategoryDisease = CategoryDisease.GetAll();
        List<CategoryRemedy> AllCategoryRemedy = CategoryRemedy.GetAll();
        List<Disease> AllAilments = Disease.GetAll();
        List<Remedy> AllRemedies = Remedy.GetAll();
        model.Add("AllCategoryDisease", AllCategoryDisease);
        model.Add("AllCategoryRemedy", AllCategoryRemedy);
        model.Add("AllDiseases", AllAilments);
        model.Add("AllRemedies", AllRemedies);
        return View["admin.cshtml", model];
      };

      Post["/admin/disease/category"] = _ =>{
        string name = Request.Form["disease-category-name"];
        CategoryDisease newCategoryDisease = new CategoryDisease(name);
        newCategoryDisease.Save();
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<CategoryDisease> AllCategoryDisease = CategoryDisease.GetAll();
        List<CategoryRemedy> AllCategoryRemedy = CategoryRemedy.GetAll();
        List<Disease> AllAilments = Disease.GetAll();
        List<Remedy> AllRemedies = Remedy.GetAll();
        model.Add("AllCategoryDisease", AllCategoryDisease);
        model.Add("AllCategoryRemedy", AllCategoryRemedy);
        model.Add("AllDiseases", AllAilments);
        model.Add("AllRemedies", AllRemedies);
        return View["admin.cshtml", model];
      };
    }
  }
}
