using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Medicine
{
  [Collection("Medicine")]
  public class RemedyTest : IDisposable
  {
    public RemedyTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=medicine_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_RemedyEmptyAtFirst()
    {
      int result = Remedy.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Remedy firstRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", 1);
      Remedy secondRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", 1);

      Assert.Equal(firstRemedy, secondRemedy);
    }

    [Fact]
    public void Test_Save_SavesRemedyToDatabase()
    {
      Remedy testRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", 1);
      testRemedy.Save();

      List<Remedy> result = Remedy.GetAll();
      List<Remedy> testList = new List<Remedy>{testRemedy};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToRemedy()
    {
      Remedy testRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", 1);
      testRemedy.Save();

      Remedy savedRemedy = Remedy.GetAll()[0];

      int result = savedRemedy.GetId();
      int testId = testRemedy.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsRemedyInDatabase()
    {
      Remedy testRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", 1);
      testRemedy.Save();

      Remedy foundRemedy = Remedy.Find(testRemedy.GetId());

      Assert.Equal(testRemedy, foundRemedy);
    }

    [Fact]
    public void AddDisease_AddsDiseasesToRemedy_DiseaseList()
    {
      Remedy testRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", 1);
      testRemedy.Save();

      Disease testDisease = new Disease("cold", "running nose", "image1", 1);
      testDisease.Save();

      testRemedy.AddDisease(testDisease);

      List<Disease> result = testRemedy.GetDisease();
      List<Disease> testList = new List<Disease>{testDisease};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_ReturnsAllDiseases_DiseaseList()
    {
      Remedy testRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", 1);
      testRemedy.Save();

      Disease testDisease1 = new Disease("cold", "running nose", "image1", 1);
      testDisease1.Save();

      Disease testDisease2 = new Disease("flu", "sick", "image1", 2);
      testDisease2.Save();

      testRemedy.AddDisease(testDisease1);
      testRemedy.AddDisease(testDisease2);

      List<Disease> result = testRemedy.GetDisease();
      List<Disease> testList = new List<Disease> {testDisease1, testDisease2};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Search_SearchesRemedyInDatabase()
    {
      //Arrange
      Remedy testRemedy1 = new Remedy("Herbal", "descriptionHerbal", "death",  "website.com/photoOfRemedy.jpg", 1);
      testRemedy1.Save();
      Remedy testRemedy2 = new Remedy("Advil", "description", "not quite death",  "website.com/photoOfRemedy.jpg", 1);
      testRemedy2.Save();

      //Act
      List<Remedy> resultRemedyList = Remedy.SearchRemedy("death");
      List<Remedy> testRemedyList = new List<Remedy>{testRemedy1, testRemedy2};

      //Assert
      Assert.Equal(resultRemedyList, testRemedyList);
    }

    [Fact]
    public void Delete_DeletesRemedyAssociationsFromDataBase_RemedyList()
    {
      Disease testDisease = new Disease("cold", "running nose", "image1", 1);
      testDisease.Save();

      Remedy testRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", 1);
      testRemedy.Save();

      testRemedy.AddDisease(testDisease);
      testRemedy.Delete();

      List<Remedy> result = testDisease.GetRemedy();
      List<Remedy> test = new List<Remedy>{};

      Assert.Equal(test, result);
    }
    [Fact]
    public void Test_Update_UpdatesRemedyInDatabase()
    {
      //Arrange
      Remedy testRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", 1);
      testRemedy.Save();
      string newName = "Physical";
      string newDescription = "fun";
      string newSideEffect = "drowsy";
      string newImage = "image2";
      int newCategoryId = 2;

      //Act
      testRemedy.Update(newName, newDescription, newSideEffect, newImage, newCategoryId);
      string result1 = testRemedy.GetName();
      string result2 = testRemedy.GetDescription();
      string result3 = testRemedy.GetSideEffect();
      string result4 = testRemedy.GetImage();
      int result5 = testRemedy.GetCategoryId();

      //Assert
      Assert.Equal(newName, result1);
      Assert.Equal(newDescription, result2);
      Assert.Equal(newSideEffect, result3);
      Assert.Equal(newImage, result4);
      Assert.Equal(newCategoryId, result5);
    }
    public void Dispose()
    {
      Remedy.DeleteAll();
      Disease.DeleteAll();
      CategoryDisease.DeleteAll();

    }
  }
}
