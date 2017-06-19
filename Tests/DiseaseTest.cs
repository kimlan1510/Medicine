using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Medicine
{
  [Collection("Medicine")]
  public class DiseaseTest : IDisposable
  {
    public DiseaseTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=medicine_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DiseaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Disease.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SaveDiseaseToDatabase()
    {
      //Arrange
      Disease testDisease = new Disease("cold", "running nose", "image1", 1);
      testDisease.Save();

      //Act
      List<Disease> result = Disease.GetAll();
      List<Disease> testList = new List<Disease>{testDisease};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsDiseaseInDatabase()
    {
      //Arrange
      Disease testDisease = new Disease("cold", "running nose", "image1", 1);
      testDisease.Save();
      //Act
      Disease foundDisease = Disease.Find(testDisease.GetId());
      //Assert
      Assert.Equal(testDisease, foundDisease);
    }

    [Fact]
    public void Test_AddRemedy_AddsRemedyToDisease()
    {
      //Arrange
      Disease testDisease = new Disease("cold", "running nose", "image1", 1);
      testDisease.Save();

      Remedy testRemedy = new Remedy("lemon", "yellow sour fruit", "very sour", "image1", 1);
      testRemedy.Save();

      Remedy testRemedy2 = new Remedy("orange", "yellow sour fruit", "kinda sweet", "image2", 1);
      testRemedy2.Save();

      //Act
      testDisease.AddRemedy(testRemedy);
      testDisease.AddRemedy(testRemedy2);

      List<Remedy> result = testDisease.GetRemedy();
      List<Remedy> testList = new List<Remedy>{testRemedy, testRemedy2};

      //Assert
      Assert.Equal(testList, result);
    }


    [Fact]
    public void Test_Update_UpdatesDiseaseInDatabase()
    {
      //Arrange
      Disease testDisease = new Disease("cold", "running nose", "image1", 1);
      testDisease.Save();
      string newName = "fever";
      string newSymtoms = "Very hot";
      string newImage = "image2";
      int newCategoryId = 2;

      //Act
      testDisease.Update("fever", "Very hot", "image2", 2);
      string result1 = testDisease.GetName();
      string result2 = testDisease.GetSymtoms();
      string result3 = testDisease.GetImage();
      int result4 = testDisease.GetCategoryId();

      //Assert
      Assert.Equal(newName, result1);
      Assert.Equal(newSymtoms, result2);
      Assert.Equal(newImage, result3);
      Assert.Equal(newCategoryId, result4);
    }

    [Fact]
    public void Delete_DeletesDiseaseAssociationsFromDatabase_DiseaseList()
    {
     //Arrange
     Disease testDisease = new Disease("cold", "running nose", "image1", 1);
     testDisease.Save();

     Remedy testRemedy = new Remedy("orange", "yellow sour fruit", "kinda sweet", "image2", 1);
     testRemedy.Save();


     //Act
     testDisease.AddRemedy(testRemedy);
     testDisease.Delete();

     List<Disease> resultRemedyDisease = Disease.GetAll();
     List<Disease> testRemedyDisease = new List<Disease> {};

     //Assert
     Assert.Equal(testRemedyDisease, resultRemedyDisease);
    }



    public void Dispose()
    {
      Disease.DeleteAll();
      Remedy.DeleteAll();
      CategoryDisease.DeleteAll();
    }

  }
}
