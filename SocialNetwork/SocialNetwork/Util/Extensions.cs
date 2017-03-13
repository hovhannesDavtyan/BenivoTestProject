using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace SocialNetwork
{
    public static class Extensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }

        public static int GetPageCountByItemCount(int itemCount)
        {
            string perPageString = ConfigurationManager.AppSettings["ItemsPerPage"];
            int perPage = int.Parse(perPageString);
            return (itemCount + (perPage - 1)) / perPage;
        }
    }
}