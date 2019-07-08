using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Integration.Others
{
    public static class Connection
    {
        //private static string cn = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();

        //Em produção pegaríamos do Config.
        private static string cn = @"Server=(localdb)\mssqllocaldb;Database=STN;Trusted_Connection=True;";

        public static string Cn { get => cn; set => cn = value; }
    }
}
