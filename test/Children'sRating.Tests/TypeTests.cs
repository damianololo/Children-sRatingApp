using System;
using Children_sRatingApp;
using Xunit;

namespace Children_sRating.Tests;

public class TypeTests
{
    [Fact]
    public void GetChildReturnDifferensObjects()
    {
        var child1 = new InMemoryChild("Krzysztof");
        var child2 = new InMemoryChild("Szymon");

        Assert.NotSame(child1, child2); 
    }

    [Fact]
    public void TwoVarsCanReferenceSomeObject()
    {
        var child1 = GetChild("Dominik");
        var child2 = child1;

        Assert.Same(child1, child2);
        Assert.True(object.ReferenceEquals(child1, child2));
    }

    private InMemoryChild GetChild(string name)
    {
        return new InMemoryChild(name);
    }

}