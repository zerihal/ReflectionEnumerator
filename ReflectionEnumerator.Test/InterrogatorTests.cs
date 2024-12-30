using ReflectionEnumerator.Settings;

namespace ReflectionEnumerator.Test
{
    public class InterrogatorTests
    {
        private const string testDllResource = @"Resources\Microsoft.Office.Tools.dll";
        private Interrogator _interrogator;
        private string _testDll;

        [SetUp]
        public void Setup()
        {
            _interrogator = new Interrogator(new ReflectorSettings(ReflectorModifiers.All));

            if (File.Exists(testDllResource))
            {
                _testDll = Path.GetFullPath(testDllResource);
            }
        }

        [Test]
        public void ConstructionTest()
        {
            var interrogator = new Interrogator();
            Assert.IsNotNull(interrogator?.Settings);
            Assert.That(interrogator?.Settings.Modifiers, Is.EqualTo(ReflectorModifiers.Public));
        }

        [Test]
        public void InterrogateTest()
        {
            if (_testDll != null)
            {
                Console.WriteLine($"Interrogate test being run on {testDllResource}");
                var interrogatedAssembly = _interrogator.InterrogateAssembly(_testDll, out _);
                Assert.IsNotNull(interrogatedAssembly);
                var reflectedElements = 0;

                foreach (var assemblyObject in interrogatedAssembly.AssemblyObjects)
                {
                    assemblyObject.PopulateReflectedElements(ReflectorModifiers.All).Wait();
                    reflectedElements++;
                }

                Assert.IsTrue(interrogatedAssembly.AssemblyObjects.Count(o => o.IsReflected) == reflectedElements);
            }
            else
            {
                Console.WriteLine("Warning: Test cannot be run as test dll is null");
            }
        }
    }
}