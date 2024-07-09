# SetupWithSQLDB
 Create Setup File With attaching SQL Database .mdf

## I created a Basic CRUD in Visual Studio 2022

### Output:
![image](https://github.com/Milave-kun/SetupWithSQLDB/assets/125982535/02aee95a-e80b-4759-a7c2-84f20f3ad6ac)

### Codes:
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    namespace SetupWithSQLDB
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData(); // Load data when the form is initialized
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // Load data when the form loads
        }

        private void LoadData()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\johnd\\source\\Repos\\SetupWithSQLDB\\SetupWithSQLDB\\Database1.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserTable", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetNextId()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\johnd\\source\\Repos\\SetupWithSQLDB\\SetupWithSQLDB\\Database1.mdf;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(MIN(ID) + 1, 1) FROM UserTable WHERE (ID + 1) NOT IN (SELECT ID FROM UserTable)", con);
                    int nextId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    return nextId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while getting the next ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Validation for empty text boxes
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAge.Text))
            {
                MessageBox.Show("Age cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure Age is a valid number
            if (!double.TryParse(txtAge.Text, out double age))
            {
                MessageBox.Show("Age must be a valid number", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nextId = GetNextId();
            if (nextId == -1)
                return;

            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\johnd\\source\\Repos\\SetupWithSQLDB\\SetupWithSQLDB\\Database1.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserTable (ID, Name, Age) VALUES (@id, @name, @age)", con);
                cmd.Parameters.AddWithValue("@id", nextId);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Saved");
                LoadData(); // Reload data after insertion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the ID of the selected row
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\johnd\\source\\Repos\\SetupWithSQLDB\\SetupWithSQLDB\\Database1.mdf;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM UserTable WHERE ID = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    con.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully Deleted");
                        LoadData(); // Reload data after deletion
                    }
                    else
                    {
                        MessageBox.Show("No record found with the specified ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited cell is not in the new row
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the edited cell and its value
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["ID"].Value);
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                object newValue = row.Cells[e.ColumnIndex].Value;

                // Check for null values
                if (newValue == null || newValue == DBNull.Value)
                {
                    MessageBox.Show("The cell value cannot be null", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\johnd\\source\\Repos\\SetupWithSQLDB\\SetupWithSQLDB\\Database1.mdf;Integrated Security=True"))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand($"UPDATE UserTable SET {columnName} = @value WHERE ID = @id", con);
                        cmd.Parameters.AddWithValue("@value", newValue);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Successfully Updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // Check for null values before setting the textboxes
                txtName.Text = row.Cells["Name"].Value != null ? row.Cells["Name"].Value.ToString() : string.Empty;
                txtAge.Text = row.Cells["Age"].Value != null ? row.Cells["Age"].Value.ToString() : string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validation for empty text boxes
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAge.Text))
            {
                MessageBox.Show("Age cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure Age is a valid number
            if (!double.TryParse(txtAge.Text, out double age))
            {
                MessageBox.Show("Age must be a valid number", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the ID of the selected row
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\johnd\\source\\Repos\\SetupWithSQLDB\\SetupWithSQLDB\\Database1.mdf;Integrated Security=True"))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE UserTable SET Name = @name, Age = @age WHERE ID = @id", con);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Successfully Updated");
                    LoadData(); // Reload data after update
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
