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
    public partial class AddingCompany : Form
    {
        public AddingCompany()
        {
            InitializeComponent();
        }

        Adding adding = new Adding();

        int Кинокомпания_id;

        private void getCompanyID()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            SqlCommand command = new SqlCommand("select Кинокомпания_id from Кинокомпания", con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Кинокомпания_id = dr.GetInt32(0) + 1;
            }
            con.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            getCompanyID();
            AddCompany();
        }

        public void AddCompany()
        {
            SqlDataReader companyReader;
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            con.Open();

            if (textBox1.Text != "")
            {
                if (textBox2.Text == "" && textBox3.Text == "")
                {
                    SqlCommand company = new SqlCommand("insert into Кинокомпания (Кинокомпания_id, Название,Год_основания,Расположение) values('" + Кинокомпания_id +
                        "','" + textBox1.Text +
                        "','" + null +
                        "','" + null +
                        "')", con);
                    companyReader = company.ExecuteReader();
                    companyReader.Close();
                    
                    this.Close();
                }
                else if (textBox2.Text != "" && textBox3.Text == "")
                {
                    if (Convert.ToInt32(textBox2.Text) > 1900 && Convert.ToInt32(textBox2.Text) < 2014)
                    {
                        SqlCommand company = new SqlCommand("insert into Кинокомпания (Кинокомпания_id, Название,Год_основания,Расположение) values('" + Кинокомпания_id +
                        "','" + textBox1.Text +
                        "','" + Convert.ToInt32(textBox2.Text) +
                        "','" + null +
                        "')", con);
                        companyReader = company.ExecuteReader();
                        companyReader.Close();
                        
                        this.Close();
                    }
                    else { MessageBox.Show("Год основания кинокомпаниии должен быть не меньше  1900 и не больше 2014"); }
                }
                else if (textBox2.Text == "" && textBox3.Text != "")
                {
                    SqlCommand company = new SqlCommand("insert into Кинокомпания (Кинокомпания_id, Название,Год_основания,Расположение) values('" + Кинокомпания_id +
                        "','" + textBox1.Text +
                        "','" + null +
                        "','" + textBox3.Text +
                        "')", con);
                    companyReader = company.ExecuteReader();
                    companyReader.Close();
                    this.Close();
                }
                else
                {

                    
                    if (Convert.ToInt32(textBox2.Text) > 1900 && Convert.ToInt32(textBox2.Text) < 2014)
                    {
                        SqlCommand company = new SqlCommand("insert into Кинокомпания (Кинокомпания_id, Название,Год_основания,Расположение) values('" + Кинокомпания_id +
                            "','" + textBox1.Text +
                            "','" + Convert.ToInt32(textBox2.Text) +
                            "','" + textBox3.Text +
                            "')", con);
                        companyReader = company.ExecuteReader();
                        companyReader.Close();
                        this.Close();
                    }
                    else { MessageBox.Show("Год основания кинокомпаниии должен быть не меньше  1900 и не больше 2014"); }
                }
            }
            else { MessageBox.Show("Введите название компании"); }
            
        }

    }
}
