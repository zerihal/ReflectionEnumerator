using ReflectionEnumerator.Settings;

namespace ReflectionEnumerator.Test
{
    public class InterrogatorTests
    {
        private Interrogator _interrogator;

        [SetUp]
        public void Setup()
        {
            _interrogator = new Interrogator(new ReflectorSettings(ReflectorModifiers.All));
        }

        [Test]
        public void ConstructionTest()
        {
            var interrogator = new Interrogator();
            Assert.IsNotNull(interrogator?.Settings);
            Assert.That(interrogator?.Settings.Modifiers, Is.EqualTo(ReflectorModifiers.Public));
        }
    }
}