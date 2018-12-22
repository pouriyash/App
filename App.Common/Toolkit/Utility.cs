using Alamut.Data.Structure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App.Common.Toolkit
{
    public static class Utility
    {


        public static ContentResult CloseAndRefresh()
        {
            const string content = @"<script>
                CloseAndRefresh();
            </script>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }

    }
}