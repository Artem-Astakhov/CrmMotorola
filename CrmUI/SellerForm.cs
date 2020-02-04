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
    public partial class SellerForm : Form
    {
        CrmContext db;
        public Seller Seller { get; set; }
        public SellerForm()
        {
            InitializeComponent();
            Seller = new Seller();
        }

        public SellerForm(Seller seller):this()
        {
            Seller = seller ?? new Seller();
            textBox1.Text = Seller.Name;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = Seller ?? new Seller();

            s.Name = textBox1.Text;

            Close();
        }
    }
}
