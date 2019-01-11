﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Entities
{
    /// <summary>
    /// ارتباط با ما
    /// </summary>
    public class ContactUs
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        
    }
}
