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
    public partial class Catalog<T> : Form
        where T: class
    {
        CrmContext db;
        DbSet<T> set;
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Seller Seller { get; set; }
        public Catalog(DbSet<T> set, CrmContext db) 
        {

            InitializeComponent();
            
            this.set = set;
            this.db = db;
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (typeof(T) == typeof(Product))
            {
                
                var formProduct = new ProductForm();
                if (formProduct.ShowDialog() == DialogResult.OK)
                {
                    db.Products.Add(formProduct.Product);
                    db.SaveChanges();
                                       
                }
                
            }
            else if (typeof(T) == typeof(Customer))
            {
                var formCustomer = new CustomerForm();
                if (formCustomer.ShowDialog() == DialogResult.OK)
                {
                    db.Customers.Add(formCustomer.Customer);
                    db.SaveChanges();
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var formSeller = new SellerForm();
                if (formSeller.ShowDialog() == DialogResult.OK)
                {
                    db.Sellers.Add(formSeller.Seller);
                    db.SaveChanges();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int index = dataGridView.SelectedRows[0].Index;
                var id = dataGridView.SelectedRows[0].Cells[0].Value;
                //int id = 0;
                //bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);

                if(typeof(T) == typeof(Product))
                {
                    var product = set.Find(id) as Product;
                    var form = new ProductForm(product);
                    
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        db.SaveChanges();
                        dataGridView.Refresh();
                    }

                }
                else if (typeof(T) == typeof(Customer))
                {
                    var customer = db.Customers.Find(id);
                    var form = new CustomerForm(customer);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer = form.Customer;
                        db.SaveChanges();
                        dataGridView.Refresh();
                    }
                }
                else if (typeof(T) == typeof(Seller))
                {
                    var seller = db.Sellers.Find(id);
                    var form = new SellerForm(seller);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        db.SaveChanges();
                        dataGridView.Refresh();
                    }
                }
            }
        }

        
    }
}
