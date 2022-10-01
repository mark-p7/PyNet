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
    
", scope);
        dynamic greetings = scope.GetVariable("greetings");
        System.Console.WriteLine(greetings("world"));
    }
}