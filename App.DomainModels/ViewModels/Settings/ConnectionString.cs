using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels.Settings
{
    public class ConnectionString
    {
        public SqlServer SqlServer { get; set; }
        public Localdb LocalDb { get; set; }
        public string AppDbConnection { get; set; }
    }
}
