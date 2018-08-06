using Microsoft.VisualStudio.TestTools.UnitTesting;
using hemopet.Core.Services.Remote.Example;
using System.Threading.Tasks;
using MvvmHelpers;
using System.Linq;
using Models = hemopet.Core.Models;

namespace hemopet.UnitTest.Services.Example
{
    [TestClass]
    public class ExemplaServiceTest
    {
        [TestMethod]
        [TestCategory("Services")]
        public async Task GetExamples()
        {
            FakeExampleService fakeExampleService = new FakeExampleService();
            ObservableRangeCollection<Models.Example> result = await fakeExampleService.Get(0);

            Assert.IsNotNull(result, "A lista não pode ser NULL");
            CollectionAssert.AreNotEqual(new ObservableRangeCollection<Models.Example>(), result, "A lista não pode estar vazia");
        }

        [TestMethod]
        [TestCategory("Services")]
        public async Task PostExample()
        {
            Models.Example newExample = new Models.Example { texto = "text" };

            FakeExampleService fakeExampleService = new FakeExampleService();
            newExample = await fakeExampleService.Post(newExample);

            ObservableRangeCollection<Models.Example> examples = await fakeExampleService.Get(0);

            CollectionAssert.Contains(examples, newExample, "A lista deve conter esse novo example");
        }
    }
}
