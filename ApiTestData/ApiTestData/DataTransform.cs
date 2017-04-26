using ApiTestData.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ApiTestData
{
    public class DataTransform
    {
        public static Item ToItem(SQLiteDataReader sqlLiteDataReader)
        {
            Item item = new Models.Item(Guid.Parse(sqlLiteDataReader.GetString(0)),
                                        sqlLiteDataReader.GetString(1),
                                        sqlLiteDataReader.GetInt32(2),
                                        DateTime.Parse(sqlLiteDataReader.GetString(3)));
            return item;
        }
    }
}