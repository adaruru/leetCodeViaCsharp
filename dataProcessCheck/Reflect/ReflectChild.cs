using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataProcessCheck.Reflect
{
    public class BatchAppEnum : BaseEnumConstructor
    {
        public BatchAppEnum(int id = 0) : base(id)
        {

        }
        /// <summary>
        /// 使用者資料匯入批次作業
        /// </summary>
        [Display(Name = "使用者資料匯入批次作業")]
        [Description("使用者資料匯入批次作業")]
        public static int UserDataImport => 901;

        /// <summary>
        /// 部門資料匯入批次作業
        /// </summary>
        [Display(Name = "部門資料匯入批次作業")]
        [Description("部門資料匯入批次作業")]
        public static int DeptDataImport => 902;

        [Display(Name = "測試")]
        [Description("測試")]
        public static int Test => 0;

        [Display(Name = "ControlM測試")]
        [Description("ControlM測試")]
        public static int ControlMTest => 1;
    }

    public class BatchAppEnumMethodBase : BaseEnumMethodBase
    {
        /// <summary>
        /// 使用者資料匯入批次作業
        /// </summary>
        [Display(Name = "使用者資料匯入批次作業")]
        [Description("使用者資料匯入批次作業")]
        public static string UserDataImport => "901";

        /// <summary>
        /// 部門資料匯入批次作業
        /// </summary>
        [Display(Name = "部門資料匯入批次作業")]
        [Description("部門資料匯入批次作業")]
        public static string DeptDataImport => "902";

    }
}