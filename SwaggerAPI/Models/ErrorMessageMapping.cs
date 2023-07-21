namespace SwaggerAPI.Models
{
    public static class ErrorMessageMapping
    {

        public static string GetErrors(string errorCode, string errDetail = "") => errorCode switch
        {
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_INPUT" => $"กรอกข้อมูลไม่ครบหรือข้อมูลผิด {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_INPUT_FILETYPE" => $"ชนิดไฟล์ไม่ถูกต้อง {errDetail} ",
            "NOTFOUND_ORG" => $"ชื่อกล่องไม่มีในระบบ รบกวนตรวจสอบชื่อกล่องและ อัปโหลดใหม่อีกครั้ง {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORG_NOTFOUND_CUST" => $"ไม่พบร้านค้าในระบบ รบกวนตรวจสอบและ อัปโหลดใหม่อีกครั้ง {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORG_NOTFOUND_EMP" => $"ไม่พบพนักงานในระบบ รบกวนตรวจสอบและ อัปโหลดใหม่อีกครั้ง {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_INPUT_GROUP" => $"ไม่พบข้อมูลกลุ่มสินค้า {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_INPUT_GROUPORDERRANK" => $"ไม่พบข้อมูลลำดับกลุ่มสินค้า {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_INPUT_BRAND" => $"ไม่พบข้อมูลแบรนด์สินค้า {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_INPUT_BRANDORDERRANK" => $"ไม่พบข้อมูลลำดับแบรนด์สินค้า {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_INPUT_MASTERMATERIALNO" => $"ไม่พบข้อมูลรหัสสินค้า {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_INPUT_MASTERMATERIALORDERRANK" => $"ไม่พบข้อมูลลำดับสินค้า {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_NOTFOUND" => $"ไม่พบ {errDetail} ในระบบ",
            "ACTIVITY_ERROR_UPLOADORGMATSEQ_EXCEL_EMPTY" or "ACTIVITY_ERROR_UPLOADORGCUST_EXCEL_EMPTY"
            => $"ไม่พบข้อมูลในไฟล์ Excel {errDetail} ",
            "ACTIVITY_ERROR_UPLOADORGCUST_NOTFOUND" => $"ไม่พบข้อมูล {errDetail} ",
            "ACTIVITY_ERROR_DOWNLOADSALEORGCUSTOMER_NOTFOUND" => $"ไม่พบข้อมูล {errDetail}",
            _ => $"{errDetail}"
        };
    }
}
