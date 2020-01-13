using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;


namespace BankingCRM
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        SqlConnection connection = new SqlConnection(BankingCRM.Properties.Settings.Default.Database1ConnectionString);
        int selectedCustomerId = 1;
        public Form1()
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext(connection);

            var CustomerQuery =
                from cust in dataContext.GetTable<Customer>()
                where cust.CustomerId == selectedCustomerId
                select cust;


            InitializeComponent();


            foreach (var customer in CustomerQuery)
            {
               listBox4.Items.Add(customer.FirstName);
               listBox4.Items.Add(customer.LastName);
            }

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

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
