using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class ProductForm : Form
    {
        CrmContext db;
        public Product Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
            Product = new Product();

        }

        public ProductForm(Product product):this()
        {
            Product = product ?? new Product();
            textBox1.Text = Product.Name;
            numericUpDown1.Value = Product.Price;
            numericUpDown2.Value = Product.Count;
            textBox4.Text = Product.Color;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var product = Product ?? new Product();

            product.Name = textBox1.Text;
            product.Price = numericUpDown1.Value;
            product.Count = Convert.ToInt32(numericUpDown2.Value);
            product.Color = textBox4.Text;

            Close();

        }
    }
}
