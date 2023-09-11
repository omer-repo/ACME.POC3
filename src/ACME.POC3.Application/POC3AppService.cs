using System;
using System.Collections.Generic;
using System.Text;
using ACME.POC3.Localization;
using Volo.Abp.Application.Services;

namespace ACME.POC3;

/* Inherit your application services from this class.
 */
public abstract class POC3AppService : ApplicationService
{
    protected POC3AppService()
    {
        LocalizationResource = typeof(POC3Resource);
    }
}
