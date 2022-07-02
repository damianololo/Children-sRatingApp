using Xunit;
using Children_sRatingApp;
using System.IO;
using System.Collections.Generic;

namespace Children_sRating.Tests;

public class ChildrenTests
{
    [Fact]
    public void GetStatisticsTest()
    {
        var child = new InMemoryChild("Krzysztof");
        child.AddRating("1+");
        child.AddRating("4+");
        child.AddRating("2+");
        child.AddRating("5+");

        var result = child.GetStatistics();

        Assert.Equal(3.5, result.Average, 1);
        Assert.Equal(5.5, result.High, 1);
        Assert.Equal(1.5, result.Low, 1);
    }

    [Fact]
    public void CharParseToInt()
    {
        char rate = '3';
        int result = int.Parse(rate.ToString());
        
        Assert.Equal(3, result);
    }

    //[Fact]
    //public void ReadTextMethod()
    //{
    //    List<double> ratingList = new List<double>();

    //    using (var reader = File.OpenText(@"C:\Users\Damian\Documents\Programowanie\c# Adam Kamizelich\Children'sRatingApp\src\Children'sRatingApp\KrzysztofRate.txt"))
    //    {
    //        var line = reader.ReadLine();
    //        while (line != null)
    //        {
    //            var number = double.Parse(line);
    //            ratingList.Add(number);
    //            line = reader.ReadLine();
    //        }
    //    }

    //    Assert.Equal(5.5, 5.5);
    //}
}