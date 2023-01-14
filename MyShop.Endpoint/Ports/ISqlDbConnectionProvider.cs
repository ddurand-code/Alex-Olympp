using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Endpoint.Ports
{
    public interface ISqlDbConnectionProvider
    {
        DbConnection GetSqlConnection();
    }
}
