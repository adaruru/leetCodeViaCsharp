using LeetCode;
using Lib;

namespace TestApp;

public class RunCoreLib
{
    public void Run() {
        
        #region my Test tool
        //演算法實作
        //Algorithm.BubbleSort();

        /*
         * 基礎練習
        */
        //printStar.main(); 
        //OtherTest.LotteryGame();//6 碼樂透程式
        //OtherTest.plusToTarget();//遞迴 n 加到 1

        //字串處理
        var strProcess = new StrProcess();
        strProcess.playGround();
        //strProcess.StringConcat();
        // strProcess.StrSubAll();
        //strProcess.StrFuncTry(); 
        //strProcess.StrFormat();
        //strProcess.StrPadPractice();
        //strProcess.IsNullCheck();

        //資料轉型
        var convert = new DataConvert();
        //convert.StrListParse();
        //convert.StringDecimalPoint();
        //convert.ConvertTry();
        //convert.ConvertDirect();
        //convert.ConvertTool();

        //資料列表練習
        var listPractice = new ListTypeDataPractice();
        //listPractice.ListIndexPractice();
        //listPractice.DictionaryPractice();
        //listPractice.ArrayPractice();
        //listPractice.ListOrderBy();
        //listPractice.ListPractice();
        //listPractice.getRangePractice();
        //listPractice.ListExportFile();

        //物件練習
        var ob = new ObjectPractice();
        //ob.ObjectFiltSetValue();
        //ob.ObjectAllSetValues();
        //ob.ObjectGetValues();
        //ob.CheckCopy();
        //ob.ObjectSetDefault();
        //ob.seeIfTimeSpan();

        /*
         * 應用練習
         */

        //日期時間格式
        var check = new DateFormat();
        //check.ToChineseDate();
        //check.SimpleFormat();

        ////正則驗證
        var reg = new RegValidate();
        //reg.regValidEmail();
        //reg.boolPractice();

        #endregion
    }
}
