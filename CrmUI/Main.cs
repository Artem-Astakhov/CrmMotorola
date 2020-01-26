using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Main : Form
    {
        CrmContext db;
        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products);
            catalogProduct.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Seller>(db.Sellers);
            catalogProduct.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Customer>(db.Customers);
            catalogProduct.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Check>(db.Checks);
            catalogProduct.Show();
        }

        private void CustomerAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCustomer = new CustomerForm();
            if (formCustomer.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(formCustomer.Customer);
                db.SaveChanges();
            }
        }

        private void SellerAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSeller = new SellerForm();
            if (formSeller.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(formSeller.Seller);
                db.SaveChanges();
            }
        }

        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProduct = new ProductForm();
            if (formProduct.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(formProduct.Product);
                db.SaveChanges();
            }
        }
    }
}
