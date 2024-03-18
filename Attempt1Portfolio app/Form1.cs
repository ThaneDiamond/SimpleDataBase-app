using Attempt1Portfolio_app.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attempt1Portfolio_app
{
    public partial class FormMain : Form
    {
        DAL dAL = new DAL();//database access layer
        DataSet ds = new DataSet();

        string tableName = "Sales.Orders";

        private void refreshTable()
        {
            ds = dAL.loadTable(tableName);
            dgvMain.DataSource = ds.Tables[0];
        }
        public FormMain()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshTable();                  
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            dAL.Insert(tbCustomerID.Text,tbSalesPID.Text,dtpOrderDate.Value,tableName);
            refreshTable();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dAL.Delete(tbCustomerID.Text, tableName);
            refreshTable();
        }

        private void dgvMain_Click(object sender, EventArgs e)
        {
            tbCustomerID.Text = this.dgvMain.CurrentRow.Cells[0].Value.ToString();
            tbSalesPID.Text = this.dgvMain.CurrentRow.Cells[1].Value.ToString();
            dtpOrderDate.Text = this.dgvMain.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
