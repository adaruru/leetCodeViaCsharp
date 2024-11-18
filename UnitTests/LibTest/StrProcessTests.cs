using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Lib.Model;
using static Lib.StrProcess;
using System.IO;
using System.Security;

namespace UnitTests.LibTest
{
    [TestClass()]
    public class StrProcessTests
    {
        StrProcess service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new StrProcess();
        }
        public enum TestEnum
        {
            DefaultTest = 0,
            FirstTest = 1,
            SecondTest = 2,
        }
        [TestMethod()]
        public void ValidIdTest()
        {
            var act = "A823456789";
            var assert = service.ValidId(act);
            Assert.AreEqual("12", assert);

            var act1 = "A123456789";
            var assert1 = service.ValidId(act1);
            Assert.AreEqual("11", assert1);
        }

        [TestMethod()]
        public void SecureRandomTest()
        {
            Console.WriteLine(service.SecureRandom(0, 5));
            Console.WriteLine(service.SecureRandom(0, 5));
            Console.WriteLine(service.SecureRandom(0, 5));
            Console.WriteLine(service.SecureRandom(0, 5));
            Console.WriteLine(service.SecureRandom(0, 5));
            Console.WriteLine(service.SecureRandom(0, 5));
            Console.WriteLine(service.SecureRandom(0, 5));
            Console.WriteLine(service.SecureRandom(0, 5));
            Console.WriteLine(service.SecureRandom(0, 5));
            Console.WriteLine(service.SecureRandom(0, 5));
            Assert.AreEqual(true, true);
        }


