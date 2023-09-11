using ACME.POC3.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ACME.POC3.Permissions;

public class POC3PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(POC3Permissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(POC3Permissions.MyPermission1, L("Permission:MyPermission1"));

        var invoicePermission = myGroup.AddPermission(POC3Permissions.Invoice.Default, L("Permission:Invoice"));
        invoicePermission.AddChild(POC3Permissions.Invoice.Create, L("Permission:Create"));
        invoicePermission.AddChild(POC3Permissions.Invoice.Update, L("Permission:Update"));
        invoicePermission.AddChild(POC3Permissions.Invoice.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<POC3Resource>(name);
    }
}
