//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeachSys.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students
    {
        public int ID { get; set; }
        public Nullable<int> ClassID { get; set; }
        public string Name { get; set; }
        public string StudentNo { get; set; }
        public string Password { get; set; }
        public string TelNum { get; set; }
        public string QQ { get; set; }
        public string WeChat { get; set; }
        public string PTelNo1 { get; set; }
        public string PTelNo2 { get; set; }
        public int IsLogin { get; set; }
        public int Stauts { get; set; }
    
        public virtual Classes Classes { get; set; }
    }
}