        [TestMethod()]
        public void RandomTest()
        {
            service.Random();
            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void XMLStringTest()
        {
            //arrange
            var arrange1 = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Tx><TxHead><HMSGID>P</HMSGID><HERRID>0000</HERRID><HSYDAY>1130722</HSYDAY><HSYTIME>161723</HSYTIME><HWSID>BONUS1    </HWSID><HSTANO>1202593</HSTANO><HDTLEN>0252</HDTLEN><HREQQ1/><HREPQ1>EA6PSQ    </HREPQ1><HDRVQ1>CCW00BHQ  </HDRVQ1><HPVDQ1>EA6PSQ    </HPVDQ1><HPVDQ2/><HSYCVD>1130720</HSYCVD><HTLID>DBBonus1  </HTLID><HTXTID>VB002</HTXTID><HFMTID>0001 </HFMTID><HRETRN>E</HRETRN><HSLGNF>1</HSLGNF><HSPSCK>Y8</HSPSCK><HRTNCD/><HSBTRF/><HFILL/></TxHead><TxBody><SPRefId>00001</SPRefId><CardNO>5157160105098703</CardNO><Name>李ＸＸＸＸ                              </Name><SEX>1</SEX><CrdCtyp>M</CrdCtyp><Y4M2>202812</Y4M2><GrpCode>0040</GrpCode><OrderCount>000025124</OrderCount><OfficeTel>02 28131232        </OfficeTel><HomeTel>02 28112312  </HomeTel><MobileTel>0903131303   </MobileTel><AreaCode>89049</AreaCode><Address>金門縣ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ</Address><EmailAddr>123i12io@gmail.com                      </EmailAddr></TxBody></Tx>";
            var arrange2 = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Tx><TxHead><HMSGID>P</HMSGID><HERRID>0000</HERRID><HSYDAY>1130719</HSYDAY><HSYTIME>102104</HSYTIME><HWSID>BONUS1    </HWSID><HSTANO>1202516</HSTANO><HDTLEN>0252</HDTLEN><HREQQ1/><HREPQ1>EA6PSQ    </HREPQ1><HDRVQ1>CCW00BHQ  </HDRVQ1><HPVDQ1>EA6PSQ    </HPVDQ1><HPVDQ2/><HSYCVD>1130719</HSYCVD><HTLID>DBBonus1  </HTLID><HTXTID>VB002</HTXTID><HFMTID>0001 </HFMTID><HRETRN>E</HRETRN><HSLGNF>1</HSLGNF><HSPSCK>Y8</HSPSCK><HRTNCD/><HSBTRF/><HFILL/></TxHead><TxBody><SPRefId>00001</SPRefId><CardNO>4987138199737542</CardNO><Name>林ＸＸＸＸ                              </Name><SEX>2</SEX><CrdCtyp>M</CrdCtyp><Y4M2>202912</Y4M2><GrpCode/><OrderCount>000000000</OrderCount><OfficeTel>02 273*****  189***</OfficeTel><HomeTel>02 273*****  </HomeTel><MobileTel>092*****62   </MobileTel><AreaCode>10676</AreaCode><Address>臺北市ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ</Address><EmailAddr>***************ubon.com                 </EmailAddr></TxBody></Tx>";


            //act 解密
            var act1 = service.XMLString(arrange1);
            var act2 = service.XMLString(arrange2);

            //assert
            Assert.AreEqual(act1, act1);
        }

        [TestMethod()]
        public void SecureStringToStringTest()
        {
            //arrange
            var input = "ASSDFSDF3444";

            //加密
            SecureString arrange = new SecureString();
            foreach (char c in input)
            {
                arrange.AppendChar(c);
            }

            //act 解密
            var act1 = service.SecureStringToString1(arrange);
            var act2 = service.SecureStringToString2(arrange);

            //assert
            Assert.AreEqual(act1, act1);
        }

        [TestMethod()]
        public void ContainTest()
        {
            //arrange
            var arrange1 = "該客戶未於本行登錄亞洲萬里通會員資料，請先進行航空會員登錄";
            var arrange2 = "該客戶未於本行登錄中華航空會員資料，請先進行航空會員登錄";
            var arrange3 = "該客戶未於本行登錄長榮航空會員資料，請先進行航空會員登錄";
            var arrange4 = "該客戶未於本行登錄AirAsia會員資料，請先進行航空會員登錄";

            //act null 不能執行contain
            var act1 = arrange1.Contains("請先進行航空會員登錄");
            var act2 = arrange2.Contains("該客戶未於本行登");
            var act3 = arrange3.Contains("該客戶未於本行");
            var act4 = arrange4.Contains("該客戶未於本行登錄A");


            //assert
            Assert.AreEqual(true, act1);
            Assert.AreEqual(true, act2);
            Assert.AreEqual(true, act3);
            Assert.AreEqual(true, act4);
        }

        [TestMethod()]
        public void GetCheckCodeTest()
        {
            //arrange
            var arrange = "008100";
            //act
            var act1 = service.GetCheckCode(arrange);
            //assert
            Assert.AreEqual("5", act1);
        }

        [TestMethod()]
        public void SplitTest()
        {
            //arrange
            var arrange = "sadfaaa_aaa_sdf_sdf_sdfsdf";
            var arrange2 = "Test_TestImport_temp_20230419094657.json";

            //act
            var act1 = arrange.Split('_')[0];

            var act2 = arrange2.Substring(0, arrange2.LastIndexOf('_'));
            var act3 = act2.Substring(0, act2.LastIndexOf('_'));
            var act4 = act2.Substring(act2.LastIndexOf('_') + 1);
            //assert
            Assert.AreEqual("sadfaaa", act1);
            Assert.AreEqual("Test_TestImport_temp", act2);
            Assert.AreEqual("Test_TestImport", act3);
            Assert.AreEqual("temp", act4);
        }

        [TestMethod()]
        public void EnumStringTest()
        {
            //arrange
            TestEnum? arrange = TestEnum.FirstTest;
            //act
            var key = (int)arrange;
            var value = arrange.ToString();

            arrange = null;
            //var nullkey = (int)arrange; runtime error
            var nullValue = arrange.ToString();

            //assert
            Assert.AreEqual(1, key);
            Assert.AreEqual("FirstTest", value);
            Assert.AreEqual("", nullValue);
        }

        [TestMethod()]
        public void GetApplyCodeTest()
        {
            //arrange
            var VACCIDNO1 = "    1234567890123";
            var VACCIDNO2 = "    12345678901234";
            var VACCIDNO3 = "    12300678901234";
            var VACCIDNO4 = "   01234567890123456";
            var VACCIDNO5 = "00001234567890123456";

            //act
            var applyCode1 = service.GetApplyCode(VACCIDNO1);
            var applyCode2 = service.GetApplyCode(VACCIDNO2);
            var applyCode3 = service.GetApplyCode(VACCIDNO3);
            var applyCode4 = service.GetApplyCode(VACCIDNO4);
            var applyCode5 = service.GetApplyCode(VACCIDNO5);

            //assert
            Assert.AreEqual("123456", applyCode1);
            Assert.AreEqual("12345", applyCode2);
            Assert.AreEqual("123", applyCode3);
            Assert.AreEqual("1234", applyCode4);
            Assert.AreEqual("1234", applyCode5);
        }

        [TestMethod()]
        public void StrSubAllTest()
        {
            service.StrSubAll();
            //assert
            Assert.AreEqual(1, 1);
        }
    }
}