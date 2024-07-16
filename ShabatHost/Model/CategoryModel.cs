using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabatHost.Model
{
    internal class CategoryModel
    {

        public string Name { get; set; }
        public int? ID { get; set; }

        public CategoryModel(string name , int? id = null)
        {
            Name = name;
            ID = id;
        }

        // ctor from datarow
        public CategoryModel(DataRow row)
        {
            if (row == null || row["Name"] == null || row["ID"] == null)
            {
                throw new System.ArgumentNullException(nameof(row));
            }
            Name = row["Name"].ToString()!;
            ID = (int)row["ID"];
        }
    }
}
