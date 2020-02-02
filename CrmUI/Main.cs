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
        Cart cart;
        Customer customer;
        CashDesk cashDesk;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();

            cart = new Cart(customer);
            cashDesk = new CashDesk(1, db.Sellers.FirstOrDefault(),db);
            cashDesk.IsModel = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {            
            listBox1.Items.AddRange(db.Products.ToArray());
            listBox2.Items.AddRange(cart.GetAll().ToArray());
        }
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products,db);
            catalogProduct.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Seller>(db.Sellers,db);
            catalogProduct.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Customer>(db.Customers, db);
            catalogProduct.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Check>(db.Checks, db);
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

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listBox1.SelectedItem is Product product)
            {
                cart.Add(product);
                listBox2.Items.Add(product);
                label1.Text = "Сумма: " + cart.Price;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new Login();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                var tempCustomer = db.Customers.FirstOrDefault(c => c.Name.Equals(form.Customer.Name));
                if (tempCustomer != null)
                {
                    customer = tempCustomer;
                }
                else
                {
                    db.Customers.Add(form.Customer);
                    db.SaveChanges();
                    customer = form.Customer;
                }

                cart.Customer = customer;
            }

            linkLabel1.Text = $"{customer.Name}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (customer != null)
            {
                cashDesk.Enqueue(cart);
                cashDesk.Dequeue();                
            }
            else
            {
                MessageBox.Show("Login", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cart = new Cart(customer);
            listBox2.Items.Clear();
            label1.Text = "0";
        }
    }
}
