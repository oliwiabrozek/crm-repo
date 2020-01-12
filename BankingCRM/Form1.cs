using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BankingCRM
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(BankingCRM.Properties.Settings.Default.Database1ConnectionString);

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.Clear();
        }

        private void toolStripComboBox1_DropDown(object sender, EventArgs e)
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext(connection);

            var SelectQuery =
                from cust in dataContext.GetTable<Customer>()
                select cust;

            foreach (var customer in SelectQuery)
            {
                toolStripComboBox1.Items.Add(customer.FirstName + " " + customer.LastName);
            }
        }
    }
}
