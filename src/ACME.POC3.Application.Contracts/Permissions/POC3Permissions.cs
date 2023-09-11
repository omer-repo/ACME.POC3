namespace ACME.POC3.Permissions;

public static class POC3Permissions
{
    public const string GroupName = "POC3";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public class Invoice
    {
        public const string Default = GroupName + ".Invoice";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class InvoiceLine
    {
        public const string Default = GroupName + ".InvoiceLine";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
