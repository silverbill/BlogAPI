using Xunit;

public class SimpleTests {

    /* 
    Facts are used to test single inputs.
    Each function should contain just one assertion.
    */

    [Fact]
    public void Classes_Inherit()
    {
        Assert.True(new Blog() is IBlogRepo);
    }

    // [Fact]
    // public void TestingAdd2() => 
    //     Assert.Equal(16, Add(5,11));

   

    /*
    other Assert methods:
    Equal(a,b)
    True(a)
    False(a)
    */

    /*
    Use theories to test multiple inputs to a function
    */

    // [Theory]
    // [InlineData( 1,1,2 )]
    // [InlineData( 4,6,10 )]
    // [InlineData( 7,7,14 )]
    // public void TestingAdd3(int a, int b, int c) =>
    //     Assert.Equal(Add(a,b), c);

}