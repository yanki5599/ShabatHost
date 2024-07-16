using ShabatHost.DAL;
using ShabatHost.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabatHost.Reposetory
{
    internal class CategoryRepository : IRepository<CategoryModel>
    {
        private readonly DBContext _dbContext;

        

        public CategoryRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CategoryModel> GetAll()
        {
            var categories = new List<CategoryModel>();
            string query = "SELECT ID, Name FROM FoodCategories";

            DataTable result = _dbContext.ExecuteQuery(query);
            foreach (DataRow row in result.Rows)
                categories.Add(new CategoryModel(row));

            return categories;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryModel? FindById(int id)
        {
            string query = "SELECT ID, Name FROM FoodCategories fc where fc.ID = @id";

            var parameter = new SqlParameter("@id", SqlDbType.Int) { Value = id };


            var dt = _dbContext.ExecuteQuery(query, parameter);
            if (dt.Rows[0] == null)
                return null;

            return new CategoryModel(dt.Rows[0]);
        }

        public bool Insert(CategoryModel entity)
        {
            string query = "INSET INTO FoodCategories(name) VALUES(@categoryName)";

            var parameter = new SqlParameter("@categoryName", SqlDbType.NVarChar) { Value = entity.Name };

            return _dbContext.ExecuteNonQuery(query, parameter) > 0;
        }

        public bool Update(CategoryModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
