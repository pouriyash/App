using Alamut.Data.Structure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App.Common.Toolkit
{
    public static class Utility
    {
        public static ContentResult CloseAndRefreshOneLevel()
        {
            const string content = @"<script>
                window.parent.closeAndRefreshOneLevel();
            </script>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }


        public static ContentResult CloseAndRefresh()
        {
            var message = JsonConvert.SerializeObject(ServiceResult.Okay());
            var content = $"<script>window.parent.showBeautyMessageOnFancyBox({message});" +
                $"alert('HIiiiiiiiiii')" +
                $" setTimeout(window.parent.closeFancybox, 10);" +
                $"</script>";
            return new ContentResult() { Content = content, ContentType = "text/html; charset=utf-8" };
        }

        public static ContentResult CloseAndRedirectOneLevel()
        {
            var message = JsonConvert.SerializeObject(ServiceResult.Okay());
            var content = $"<script>window.parent.showBeautyMessageOnFancyBox({message});" +
                $"alert('HIiiiiiiiiii')" +
                $" setTimeout(window.parent.closeFancybox, 10);" +
                $"</script>";
            return new ContentResult() { Content = content, ContentType = "text/html; charset=utf-8" };
        }

        public static ContentResult CloseAndRedirect(string url)
        {
            var content = $@"<script>
                window.parent.closeAndRedirect('{url}');
            </script>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }

        public static ContentResult CloseFancybox()
        {
            const string content = @"<script>
                window.parent.closeFancybox();
            </script>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }

        public static ContentResult CloseFancyboxAndShowServiceResult(ServiceResult result)
        {
            var resultJson = JsonConvert.SerializeObject(result);

            var content = $@"<script>
                window.parent.closeFancyboxAndShowServiceResult({resultJson});
            </script>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }
    }
}