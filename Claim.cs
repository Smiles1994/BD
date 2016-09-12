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
    public partial class Claim : Form
    {
        public Claim()
        {
            InitializeComponent();
        }

        int Заявка_id;
   
        string date;
        Form1 f1 = new Form1();
        

        private void Claim_Load(object sender, EventArgs e)
        {
            fillFilm();
            fillUser();
        }

        public void getClaimID()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            SqlCommand command = new SqlCommand("select Заявка_id from Заявка", con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Заявка_id = dr.GetInt32(0) + 1;
            }
            con.Close();
        }

        public void fillUser()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Зритель", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.Fill(ds, "Зритель");
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Имя";
            comboBox1.ValueMember = "Зритель_id";
            con.Close();
        }

        public void fillFilm()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Фильм", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.Fill(ds, "Фильм");
            comboBox2.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = "Название";
            comboBox2.ValueMember = "Фильм_id";
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getClaimID();
            date = DateTime.Now.Month.ToString() +"."+ DateTime.Now.Day.ToString() +"."+ DateTime.Now.Year.ToString();
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            SqlDataReader claimReader;
            con.Open();
            SqlCommand claim = new SqlCommand("insert into Заявка (Заявка_id, Зритель_id,Фильм_id,Дата_подачи_заявки) values('" + Заявка_id + "','"
                + comboBox1.SelectedValue + "','"
                + comboBox2.SelectedValue + "','"
                + date + "')", con);
            claimReader = claim.ExecuteReader();
            claimReader.Close();
            con.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdingUser f2 = new AdingUser();
            f2.ShowDialog();
            fillUser();
        }

    }
}
