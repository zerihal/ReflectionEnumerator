# Reflection Enumerator

Reflection Enumerator uses reflection on a target .NET assembly (.dll file) to interrogate contained classes, methods, properties, etc and return an interrogated assembly object that can be easily used to view internal elements and generate a formatted / serialised JSON file for consumption in other applications, such as in the [Reflection Enumerator Web UI](https://github.com/zerihal/ReflectionEnumeratorWebUI) sample web app.

## Example Usage

Create an instance of ReflectionEnumerator.Interrogator to call InterrogateAssembly on a file or Assembly object.

```
// Create instance of Interrogator
var interrogator = new Interrogator(new ReflectorSettings(ReflectorModifiers.All));

// Get basic assembly and object info, outputting any error if required
var interrogatedAssembly = interrogator.InterrogateAssembly(TestAssembly, out var err);

// Assuming IInterrogatedAssembly returned is not null, hook reflection complete event and perform analysis
if (interrogatedAssembly != null)
{
  interrogatedAssembly.ReflectionComplete += async (s, e) =>
  {
    if (sender is IInterrogatedAssembly assembly)
    {
      // Perform further analysis as required, such as ...
      foreach (var assObj in assembly.AssemblyObjects)
      {
        await assObj.PopulateReflectedElements(ReflectionModifiers.All);

        // The above will populate Properties, Methods, Fields, Events, and Constructors collections for the assembly object,
        // which can now be utilised further (see interfaces for full details), for example ...
        foreach (var prop in assObj.Properties)
        {
          if (prop.HasSetter)
          {
            Debug.WriteLine(prop.Name);
          }
        }
      }
    }
  }

  interrogatedAssembly.GetAssemblyObjectElementsAsync();
}
