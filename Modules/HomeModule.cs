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

      Get["/admin/diseaseCategory/delete/{id}"] = parameters => {
        CategoryDisease category = CategoryDisease.Find(parameters.id);
        return View["category_disease_delete.cshtml", category];
      };

      Delete["/admin/diseaseCategory/delete/{id}"] = parameters => {
        CategoryDisease chosenCategoryDisease = CategoryDisease.Find(parameters.id);
        chosenCategoryDisease.Delete();
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

      Get["/admin/remedyCategory/delete/{id}"] = parameters => {
        CategoryRemedy category = CategoryRemedy.Find(parameters.id);
        return View["category_remedy_delete.cshtml", category];
      };

      Delete["/admin/remedyCategory/delete/{id}"] = parameters => {
        CategoryRemedy chosenCategoryRemedy = CategoryRemedy.Find(parameters.id);
        chosenCategoryRemedy.Delete();
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

      Get["/admin/remedy/delete/{id}"] = parameters => {
        Remedy chosen = Remedy.Find(parameters.id);
        return View["remedy_delete.cshtml", chosen];
      };

      Delete["/admin/remedy/delete/{id}"] = parameters => {
        Remedy chosenRemedy = Remedy.Find(parameters.id);
        chosenRemedy.Delete();
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

      Get["/admin/disease/delete/{id}"] = parameters => {
        Disease chosen = Disease.Find(parameters.id);
        return View["disease_delete.cshtml", chosen];
      };

      Delete["/admin/disease/delete/{id}"] = parameters => {
        Disease chosenDisease = Disease.Find(parameters.id);
        chosenDisease.Delete();
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

      Get["/admin/diseaseCategory/edit/{id}"] = parameter => {
        CategoryDisease SelectedCategoryDisease = CategoryDisease.Find(parameter.id);
        return View["edit_category_disease.cshtml", SelectedCategoryDisease];
      };

      Patch["/admin/diseaseCategory/edit/{id}"] = parameter => {
        CategoryDisease SelectedCategoryDisease = CategoryDisease.Find(parameter.id);
        SelectedCategoryDisease.Update(Request.Form["edit-name"]);
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

      Get["/admin/remedyCategory/edit/{id}"] = parameter => {
        CategoryRemedy SelectedCategoryRemedy = CategoryRemedy.Find(parameter.id);
        return View["edit_category_remedy.cshtml", SelectedCategoryRemedy];
      };

      Patch["/admin/remedyCategory/edit/{id}"] = parameter => {
        CategoryRemedy SelectedCategoryRemedy = CategoryRemedy.Find(parameter.id);
        SelectedCategoryRemedy.Update(Request.Form["edit-name"]);
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

      Get["/admin/disease/edit/{id}"] = parameter => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Disease SelectedDisease = Disease.Find(parameter.id);
        var AllCategoryDisease = CategoryDisease.GetAll();
        model.Add("SelectedDisease", SelectedDisease);
        model.Add("AllCategoryDisease", AllCategoryDisease);
        return View["edit_disease.cshtml", model];
      };

      Patch["/admin/disease/edit/{id}"] = parameter => {
        Disease SelectedDisease = Disease.Find(parameter.id);
        SelectedDisease.Update(Request.Form["edit-name"], Request.Form["edit-symptom"], Request.Form["edit-image"], Request.Form["edit-category-id"]);
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

      Get["/admin/remedy/edit/{id}"] = parameter => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Remedy SelectedRemedy = Remedy.Find(parameter.id);
        var AllCategoryRemedy = CategoryRemedy.GetAll();
        model.Add("SelectedRemedy", SelectedRemedy);
        model.Add("AllCategoryRemedy", AllCategoryRemedy);
        return View["edit_remedy.cshtml", model];
      };

      Patch["/admin/remedy/edit/{id}"] = parameter => {
        Remedy SelectedRemedy = Remedy.Find(parameter.id);
        SelectedRemedy.Update(Request.Form["edit-name"], Request.Form["edit-description"], Request.Form["edit-sideEffect"], Request.Form["edit-image"], Request.Form["edit-category-id"]);
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
