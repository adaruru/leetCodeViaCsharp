using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using static Lib.EncryptUtil;

namespace UnitTests.LibTest
{
    [TestClass()]
    public class EncryptUtilTests
    {
        EncryptUtil service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new EncryptUtil();
        }

        [TestMethod()]
        public void AESEncryptTest()
        {
            /*
             * {"accessToken": "aaddccdd","refreshToken": ""}
             * 
             */
            var raw = "{\"accessToken\": \"aaddccdd\",\"refreshToken\": \"\"}";
            var key = "2347423223474232";
            var Iv = "2719580527195805";
            var encryptText = AESCBC.Encrypt(raw, key, Iv);
            var decryptText = AESCBC.Decrypt(encryptText, key, Iv);

            var raw2 = "{\"uid\": \"abc\",\"uuid\": \"uuidAbc\",\"loginType\":\"m1\"}";
            var en2 = AESCBC.Encrypt(raw2, key, Iv);
            Assert.AreEqual(decryptText, raw);
        }
    }
}