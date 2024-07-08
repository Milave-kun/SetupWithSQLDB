using System.Data;
using System.Data.SqlClient;

namespace SetupWithSQLDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\johnd\\source\\Repos\\SetupWithSQLDB\\SetupWithSQLDB\\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into UserTable values (@id, @name, @age)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(txtAge.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\johnd\\source\\Repos\\SetupWithSQLDB\\SetupWithSQLDB\\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from UserTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);       
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
