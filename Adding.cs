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

namespace Домашняя_видеотека
{
    public partial class Adding : Form
    {
        public Adding( )
        {
            InitializeComponent();
            
        }


        public Form1 f1;

        int Фильм_id;
       public int id;
       public int refresh = 0;

        private void Adding_Load(object sender, EventArgs e)
        {
            
            f1 = new Form1();
            
        }

        public void fillGenre()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Жанр", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.Fill(ds, "Жанр");
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Название";
            comboBox1.ValueMember = "Жанр_id";
            con.Close();
        }

        public void fillDirector()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Режиссер", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.Fill(ds, "Режиссер");
            comboBox2.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = "Имя";
            comboBox2.ValueMember = "Режиссер_id";
            
            con.Close();

        }

        public void fillCompany()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Кинокомпания", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.Fill(ds, "Кинокомпания");
            comboBox3.DataSource = ds.Tables[0];
            comboBox3.DisplayMember = "Название";
            comboBox3.ValueMember = "Кинокомпания_id";
            con.Close();
        }

        private void getFilmID()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            SqlCommand command = new SqlCommand("select Фильм_id from Фильм", con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Фильм_id = dr.GetInt32(0) + 1;
            }
            con.Close();
        }


        public void button1_Click(object sender, EventArgs e)
        {
            getFilmID();
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            SqlDataReader filmReader;
            con.Open();

            SqlCommand film = new SqlCommand("insert into Фильм (Фильм_id, Название,Год,Страна,Режиссер_id,Кинокомпания_id,Жанр_id,Продолжительность,Рейтинг) values('" + Фильм_id + "','"
                + textBox1.Text + "','"
                + Convert.ToInt32(textBox2.Text) + "','"
                + textBox3.Text + "','"
                + Convert.ToInt32(comboBox2.SelectedValue) + "','"
                + Convert.ToInt32(comboBox3.SelectedValue) + "','"
                + Convert.ToInt32(comboBox1.SelectedValue) + "','"
                + Convert.ToInt32(textBox6.Text) + "','"
                + numericUpDown1.Value + "')", con);
            filmReader = film.ExecuteReader();
            filmReader.Close();
            con.Close();
            this.Close();
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            getFilmID();
            
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            SqlDataReader filmReader;
            con.Open();
            SqlCommand film = new SqlCommand("update Фильм set Название='" + textBox1.Text +
                "',Год='" + Convert.ToInt32(textBox2.Text) +
                "',Страна='" + textBox3.Text +
                "',Режиссер_id='" + Convert.ToInt32(comboBox2.SelectedValue) +
                "',Кинокомпания_id='" + Convert.ToInt32(comboBox3.SelectedValue) +
                "',Жанр_id='" + Convert.ToInt32(comboBox1.SelectedValue) +
                "',Продолжительность='" + Convert.ToInt32(textBox6.Text) +
                "',Рейтинг='" + numericUpDown1.Value + "'where Фильм_id='" + id + "'", con);
            filmReader = film.ExecuteReader();
            filmReader.Close();
            con.Close();
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddingDirector DirectorForm = new AddingDirector();
            DirectorForm.ShowDialog();
            fillDirector();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddingCompany CompanyForm = new AddingCompany();
            CompanyForm.ShowDialog();
            fillCompany();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fillCompany();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fillDirector();
        }

        private void Adding_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.fillDataGridView();
        }

        private void Adding_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.fillDataGridView();
        }







    }
}
