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
    public partial class AdingUser : Form
    {
        public AdingUser()
        {
            InitializeComponent();
        }

        Form1 f1 = new Form1();
        int Зритель_id;
        string date;

        private void getUserID()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            SqlCommand command = new SqlCommand("select Зритель_id from Зритель", con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Зритель_id = dr.GetInt32(0) + 1;
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getUserID();
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            SqlDataReader userReader;
            con.Open();
            date = dateTimePicker1.Value.Month.ToString() + "." + dateTimePicker1.Value.Day.ToString() + "." + dateTimePicker1.Value.Year.ToString();
            SqlCommand user = new SqlCommand("insert into Зритель (Зритель_id, Имя,Дата_рождения,Адрес,Телефон) values('" + Зритель_id + "','"
                + textBox1.Text + "','"
                + date + "','"
                + textBox2.Text + "','"
                + textBox3.Text + "')", con);
            userReader = user.ExecuteReader();
            userReader.Close();
            con.Close();
            this.Close();
        }
    }
}
