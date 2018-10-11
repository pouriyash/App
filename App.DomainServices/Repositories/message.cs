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
            IOptions<SiteSettings> _settings;
        public MessagesService(IOptions<SiteSettings> settings)
            {
                _settings = settings;
            }
            public string GetSiteName()
            {
                var cs=_settings.Value.ConnectionStrings;
                return "DNT";
            }
        }
    }
}
