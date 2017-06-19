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


    public void Dispose()
    {
      CategoryDisease.DeleteAll();

    }
  }
}
