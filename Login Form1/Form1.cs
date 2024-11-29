using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace Login_Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=GEORGEACER\SQLEXPRESS;Initial Catalog=loginpage1;Integrated Security=True;Trust Server Certificate=True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_Username.Clear();
            txt_Password.Clear();

            txt_Username.Focus();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, password;
            username = txt_Username.Text;
            password = txt_Password.Text;

            try
            {
                String querry = "SELECT * FROM login WHERE username ='"+txt_Username.Text+"'AND password = '"+txt_Password.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry,conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txt_Username.Text;
                    password = txt_Password.Text;

                    //Page that needed to be load next
                    Menuform form2 = new Menuform();
                    form2.Show();
                    this.Hide();
                }
            }
            catch
            {

                MessageBox.Show("Accessed Denied", "Invalid Details", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txt_Username.Clear();
                txt_Password.Clear();

                //to focus username
                txt_Username.Focus();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
