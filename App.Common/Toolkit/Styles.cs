using System;
using System.Collections.Generic;
using System.Text;

namespace App.Common.Toolkit
{
    public static class  Styles
    {
        public static string MakeLayoutBlank()
        {
            return @"
                <style>
                   .sidebar , .header .header__menu , .header{
                        display:none;
                    }
                    .content {
                        padding:20px;
                    }
                </style>
            ";
        }

    }
}
