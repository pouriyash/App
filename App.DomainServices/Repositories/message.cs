using App.DomainModels.ViewModels.Settings;
using Microsoft.Extensions.Options;
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
            IOptions<ConnectionString> _settings;
        public MessagesService(IOptions<ConnectionString> settings)
            {
                _settings = settings;
            }
            public string GetSiteName()
            {
                var cs=_settings.Value.AppDbConnection;
                return "App";
            }
        }
    }
}
