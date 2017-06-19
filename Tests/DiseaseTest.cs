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



    public void Dispose()
    {
      Disease.DeleteAll();

    }

  }
}
