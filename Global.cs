using System.Collections.Generic;
using System.IO;

namespace AdministrationManagement
{
    public static class Global
    {
        public static Dictionary<string, AdministrationGroup> Administration = new Dictionary<string, AdministrationGroup>();

        public static readonly string AdministrationFullFileName = Path.Combine("/etc/scpsl/Administrative/", "Administration.txt");
    }

    public struct AdministrationGroup
    {
        public string Name { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}