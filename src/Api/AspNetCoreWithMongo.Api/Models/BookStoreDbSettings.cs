using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithMongo.Api.Models
{
    public class BookStoreDbSettings : IDbSettings
    {
        public string CollectionName { get ; set ; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
