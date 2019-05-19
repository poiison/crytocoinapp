using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Entities
{
    public class Parametros
    {
        public static string UrlApiCryptonator
        {
            get
            {
                return ConfigurationManager.AppSettings["API_CRYPTONATOR"];
            }
        }

        public static string UrlApiShrimpy
        {
            get
            {
                return ConfigurationManager.AppSettings["API_SHRIMPY"];
            }
        }

        public static string UrlApiBitcoinfee
        {
            get
            {
                return ConfigurationManager.AppSettings["API_BITCOINFEES"];
            }
        }
    }
}
