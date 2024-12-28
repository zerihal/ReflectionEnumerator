using ReflectionEnumerator;
using ReflectionEnumerator.EventArguments;
using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Objects;
using ReflectionEnumerator.Settings;

internal class Program
{
    // Add in full path of assembly that is to be tested ...
    private static string TestAssembly = @"";

    private static void Main(string[] args)
    {
        var interrogator = new Interrogator(new ReflectorSettings(ReflectorModifiers.All));
        var interrogatedAssembly = interrogator.InterrogateAssembly(TestAssembly, out _);

        if (interrogatedAssembly != null )
        {
            Console.WriteLine($"Assembly loaded: {interrogatedAssembly.Name}");
            Console.WriteLine($"Assembly version: {interrogatedAssembly.Version}");

            interrogatedAssembly.ReflectionComplete += InterrogatedAssembly_ReflectionComplete;
            interrogatedAssembly.GetAssemblyObjectElementsAsync();
        }
        else
        {
            Console.WriteLine("Interrogated assembly returned null");
        }

        Console.ReadKey();
    }

    private static void InterrogatedAssembly_ReflectionComplete(object? sender, ReflectionCompleteEventArgs e)
    {
        if (sender is IInterrogatedAssembly assembly)
        {
            foreach (var assObj in assembly.AssemblyObjects)
            {
                Console.WriteLine(assObj.Name);
            }

            if (assembly.AssemblyReflectionError != null)
                Console.WriteLine(assembly.AssemblyReflectionError.ErrorMessage);

            var serialisedJson = assembly.Serialize(SerializationType.JSON);
        }
    }
}