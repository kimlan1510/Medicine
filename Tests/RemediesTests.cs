using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Medicine
{
  [Collection("tester")]
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
    public void Dispose()
    {
      Remedy.DeleteAll();
    }
  }
}
