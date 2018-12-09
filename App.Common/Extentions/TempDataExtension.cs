using Alamut.Data.Structure;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Common.Extentions
{
    public static class TempDataExtension
    {
        public static void AddResult(this ITempDataDictionary tempData,ServiceResult result)
        {
            tempData.Clear();
            tempData.Add("result.Messages", result.Message);
            tempData.Add("result.Succeed", result.Succeed);
        }
    }
}
