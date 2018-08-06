using NUnit.Framework;

using hemopet.UITest.Core;
using hemopet.UITest.Pages;

using Xamarin.UITest;

namespace hemopet.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        public Tests(Platform platform)
        {
            AppManager.Platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            AppManager.StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            new HomePage().ValidarViews();
        }
    }
}

