using IronPython.Runtime;
using IronPython.Hosting;
namespace InterestLibrary;
public class Interest
{
    // public double? GetResult(double? pInput, double? rInput, int? nInput, double? tInput) {
    //     if (pInput == null || rInput == null || nInput == null || tInput == null) {
    //         return null;
    //     }
    //     double p = (double)pInput;
    //     double r = (double)rInput;
    //     int n = (int)nInput;
    //     double t = (double)tInput;
    //     if (n.ToString().Length >  10 | t.ToString().Length > 10 | p.ToString().Length > 10 | r.ToString().Length > 10) {
    //         throw new OverflowException();
    //     }
    //     if (n.GetType() != typeof(int) | t.GetType() != typeof(double) | p.GetType() != typeof(double) | r.GetType() != typeof(double)) {
    //         throw new TypeAccessException();
    //     }
    //     if (n == 0) {
    //         throw new DivideByZeroException();
    //     }
    //     if (n < 0 || t < 0 || p < 0 || r < 0) {
    //         throw new InvalidDataException();
    //     }
    //     return Math.Round((p * Math.Pow(1 + r / n, n * t)), 2);
    // }
    public double? GetResult(double? pInput, double? rInput, int? nInput, double? tInput)
    {
        // Create the Engine
        var engine = IronPython.Hosting.Python.CreateEngine();

        // Create the Scope
        var scope = engine.CreateScope();

        // Executing the Python Code
        engine.Execute(@"
def getResult(pInput, rInput, nInput, tInput):
    if (pInput is None or rInput is None or nInput is None or tInput is None):
        return -1
    p = pInput
    r = rInput
    n = int(nInput)
    t = tInput
    if (len(str(p)) > 10 or len(str(r)) > 10 or len(str(n)) > 10 or len(str(t)) > 10):
        return -2
    if (n == 0):
        return -3
    if (p < 0 or r < 0 or n < 0 or t < 0):
        return -4
    output = p * ((1 + r / n) ** (n * t))
    return round(output, 2)
", scope);
        dynamic getResult = scope.GetVariable("getResult");
        // System.Console.WriteLine(getResult(pInput, rInput, nInput, tInput));
        double result = getResult(pInput, rInput, nInput, tInput);
        if (result == -1)
        {
            return null;
        }
        if (result == -2)
        {
            throw new OverflowException();
        }
        if (result == -3)
        {
            throw new DivideByZeroException();
        }
        if (result == -4)
        {
            throw new InvalidDataException();
        }
        return result;
    }
}
