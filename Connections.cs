using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    internal static class Connections
    {
        public const string ConnectionString = """
                Server=HASSAN;
                Database=EFCoreTestDB;
                User Id=sa;
                Password=sa123456;
                TrustServerCertificate=True;
                """;
    }
}
