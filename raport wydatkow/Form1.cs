
using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace raport_wydatkow
{
    public partial class Form1 : Form
    {
        private string data;
        private string miesiac;
        private string coZaplacone;
        private double kwota = 0;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Miesiac
        {
            get { return miesiac; }
            set { miesiac = value; }
        }
        public string CoZaplacone
        {
            get { return coZaplacone; }
            set { coZaplacone = value; }
        }
        public double Kwota
        {
            get { return kwota; }
            set { kwota = value; }
        }
        ObslugaBazyDanych OB = new ObslugaBazyDanych();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//przycisk dodaj
        {
            bool czyZduplikowanezakupy, czyZduplikowaneoplaty;


            Miesiac = string.Concat(dateTimePicker1.Text[3], dateTimePicker1.Text[4]);
            Data = dateTimePicker1.Text;

            double bufor = 0;
            if (double.TryParse(textBox1.Text, out bufor))
            {
                Kwota = bufor;

                CoZaplacone = textBox2.Text;
                if (CoZaplacone == "")
                {
                    MessageBox.Show("Niepoprawny opis", "Błąd");
                }
                else
                {
                    if (radioButton1.Checked == true)//ZAKUPY
                    {
                        OB.sprawdzenieCzyzduplikowaneZakupy(Kwota.ToString(), CoZaplacone, Data);
                        //if (czyZduplikowanezakupy = ObslugaBazy.sprawdzenieCzyzduplikowaneZakupy(data, coZaplacone, kwota.ToString()))
                        //{

                        //}
                    }
                    if (radioButton2.Checked == true)//OPŁATY
                    {

                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)//przycisk zamknij
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)//przy włączeniu programu
        {
            WyswietlaDane();
            OB.sprawdzenieCzyzduplikowaneZakupy(Kwota.ToString(), CoZaplacone, Data);
        }


        //METODA WYŚWIETLANIA TABELI W ListView
        //////////////////////////////////////////////////////////////////////////////////
        public void WyswietlaDane()
        {

            //textBox19.Text = OB.sprawdzenieCzyzduplikowaneZakupy("28.04.2021");

            SqlConnection con = new SqlConnection(OB.KonfiguracjaBazy());
            con.Open();

            SqlCommand cmd = new SqlCommand("select data, cokupione, kwota from zakupy", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            da.Fill(ds, "Database1");
            con.Close();

            listView1.Items.Clear();

            //listView1.Columns.Add("Numer", 45);
            listView1.Columns.Add("Data", 70);
            listView1.Columns.Add("Nazwa", 240);
            listView1.Columns.Add("Kwota", 58);
            listView1.View = View.Details;

            dt = ds.Tables["Database1"];

            //int NumerWiersza = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //listView1.Items.Add(NumerWiersza.ToString());
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                //NumerWiersza++;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////

    }
}