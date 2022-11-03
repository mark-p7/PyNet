using IronPython.Runtime;
using IronPython.Hosting;
var engine = IronPython.Hosting.Python.CreateEngine();
var scope = engine.CreateScope();
engine.Execute(@"
def helloWorld(hello):
    return hello + ' world!'
", scope);

dynamic helloWorld = scope.GetVariable("helloWorld");
string helloWorldString = helloWorld("Hello,");

Console.WriteLine("Hello, World!");
Console.WriteLine(helloWorldString);
