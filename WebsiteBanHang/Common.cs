using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBanHang
{
    public class Common
    {
        [NonAction]
        public SelectList ToSelectList(DataTable table,string valueField,string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach(DataRow dr in table.Rows) {
                list.Add(new SelectListItem()
                {
                    Text = dr[textField].ToString(),
                    Value = dr[valueField].ToString()
                });
            }
            return new SelectList(list,"Value","Text");
        }
        public class ListtoDataTableConverter { 
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dt = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props= typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props) {
                    //Setting column names as Property names
                    dt.Columns.Add(prop.Name);
                }
                foreach (T item in items) {
                    var values = new object[Props.Length];
                    for (int i = 0; i < values.Length; i++) {
                        //inserting property values to datatable rows
                        values[i]=Props[i].GetValue(item,null);
                    }
                   dt.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dt;
            }
        }
        public class ProductType
        {
            public int Id { get; set; }
            public string Name { get;set; }
        }
        public class OrderStatus {
            public int Id { get; set; }
            public string Name { get; set; }
        }


    }
}