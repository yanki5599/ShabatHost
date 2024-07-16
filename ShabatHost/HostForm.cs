using ShabatHost.DAL;
using ShabatHost.Reposetory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShabatHost.Model;

namespace ShabatHost
{
    public partial class HostForm : Form
    {
        DBContext _dbContext;
        private CategoryRepository _categoryRepository;
        public HostForm(DBContext dBContext)
        {
            _dbContext = dBContext;
            _categoryRepository = new CategoryRepository(_dbContext);
            InitializeComponent();
            LoadCategoriesList();
        }

        private void button_addCategory_Click(object sender, EventArgs e)
        {
            string catName = textBox_inputCategory.Text.Trim();
            if (string.IsNullOrEmpty(catName))
            {
                MessageBox.Show("cannot be empty.");
            }
            bool success = _categoryRepository.Insert(new CategoryModel(catName));
            if (!success)
            {
                MessageBox.Show("unable to add name!", "error",MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            LoadCategoriesList();
            textBox_inputCategory.Clear();
        }

        private void LoadCategoriesList()
        {
            listView_categoriesList.Items.Clear();
            listView_categoriesList.Columns.Add("קטגוריה");
            List<ListViewItem> categories = new List<ListViewItem>();
            _categoryRepository.GetAll().ForEach
                (category => categories.Add(new ListViewItem(category.Name)));
            listView_categoriesList.Items.AddRange(categories.ToArray());
        }
    }
}
