using Microsoft.VisualStudio.TestTools.UnitTesting;
using hemopet.Core.Converters;

namespace hemopet.UITest.Converters
{
    [TestClass]
    public class SuspensionPointsConverterTest
    {

        [TestMethod]
        [TestCategory("Converters")]
        public void SuspensionPoint_ToBigText()
        {
            SuspensionPointsConverter converter = new SuspensionPointsConverter();
            string texto = "O rato roeu a roupa do rei de roma";
            Assert.AreEqual("O rato roe...", converter.Convert(texto, null, "10", null));
            Assert.AreEqual(texto, converter.ConvertBack(texto, null, "10", null));
        }

        [TestMethod]
        [TestCategory("Converters")]
        public void SuspensionPoint_ToSmallText()
        {
            SuspensionPointsConverter converter = new SuspensionPointsConverter();
            string texto = "O rato roeu a roupa do rei de roma";
            Assert.AreEqual(texto, converter.Convert(texto, null, "100", null));
            Assert.AreEqual(texto, converter.ConvertBack(texto, null, "100", null));
        }

        [TestMethod]
        [TestCategory("Converters")]
        public void SuspensionPoint_ToEmptyValue()
        {
            SuspensionPointsConverter converter = new SuspensionPointsConverter();
            Assert.AreEqual("", converter.Convert("", null, "10", null));
            Assert.AreEqual("", converter.ConvertBack("", null, "10", null));

            Assert.AreEqual("teste", converter.Convert("teste", null, "", null));
            Assert.AreEqual("teste", converter.ConvertBack("teste", null, "", null));

            Assert.AreEqual("", converter.Convert("", null, "", null));
            Assert.AreEqual("", converter.ConvertBack("", null, "", null));

        }

        [TestMethod]
        [TestCategory("Converters")]
        public void SuspensionPoint_ToNullText()
        {
            SuspensionPointsConverter converter = new SuspensionPointsConverter();
            Assert.AreEqual(null, converter.Convert(null, null, null, null));
            Assert.AreEqual(null, converter.ConvertBack(null, null, null, null));
        }


    }
}
