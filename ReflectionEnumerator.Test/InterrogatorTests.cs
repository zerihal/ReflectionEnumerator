using ReflectionEnumerator.Settings;

namespace ReflectionEnumerator.Test
{
    public class InterrogatorTests
    {
        private Interrogator _interrogator;
        private string _testDll;

        [SetUp]
        public void Setup()
        {
            _interrogator = new Interrogator(new ReflectorSettings(ReflectorModifiers.All));

            if (File.Exists(@"Resources\Microsoft.Office.Tools.dll"))
            {
                _testDll = Path.GetFullPath(@"Resources\Microsoft.Office.Tools.dll");
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
                var interrogatedAssembly = _interrogator.InterrogateAssembly(_testDll);
                Assert.IsNotNull(interrogatedAssembly);
            }
        }
    }
}