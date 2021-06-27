using dataProcessCheck;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace CsharpStartTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LeetCodePractice

            //BubbleSort.main();
            //Day4_Class_vs_Instance.main();

            //JudgeZeroa022_PalindromeString.main();
            //Judgezeroa010_PrimeFactorization.main();
            //Judgezeroc459_NarcissisticNumber.main();

            //Leet001_2Sum1.main();
            //Leet001_2Sum2.main();
            //Leet001_2Sum3.main();
            //Leet001_2Sum4.main();
            //Leet002_QustAddTwoNumber.main();
            //Leet007_ReverseInteger_1.main();
            //Leet007_ReverseInteger_2.main();
            //Leet008_StringToIntegerATOI_1.main();
            //Leet008_StringToIntegerATOI_2.main();
            //Leet008_StringToIntegerATOI_3.main();
            //Leet009_PalindromeNumber.main();
            //Leet012_IntegerToRoman.main();
            //Leet013_RomanToInteger.main();
            //Leet015_3Sum1.main();
            //Leet015_3Sum2.main();

            //Leet020_ValidParentheses.main();

            //Leet058_LengthOfLastWord.main();
            //Leet066_PlusOne.main();
            //Leet069_Sqrt.main();
            //Leet070_ClimbingStairs.main();
            //Leet079_WordSearch.main();
            //Leet101_SymmetricTree.main();
            Leet322_CoinChange.main();

            //Mentor3_hw2_ChangeCharCaseInString.main();

            //printStar.main(); 
            #endregion


            #region my Test tool

            /*
             * 基礎練習
            */

            //字串處理
            var strProcess = new StrProcess();
            //strProcess.StrSubAll();
            //strProcess.StrFuncTry(); 
            //strProcess.StrFormat();
            //strProcess.IsNullCheck();

            //資料轉型
            var convert = new DataConvert();
            //convert.StringDecimalPoint();
            //convert.ConvertTry();
            //convert.ConvertDirect();
            //convert.ConvertTool();

            //資料列表練習
            var listPractice = new ListTypeDataPractice();
            //listPractice.ListIndexPractice();
            //listPractice.DictionaryPravtice();
            //listPractice.ArrayPractice();
            //listPractice.ListPractice();
            //listPractice.getRangePractice();

            //物件練習
            var ob = new ObjectPractice();
            //ob.ObjectFiltSetValue();
            //ob.ObjectAllSetValues();
            //ob.ObjectGetValues();
            //ob.CheckCopy();
            //ob.ObjectSetDefault();


            /*
             * 應用練習
             */

            //日期時間格式
            var check = new DateFormat();
            //check.ToChineseDate();
            //check.SimpleFormat();

            ////正則驗證
            //var reg = new RegValidate();
            //reg.regValidEmail();



            #endregion

        }

    }

}







