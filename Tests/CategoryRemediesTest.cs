using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Medicine
{
  [Collection("Medicine")]
  public class CategoryRemedyTest : IDisposable
  {
    public CategoryRemedyTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=medicine_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CategoryRemedyEmptyAtFirst()
    {
      //Arrange, Act
      int result = CategoryRemedy.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SaveCategoryRemedyToDatabase()
    {
      //Arrange
      CategoryRemedy testCategoryRemedy = new CategoryRemedy("Herbal");
      testCategoryRemedy.Save();

      //Act
      List<CategoryRemedy> result = CategoryRemedy.GetAll();
      List<CategoryRemedy> testList = new List<CategoryRemedy>{testCategoryRemedy};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsCategoryRemedyInDatabase()
    {
      //Arrange
      CategoryRemedy testCategoryRemedy = new CategoryRemedy("Herbal");
      testCategoryRemedy.Save();
      //Act
      CategoryRemedy foundCategoryRemedy = CategoryRemedy.Find(testCategoryRemedy.GetId());
      //Assert
      Assert.Equal(testCategoryRemedy, foundCategoryRemedy);
    }

    [Fact]
    public void Test_GetRemedy_RetrieveAllRemedyWithinCategoryRemedy()
    {
      //Arrange
      CategoryRemedy testCategoryRemedy = new CategoryRemedy("Herbal");
      testCategoryRemedy.Save();

      Remedy firstRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", testCategoryRemedy.GetId());
      firstRemedy.Save();
      Remedy secondRemedy = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", testCategoryRemedy.GetId());
      secondRemedy.Save();

      //Act
      List<Remedy> testRemedyList = new List<Remedy>{firstRemedy, secondRemedy};
      List<Remedy> resultRemedyList = testCategoryRemedy.GetRemedy();

      //Assert
      Assert.Equal(testRemedyList, resultRemedyList);
    }

    [Fact]
    public void Test_Update_UpdatesCategoryRemedyInDatabase()
    {
      //Arrange
      string name = "Sore";
      CategoryRemedy testCategoryRemedy = new CategoryRemedy(name);
      testCategoryRemedy.Save();
      string newName = "Physical";

      //Act
      testCategoryRemedy.Update("Physical");
      string result = testCategoryRemedy.GetName();

      //Assert
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test_Delete_DeleteCategoryRemedyFromDatabase()
    {
      //Arrange
      string name1 = "Herbal";
      CategoryRemedy testCategoryRemedy1 = new CategoryRemedy(name1);
      testCategoryRemedy1.Save();

      string name2 = "Physical";
      CategoryRemedy testCategoryRemedy2 = new CategoryRemedy(name2);
      testCategoryRemedy2.Save();

      Remedy Remedy1 = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", testCategoryRemedy1.GetId());
      Remedy1.Save();
      Remedy Remedy2 = new Remedy("Herbal", "descriptionHerbal", "sideEffectHerbal",  "website.com/photoOfRemedy.jpg", testCategoryRemedy2.GetId());
      Remedy2.Save();

      //Act
      testCategoryRemedy1.Delete();
      List<CategoryRemedy> resultCategoryRemedy = CategoryRemedy.GetAll();
      List<CategoryRemedy> testCategoryRemedy = new List<CategoryRemedy> {testCategoryRemedy2};

      List<Remedy> resultRemedy = Remedy.GetAll();
      List<Remedy> RemedyList = new List<Remedy> {Remedy2};

      //Assert
      Assert.Equal(testCategoryRemedy, resultCategoryRemedy);
      Assert.Equal(RemedyList, resultRemedy);
    }


    public void Dispose()
    {
      CategoryRemedy.DeleteAll();
      Remedy.DeleteAll();
    }
  }
}
