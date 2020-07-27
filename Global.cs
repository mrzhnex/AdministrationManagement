using System.Collections.Generic;
using System.IO;

namespace AdministrationManagement
{
    public static class Global
    {
        public static Dictionary<string, UserGroup> Administration = new Dictionary<string, UserGroup>();

        public static readonly string AdministrationFullFileName = Path.Combine("/etc/scpsl/Administrative/", "Administration.txt");
    }
}