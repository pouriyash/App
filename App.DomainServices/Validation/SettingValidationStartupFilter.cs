using App.DomainModels.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainServices.Validation
{
    public class SettingValidationStartupFilter : IStartupFilter
    {
        readonly IEnumerable<IValidatable> _validatableObjects;
        public SettingValidationStartupFilter(IEnumerable<IValidatable> validatableObjects)
        {
            _validatableObjects = validatableObjects;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            foreach (var validatableObject in _validatableObjects)
            {
                validatableObject.Validate();
            }

            //don't alter the configuration
            return next;
        }
    }
}
