using ACME.POC3.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ACME.POC3.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class POC3Controller : AbpControllerBase
{
    protected POC3Controller()
    {
        LocalizationResource = typeof(POC3Resource);
    }
}
