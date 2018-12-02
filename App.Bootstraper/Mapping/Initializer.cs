using System;
using System.Collections.Generic;
using System.Text;

namespace App.Bootstraper.Mapping
{
    public static class Initializer
    {
        public static void Init()
        {
            AutoMapper.Mapper.Initialize(c=>
            {
                c.AddProfile<PersonProfile>();
            });
        }
    }
}
