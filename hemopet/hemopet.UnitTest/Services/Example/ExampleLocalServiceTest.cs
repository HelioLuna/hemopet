using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmHelpers;
using hemopet.Core.Services.Local.Example;
using System;
using System.Threading.Tasks;
using Models = hemopet.Core.Models;

namespace hemopet.UnitTest.Services.Example
{
    [TestClass]
    public class ExampleLocalServiceTest
    {
        [TestMethod]
        [TestCategory("LocalServices")]
        public async Task ReadAllExamples()
        {
            FakeExampleLocalService fakeExampleLocalService = new FakeExampleLocalService();
            ObservableRangeCollection<Models.Example> result = await fakeExampleLocalService.ReadAll();

            Assert.IsNotNull(result, "A lista não pode ser NULL");
            CollectionAssert.AreNotEqual(new ObservableRangeCollection<Models.Example>(), result, "A lista não pode estar vazia");
        }

        [TestMethod]
        [TestCategory("LocalServices")]
        public async Task InsertExample()
        {
            Models.Example newExample = new Models.Example { texto = "text" };

            FakeExampleLocalService fakeExampleLocalService = new FakeExampleLocalService();
            newExample = await fakeExampleLocalService.Insert(newExample, TimeSpan.FromDays(14));

            ObservableRangeCollection<Models.Example> examples = await fakeExampleLocalService.ReadAll();

            CollectionAssert.Contains(examples, newExample, "A lista deve conter esse novo example");
        }
    }
}
