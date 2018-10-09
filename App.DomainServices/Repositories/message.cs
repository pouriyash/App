using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainServices.Repositories
{
    public class message
    {
        public interface IMessagesService
        {
            string GetSiteName();
        }

        public class MessagesService : IMessagesService
        {
            public string GetSiteName()
            {
                return "DNT";
            }
        }
    }
}
