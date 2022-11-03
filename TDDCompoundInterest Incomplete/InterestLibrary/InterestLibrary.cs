using IronPython.Runtime;
using IronPython.Hosting;
namespace InterestLibrary;
public class Interest
{
    public double? GetResult(double? pInput, double? rInput, int? nInput, double? tInput) {
        if (pInput == null || rInput == null || nInput == null || tInput == null) {
            return null;
        }
        double p = (double)pInput;
        double r = (double)rInput;
        int n = (int)nInput;
        double t = (double)tInput;
        if (n.ToString().Length >  10 | t.ToString().Length > 10 | p.ToString().Length > 10 | r.ToString().Length > 10) {
            throw new OverflowException();
        }
        if (n.GetType() != typeof(int) | t.GetType() != typeof(double) | p.GetType() != typeof(double) | r.GetType() != typeof(double)) {
            throw new TypeAccessException();
        }
        if (n == 0) {
            throw new DivideByZeroException();
        }
        if (n < 0 || t < 0 || p < 0 || r < 0) {
            throw new InvalidDataException();
        }
        return Math.Round((p * Math.Pow(1 + r / n, n * t)), 2);
    }
}
