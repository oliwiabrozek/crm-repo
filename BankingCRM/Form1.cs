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

            var AddressQuery = 
                from cust in dataContext.GetTable<Customer>()
                join addr in dataContext.GetTable<Address>()
                on cust.AddressId equals addr.AddressId
                where cust.CustomerId == selectedCustomerId
                select addr;

            var TransactionQuery = 
                from cust in dataContext.GetTable<Customer>()
                join trans in dataContext.GetTable<Transaction>()
                on cust.AccountNumber equals trans.AccountNumber
                where cust.CustomerId == selectedCustomerId
                select trans;


            InitializeComponent();


            foreach (var customer in CustomerQuery)
            {
               listBox4.Items.Add(customer.FirstName);
               listBox4.Items.Add(customer.LastName);
               //listBox4.Items.Add(customer.AccountNumber);
            }

            foreach(var address in AddressQuery)
            {
                listBox4.Items.Add(address.Street);
                listBox4.Items.Add(address.City);
                listBox4.Items.Add(address.Country);
            }

            foreach (var transaction in TransactionQuery)
            {
                
                if(transaction.TransactionTypeId == 1)
                {
                    listBox2.Items.Add("+ " + transaction.Amount);
                }
                if (transaction.TransactionTypeId == 2)
                {
                    listBox2.Items.Add("- " + transaction.Amount);
                }
            

            }

            listBox3.Items.Add("Debit Card");
            listBox3.Items.Add("Loan");

            listBox1.Items.Add("Food");
            listBox1.Items.Add("Clothing");
            listBox1.Items.Add("Hausing");
            listBox1.Items.Add("Transport");
            listBox1.Items.Add("Recreation and culture");
            






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
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);
            BankProduct bankProduct = new BankProduct();
            bankProduct.Name = textBox5.Text;

            dc.BankProducts.InsertOnSubmit(bankProduct);
            dc.SubmitChanges();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);

            BankProduct bankProduct
                = dc.BankProducts.FirstOrDefault(bp => bp.Name.Equals(listBox2.SelectedValue));

            bankProduct.Name = textBox5.Text;

            dc.SubmitChanges();

         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connection);

            
            BankProduct bankProduct = dc.BankProducts.FirstOrDefault(bp => bp.Name.Equals(listBox2.SelectedValue));

            dc.BankProducts.DeleteOnSubmit(bankProduct);

            dc.SubmitChanges();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
