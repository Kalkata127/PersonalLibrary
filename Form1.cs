using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySqlConnector;
using System.Linq;

namespace PersonalLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //Бутон за Добавяне на запис
        private void button1_Click(object sender, EventArgs e)
        {
            //Свързване с базата данни
            string constring = "Server=localhost; database=personallibrary; uid=root; password=;";
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            //На база от полетата за входни данни се прави заявка за вкарване на данните в базата данни
            MySqlCommand cmd = new MySqlCommand("insert into userlib values (@ID,@Title,@Author,@Pages)", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Author", textBox3.Text);
            cmd.Parameters.AddWithValue("@Pages", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            
            //Затваряне на връзката с базата данни
            connection.Close();
            MessageBox.Show("Successfully Saved");
           
        }
        //Бутон за актуализиране на данни
        private void button2_Click(object sender, EventArgs e)
        {
            //Връзка с базата данни
            string constring = "Server=localhost; database=personallibrary; uid=root; password=;";
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            //На база от полетата за входни данни се прави заявка за актуализиране на данните в базата данни
            MySqlCommand cmd = new MySqlCommand("Update userlib set Title=@Title, Author=@Author, Pages=@Pages where ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Author", textBox3.Text);
            cmd.Parameters.AddWithValue("@Pages", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();

            //Затваряне на връзката с базата данни
            connection.Close();
            MessageBox.Show("Successfully Updated");

        }
        //Бутон за изтриване на данни от базата данни
        private void button3_Click(object sender, EventArgs e)
        {
            //Връзка с базата данни
            string constring = "Server=localhost; database=personallibrary; uid=root; password=;";
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            //На база от полетата за входни данни се прави заявка за изтриване на данните в базата данни
            MySqlCommand cmd = new MySqlCommand("Delete from userlib where ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();

            //Затваряне на връзката с базата данни
            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }
        //Бутон за търсене на данни от базата данни
        private void button4_Click(object sender, EventArgs e)
        {
            //Връзка с базата данни
            string constring = "Server=localhost; database=personallibrary; uid=root; password=;";
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            //Заявка за намиране на запис, чрез неговото ID
            MySqlCommand cmd = new MySqlCommand("Select * from userlib where ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

            //Запълва полето за изобразяване на данните от базата данни
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            dataGridView1.DataSource = datatable;

        }
          //Метод за изписване на даниите във DataGridView обекта
        private void list()
        {
            //Връзка с базата данни
            string constring = "Server=localhost; database=personallibrary; uid=root; password=;";
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            //Заявка за избиране да данните
            string query = "Select * From userlib";

            //Адаптер за базата дании и връзката със заявката
            MySqlDataAdapter da = new MySqlDataAdapter(query,connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //Запълва DataGridView обекта с данните от базата данни
            dataGridView1.DataSource= dt;

            //Затваряне на връзката с базата данни
            connection.Close();
            
        }

        //Метод за зареждане на данните
        private void Form1_Load(object sender, EventArgs e)
        {
            list();
        }
    }
}