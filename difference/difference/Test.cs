using System.Diagnostics;
using System.Reflection;
using Pastel;
using Terminal.Gui;
using Attribute = System.Attribute;

namespace difference;

public class GotchaAttribute : Attribute
{
    public GotchaAttribute(string str)
    {
    }
}

public class Test {
    // string Add(int a, int b) {
    //     return a.ToString() + b.ToString();
    // }
    //
    // public Test() {
    //     RunTest<string>("a", "z", Add, new object[] {1, 2});
    // }

    // public void RunTest(string name, object right, Delegate left, params object[] args) {
    //     var result = left.DynamicInvoke(args);
    //     
    //     if (Assert(result, right)) {
    //         Console.ForegroundColor = ConsoleColor.DarkGreen;
    //         Console.WriteLine($"Passed: {name} '{result}' == '{right}'");
    //     }
    //     else {
    //         Console.ForegroundColor = ConsoleColor.DarkRed;
    //         Console.WriteLine($"Failed {name} '{result}' != '{right}'");
    //         foreach (var argument in info.GetParameters()) {
    //             Console.WriteLine(argument.ParameterType.Name);
    //         }
    //     }
    //
    //     Console.ResetColor();
    // }
    
    public static bool Assert(string message, string left, string right) {
        Debug.Assert(left == right, $"{message}\n{left} !=\n{right}".Pastel(ConsoleColor.Red));
        Console.WriteLine($"passed: {message} '{left}' == '{right}'".Pastel(ConsoleColor.Green));
        return left.Equals(right);
    }
}