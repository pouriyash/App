using App.DomainModels.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Entities.Identity
{
   public  class AppLogItem: IAuditableEntity
    {
        public int Id { set; get; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public int EventId { get; set; }

        public string Url { get; set; }

        public string LogLevel { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }

        public string StateJson { get; set; }
    }
}
