using ReflectionEnumerator.Settings;

namespace ReflectionEnumerator.Test
{
    public class InterrogatorTests
    {
        [SetUp]
        public void Setup()
        {
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