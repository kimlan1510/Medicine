using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Medicine
{
  [Collection("Medicine")]
  public class CategoryDiseaseTest : IDisposable
  {
    public CategoryDiseaseTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=medicine_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CategoryDiseaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = CategoryDisease.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SaveCategoryDiseaseToDatabase()
    {
      //Arrange
      CategoryDisease testCategoryDisease = new CategoryDisease("flu");
      testCategoryDisease.Save();

      //Act
      List<CategoryDisease> result = CategoryDisease.GetAll();
      List<CategoryDisease> testList = new List<CategoryDisease>{testCategoryDisease};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsCategoryDiseaseInDatabase()
    {
      //Arrange
      CategoryDisease testCategoryDisease = new CategoryDisease("flu");
      testCategoryDisease.Save();
      //Act
      CategoryDisease foundCategoryDisease = CategoryDisease.Find(testCategoryDisease.GetId());
      //Assert
      Assert.Equal(testCategoryDisease, foundCategoryDisease);
    }

    [Fact]
    public void Test_GetDisease_RetrieveAllDiseaseWithinCategoryDisease()
    {
      //Arrange
      CategoryDisease testCategoryDisease = new CategoryDisease("flu");
      testCategoryDisease.Save();

      Disease firstDisease = new Disease("cold","running nose", "image1", testCategoryDisease.GetId());
      firstDisease.Save();
      Disease secondDisease = new Disease("fever", "hot", "image2", testCategoryDisease.GetId());
      secondDisease.Save();

      //Act
      List<Disease> testDiseaseList = new List<Disease>{firstDisease, secondDisease};
      List<Disease> resultDiseaseList = testCategoryDisease.GetDisease();

      //Assert
      Assert.Equal(testDiseaseList, resultDiseaseList);
    }

    [Fact]
    public void Test_Update_UpdatesCategoryDiseaseInDatabase()
    {
      //Arrange
      string name = "physical injuries";
      CategoryDisease testCategoryDisease = new CategoryDisease(name);
      testCategoryDisease.Save();
      string newName = "cancer";

      //Act
      testCategoryDisease.Update("cancer");
      string result = testCategoryDisease.GetName();

      //Assert
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test_Delete_DeleteCategoryDiseaseFromDatabase()
    {
      //Arrange
      string name1 = "flu";
      CategoryDisease testCategoryDisease1 = new CategoryDisease(name1);
      testCategoryDisease1.Save();

      string name2 = "cancer";
      CategoryDisease testCategoryDisease2 = new CategoryDisease(name2);
      testCategoryDisease2.Save();

      Disease Disease1 = new Disease("cold","running nose", "image1", testCategoryDisease1.GetId());
      Disease1.Save();
      Disease Disease2 = new Disease("fever", "hot", "image2", testCategoryDisease2.GetId());
      Disease2.Save();

      //Act
      testCategoryDisease1.Delete();
      List<CategoryDisease> resultCategoryDisease = CategoryDisease.GetAll();
      List<CategoryDisease> testCategoryDisease = new List<CategoryDisease> {testCategoryDisease2};

      List<Disease> resultDisease = Disease.GetAll();
      List<Disease> DiseaseList = new List<Disease> {Disease2};

      //Assert
      Assert.Equal(testCategoryDisease, resultCategoryDisease);
      Assert.Equal(DiseaseList, resultDisease);
    }


    public void Dispose()
    {
      CategoryDisease.DeleteAll();
      Remedy.DeleteAll();
      Disease.DeleteAll();
    }
  }
}
