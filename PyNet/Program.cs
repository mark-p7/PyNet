using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IronPython.Runtime;
using IronPython.Hosting;

class Program
{
    static void Main(string[] args)
    {
        var eng = IronPython.Hosting.Python.CreateEngine();
        var scope = eng.CreateScope();
        eng.Execute(@"
def greetings(name):
    return 'Hello ' + name.title() + '!'

def primeSearch(n):
    primes = []
    for i in range(2, n):
        for j in range(2, i):
            if i % j == 0:
                break
        else:
            primes.append(i)
    return primes
    
", scope);
        dynamic greetings = scope.GetVariable("greetings");
        System.Console.WriteLine(greetings("world"));

        dynamic primeSearch = scope.GetVariable("primeSearch");
        var primes = primeSearch(100);
        for (int i = 0; i < primes.Count; i++)
        {
            System.Console.WriteLine(primes[i]);
        }
    }
}