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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillGenre();
            fillActor();
            fillCompanies();
            fillDirector();
            fillUser();
            fillClaim();
            fillDataGridView();

            deleteButt.FlatStyle = FlatStyle.Popup;
            deleteButt.CellTemplate.Style.BackColor = Color.Honeydew;
            deleteButt.HeaderText = "Редактирование";
            deleteButt.Name = "Button";
            deleteButt.UseColumnTextForButtonValue = true;
            deleteButt.Text = "Удалить";
            deleteButt.DisplayIndex = 10;

            changeButt.FlatStyle = FlatStyle.Popup;
            changeButt.CellTemplate.Style.BackColor = Color.Honeydew;
            changeButt.HeaderText = "Редактирование";
            changeButt.Name = "Button";
            changeButt.UseColumnTextForButtonValue = true;
            changeButt.Text = "Изменить";
            changeButt.DisplayIndex = 9;

            dataGridView1.Columns.Add(deleteButt);
            dataGridView1.Columns.Add(changeButt);
            dataGridView1.Columns["Фильм_id"].Visible = false;

        }

        SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
        DataGridViewButtonColumn deleteButt = new DataGridViewButtonColumn();
        DataGridViewButtonColumn changeButt = new DataGridViewButtonColumn();
        public int currentID,
            filmCol,
            directorCol,
            actorCol,
            userCol,
            companyCol;


        public void fillDataGridView()
        {
            changeButt.Visible = true;
            deleteButt.Visible = true;
            SqlDataAdapter da = new SqlDataAdapter
                (
                "SELECT Фильм.Фильм_id, Фильм.Название, Фильм.Год, Фильм.Страна, Режиссер.Имя AS Режиссер, Кинокомпания.Название AS Кинокомпания, Жанр.Название AS Жанр, Фильм.Продолжительность, Фильм.Рейтинг FROM Жанр INNER JOIN (Кинокомпания INNER JOIN (Режиссер INNER JOIN Фильм ON Режиссер.Режиссер_id = Фильм.Режиссер_id) ON Кинокомпания.Кинокомпания_id = Фильм.Кинокомпания_id) ON Жанр.Жанр_id = Фильм.Жанр_id;",con
                );
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds,"Фильм");
            
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["Фильм_id"].Visible = false;
            changeButt.DisplayIndex = 10;
            deleteButt.DisplayIndex = 10;

            for (int i = 0; i < dataGridView1.Rows.Count+1; i++)
            {
                filmCol = i;
            }
            label12.Text = filmCol.ToString();
            label13.Text = directorCol.ToString();
            label14.Text = actorCol.ToString();
            label15.Text = userCol.ToString();
            label16.Text = companyCol.ToString();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Adding f2 = new Adding();

            f2.button6.Visible = false;
            f2.button1.Enabled = true;
            f2.ShowDialog();
            this.fillDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fillDataGridView();
            textBox1.Text = "";
            textBox4.Text = "";
        }



        private void fillActor()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Актер", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Актер");

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["Актер_id"].Visible = false;
            changeButt.Visible = false;
            deleteButt.Visible = false;
            for (int i = 0; i < dataGridView1.Rows.Count+1; i++)
            {
                actorCol = i;
            }
        }

        private void fillDirector()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Режиссер", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Режиссер");

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["Режиссер_id"].Visible = false;
            changeButt.Visible = false;
            deleteButt.Visible = false;

            for (int i = 0; i < dataGridView1.Rows.Count+1; i++)
            {
                directorCol = i;
            }
        }

        private void fillCompanies()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Кинокомпания", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Кинокомпания");

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["Кинокомпания_id"].Visible = false;
            changeButt.Visible = false;
            deleteButt.Visible = false;

            for (int i = 0; i < dataGridView1.Rows.Count+1; i++)
            {
                companyCol = i;
            }
        }
        private void fillUser()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Зритель", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Зритель");

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["Зритель_id"].Visible = false;
            changeButt.Visible = false;
            deleteButt.Visible = false;

            for (int i = 0; i < dataGridView1.Rows.Count+1; i++)
            {
                userCol = i;
            }
        }

        private void FillGenre()
        {
            SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Жанр", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.Fill(ds, "Жанр");
            comboBox2.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = "Название";
            comboBox2.ValueMember = "Жанр_id";
            con.Close();
        }
        private void fillClaim()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Заявка.Заявка_id, Заявка.Зритель_id, Заявка.Фильм_id, Зритель.Имя, Зритель.Дата_рождения, Зритель.Телефон, Фильм.Название, Заявка.Дата_подачи_заявки FROM (Зритель INNER JOIN Заявка ON Зритель.Зритель_id = Заявка.Зритель_id) INNER JOIN Фильм ON Заявка.Фильм_id = Фильм.Фильм_id;" , con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Заявка");

            
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["Заявка_id"].Visible = false;
            dataGridView1.Columns["Фильм_id"].Visible = false;
            dataGridView1.Columns["Зритель_id"].Visible = false;
            changeButt.Visible = false;
            deleteButt.Visible = false;
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Фильм.Фильм_id, Фильм.Название, Фильм.Год, Фильм.Страна, Режиссер.Имя AS Режиссер, Кинокомпания.Название AS Кинокомпания, Жанр.Название AS Жанр, Фильм.Продолжительность, Фильм.Рейтинг FROM Жанр INNER JOIN (Кинокомпания INNER JOIN (Режиссер INNER JOIN Фильм ON Режиссер.Режиссер_id = Фильм.Режиссер_id) ON Кинокомпания.Кинокомпания_id = Фильм.Кинокомпания_id) ON Жанр.Жанр_id = Фильм.Жанр_id WHERE Жанр.Название='" + comboBox2.Text + "'", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Фильм");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Фильм.Фильм_id, Фильм.Название, Фильм.Год, Фильм.Страна, Режиссер.Имя AS Режиссер, Кинокомпания.Название AS Кинокомпания, Жанр.Название AS Жанр, Фильм.Продолжительность, Фильм.Рейтинг FROM Жанр INNER JOIN (Кинокомпания INNER JOIN (Режиссер INNER JOIN Фильм ON Режиссер.Режиссер_id = Фильм.Режиссер_id) ON Кинокомпания.Кинокомпания_id = Фильм.Кинокомпания_id) ON Жанр.Жанр_id = Фильм.Жанр_id WHERE Фильм.Год Between '" + Convert.ToInt32(textBox2.Text) + "' And '" + Convert.ToInt32(textBox3.Text) + "'", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Фильм");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Фильм.Фильм_id, Фильм.Название, Фильм.Год, Фильм.Страна, Режиссер.Имя AS Режиссер, Кинокомпания.Название AS Кинокомпания, Жанр.Название AS Жанр, Фильм.Продолжительность, Фильм.Рейтинг FROM Жанр INNER JOIN (Кинокомпания INNER JOIN (Режиссер INNER JOIN Фильм ON Режиссер.Режиссер_id = Фильм.Режиссер_id) ON Кинокомпания.Кинокомпания_id = Фильм.Кинокомпания_id) ON Жанр.Жанр_id = Фильм.Жанр_id WHERE Фильм.Рейтинг= '" + Convert.ToInt32(textBox5.Text) + "'", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Фильм");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
               
                SqlConnection con = new SqlConnection("Data Source=KOMP\\SMILES;Initial Catalog=Фильмы;Integrated Security=True");
                SqlCommand delete = new SqlCommand("Delete from Фильм where Фильм_id = @ID", con);
                delete.Parameters.AddWithValue("@ID", dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                con.Open();
                delete.ExecuteNonQuery();
                con.Close();
                fillDataGridView();
            }
            if (e.ColumnIndex == 1)
            {
                
                Adding f2 = new Adding();
                f2.fillGenre();
                f2.fillDirector();
                f2.fillCompany();
                f2.id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                f2.textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                f2.textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                f2.textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                f2.comboBox2.SelectedIndex = f2.comboBox2.FindString(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                f2.comboBox3.SelectedIndex = f2.comboBox3.FindString(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                f2.comboBox1.SelectedIndex = f2.comboBox1.FindString(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                f2.textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                

                f2.numericUpDown1.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
   
                f2.button6.Visible = true;
                f2.button1.Enabled = false;
                f2.ShowDialog();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fillDirector();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fillActor();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fillUser();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            fillClaim();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Claim cliam1 = new Claim();
            cliam1.ShowDialog();
            fillClaim();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Фильм.Фильм_id, Фильм.Название, Фильм.Год, Фильм.Страна, Режиссер.Имя AS Режиссер, Кинокомпания.Название AS Кинокомпания, Жанр.Название AS Жанр, Фильм.Продолжительность, Фильм.Рейтинг FROM Жанр INNER JOIN (Кинокомпания INNER JOIN (Режиссер INNER JOIN Фильм ON Режиссер.Режиссер_id = Фильм.Режиссер_id) ON Кинокомпания.Кинокомпания_id = Фильм.Кинокомпания_id) ON Жанр.Жанр_id = Фильм.Жанр_id WHERE Фильм.Название LIKE '%" + textBox1.Text + "%'", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Фильм");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Фильм.Фильм_id, Фильм.Название, Фильм.Год, Фильм.Страна, Режиссер.Имя AS Режиссер, Кинокомпания.Название AS Кинокомпания, Жанр.Название AS Жанр, Фильм.Продолжительность, Фильм.Рейтинг FROM Жанр INNER JOIN (Кинокомпания INNER JOIN (Режиссер INNER JOIN Фильм ON Режиссер.Режиссер_id = Фильм.Режиссер_id) ON Кинокомпания.Кинокомпания_id = Фильм.Кинокомпания_id) ON Жанр.Жанр_id = Фильм.Жанр_id WHERE Режиссер.Имя Like '%" + textBox4.Text + "%'", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Фильм");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fillCompanies();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Актер.Имя AS [Имя актера], Фильм.Название AS [Название фильма] FROM Актер INNER JOIN (Фильм_Актер INNER JOIN Фильм ON Фильм_Актер.Фильм_id = Фильм.Фильм_id) ON Актер.Актер_id = Фильм_Актер.Актер_id;", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Фильм_Актер");
            dataGridView1.DataSource = ds.Tables[0];
            changeButt.Visible = false;
            deleteButt.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT Фильм.Название, Count(Заявка.Заявка_id) AS [Количетсво заявок] FROM Заявка INNER JOIN Фильм ON Заявка.Фильм_id = Фильм.Фильм_id GROUP BY Фильм.Название ORDER BY Count(Заявка.Заявка_id) DESC;", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Заявка");
            dataGridView1.DataSource = ds.Tables[0];
            changeButt.Visible = false;
            deleteButt.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {


            SqlDataAdapter da = new SqlDataAdapter("SELECT Фильм.Название, Фильм.Год, Фильм.Страна, Фильм.Продолжительность FROM Фильм ORDER BY Фильм.Продолжительность DESC;", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Фильм");
            dataGridView1.DataSource = ds.Tables[0];
            changeButt.Visible = false;
            deleteButt.Visible = false;

        }

        private void button15_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT Жанр.Название AS [Название жанра], Count(Заявка.Заявка_id) AS [Количество заявок] FROM Жанр INNER JOIN (Фильм INNER JOIN Заявка ON Фильм.Фильм_id = Заявка.Фильм_id) ON Жанр.Жанр_id = Фильм.Жанр_id GROUP BY Жанр.Название ORDER BY Count(Заявка.Заявка_id) DESC;", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Заявка");
            dataGridView1.DataSource = ds.Tables[0];
            changeButt.Visible = false;
            deleteButt.Visible = false;

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
