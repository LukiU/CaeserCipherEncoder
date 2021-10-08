using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaeserCipherEncoder;

namespace CaeserCipherEncoder.Test
{
    [TestClass]
    public class CaeserCipherEncoderTest
    {
        private string originalText = "Sveikas, Pasauli. Ką tu šį vakarą?";


        ///<summary>
        ///Užšifravimo testas paslenkt raides per vieną į priekį.
        ///</summary>
        [TestMethod]
        public void TestEncipherShift1()
        {
            int key = 1;
            string expectedEncipheredString = "Šwęįląš, Qąšąųmį. Lb uų tj wąląsb?";

            Assert.AreEqual(expectedEncipheredString, CaeserCipherEncoder.Encode(originalText, key));
        }
        ///<summary>
        ///Užšifravimo testas paslenkt raides per vieną atgal.
        ///</summary>
        [TestMethod]
        public void TestEncipherShiftMinus1()
        {
            int key = -1;
            string expectedEncipheredString = "Rūdhjžr, Ožržtkh. Ja št si ūžjžqa?";
            Assert.AreEqual(expectedEncipheredString, CaeserCipherEncoder.Encode(originalText, key));
        }
        ///<summary>
        ///Užšifravimo ir iššifravimo testas su raktu 1.
        ///</summary>
        [TestMethod]
        public void TestEncipherDecipher1()
        {
            int key = 1;

            Assert.AreEqual(originalText, CaeserCipherEncoder.Decode(CaeserCipherEncoder.Encode(originalText, key), key));

        }
        ///<summary>
        ///Užšifravimo ir iššifravimo testas su mažiausia galima <c>int</c> reikšme.
        ///</summary>
        [TestMethod]
        public void TestEncipherDecipherMin()
        {
            int key = int.MinValue;

            Assert.AreEqual(originalText, CaeserCipherEncoder.Decode(CaeserCipherEncoder.Encode(originalText, key), key));

        }
        ///<summary>
        ///Užšifravimo ir iššifravimo testas su didžiausia galima <c>int</c> reikšme.
        ///</summary>
        [TestMethod]
        public void TestEncipherDecipherMax()
        {
            int key = int.MaxValue;

            Assert.AreEqual(originalText, CaeserCipherEncoder.Decode(CaeserCipherEncoder.Encode(originalText, key), key));

        }

    }
}
