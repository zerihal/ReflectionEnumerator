using ReflectionEnumerator;
using ReflectionEnumerator.EventArguments;
using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Objects;
using ReflectionEnumerator.Settings;

internal class Program
{
    private static void Main(string[] args)
    {
        var interrogator = new Interrogator(new ReflectorSettings(ReflectorModifiers.All));
        var interrogatedAssembly = interrogator.InterrogateAssembly(@"D:\source\AESEncryptionTester\AESEncryptionTestUtils\bin\Debug\net8.0\AESEncryptionTestUtils.dll");

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

            var serialisedJson = assembly.Serialize(SerializationType.JSON);
        }
    }
}