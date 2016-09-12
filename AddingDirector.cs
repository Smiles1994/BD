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
    public partial class AddingDirector : Form
    {
        public AddingDirector()
        {
            InitializeComponent();
        }
        Adding adding = new Adding();

        int Режиссер_id;
        string date;

        private void getDirectorID()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            SqlCommand command = new SqlCommand("select Режиссер_id from Режиссер", con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Режиссер_id = dr.GetInt32(0) + 1;
            }
            con.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            getDirectorID();
            SqlDataReader directorReader;
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            con.Open();

            if (textBox1.Text != "")
            {
                if (textBox2.Text == "")
                {
                    date = dateTimePicker1.Value.Month.ToString() + "." + dateTimePicker1.Value.Day.ToString() + "." + dateTimePicker1.Value.Year.ToString();
                    SqlCommand director = new SqlCommand("insert into Режиссер (Режиссер_id, Имя,Дата_рождения,Рост) values('" + Режиссер_id +
                        "','" + textBox1.Text +
                        "','" + date +
                        "','" + null +
                        "')", con);
                    directorReader = director.ExecuteReader();
                    directorReader.Close();
                    this.Close();
                }
                else
                {
                    date = dateTimePicker1.Value.Month.ToString() +"."+ dateTimePicker1.Value.Day.ToString() +"."+ dateTimePicker1.Value.Year.ToString();
                    SqlCommand director = new SqlCommand("insert into Режиссер (Режиссер_id, Имя,Дата_рождения,Рост) values('" + Режиссер_id +
                        "','" + textBox1.Text +
                        "','" + date +
                        "','" + Convert.ToInt32(textBox2.Text) +
                        "')", con);
                    directorReader = director.ExecuteReader();
                    directorReader.Close();
                    this.Close();
                }
            }
            else { MessageBox.Show("Введите имя режиссера"); }
            

            
        }
    }
}
