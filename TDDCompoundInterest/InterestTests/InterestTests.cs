using InterestLibrary;

namespace InterestTests;

public class InterestTests
{
    // Test Correct Output
    [Fact]
    public void Test1()
    {
        Interest interestTest = new Interest();
        Assert.Equal(8235.05, interestTest.GetResult(5000, 0.05, 12, 10));
    }

    [Fact]
    public void Test2()
    {
        Interest interestTest = new Interest();
        Assert.Equal(916.60, interestTest.GetResult(700, 0.03, 10, 9));
    }

    [Fact]
    public void Test3()
    {
        Interest interestTest = new Interest();
        Assert.Equal(35653.59, interestTest.GetResult(1200, 0.1, 20, 34));
    }

    // Test Divide By Zero Exception
    [Fact]
    public void Test4()
    {
        Interest interestTest = new Interest();
        Action act = () => interestTest.GetResult(5000, 0.05, 0, 10);
        Assert.Throws<DivideByZeroException>(act);
    }
    [Fact]
    public void Test5()
    {
        Interest interestTest = new Interest();
        Action act = () => interestTest.GetResult(700, 0.03, 0, 9);
        Assert.Throws<DivideByZeroException>(act);
    }

    // Test Invalid Data Exception
    [Fact]
    public void Test6()
    {
        Interest interestTest = new Interest();
        Action act = () => interestTest.GetResult(5000, 0.05, 12, -10);
        Assert.Throws<InvalidDataException>(act);
    }
    [Fact]
    public void Test7()
    {
        Interest interestTest = new Interest();
        Action act = () => interestTest.GetResult(-5000, -0.05, -12, -10);
        Assert.Throws<InvalidDataException>(act);
    }

    // Test Overflow Exception
    [Fact]
    public void Test8()
    {
        Interest interestTest = new Interest();
        Action act = () => interestTest.GetResult(99999999999, 0.05, 12, -10);
        Assert.Throws<OverflowException>(act);
    }
    [Fact]
    public void Test9()
    {
        Interest interestTest = new Interest();
        Action act = () => interestTest.GetResult(-5000, 99999999999, 12, -10);
        Assert.Throws<OverflowException>(act);
    }

    // Null Exception
    [Fact]
    public void Test10()
    {
        Interest interestTest = new Interest();
        Assert.Equal(null, interestTest.GetResult(5000, 0.05, null, 10));
    }
    [Fact]
    public void Test11()
    {
        Interest interestTest = new Interest();
        Assert.Equal(null, interestTest.GetResult(null, 0.05, 12, 10));
    }

}