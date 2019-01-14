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
               parent.$.fancybox.close();
        window.parent.location.reload();
            </script>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }

        public static ContentResult CloseAndRedirect(string Url)
        {
            const string content = @"<script>
               parent.$.fancybox.close();
        window.parent.location.href();
            </script>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }

    }
}