using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raport_wydatkow
{
    internal class ObslugaBazyDanych
    {
        //METODA UZUPEŁNIA PARAMETRY POŁĄCZENIA
        //Tutaj wpisz lokalizację bazy danych
        //////////////////////////////////////////////////////////////////////////////////
        public string KonfiguracjaBazy()
        {
            string sciezka = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Y:\Szkola\2_rok_\4_semestr\Programowanie obiektowe 1\Projekt\Projekt wer4\raport wydatkow\Database1.mdf;Integrated Security=True";
            return sciezka;

        }
        //////////////////////////////////////////////////////////////////////////////////

        //DO POPRAWIENIA !!!!
        //METODA SZUKA W TABELI PODANE DANE (DATA, CO KUPIONE I KWOTA) SPRAWDZA CZY TE SAME DANE NIE ZOSTAŁY DWA RAZY WPISANE
        //////////////////////////////////////////////////////////////////////////////////
        public string sprawdzenieCzyzduplikowaneZakupy(string kwota, string cokupione, string data)
        {
            string test = "";
            //SqlConnection con = new SqlConnection(KonfiguracjaBazy());
            //con.Open();

            //DataClasses1DataContext dc = new DataClasses1DataContext();

            //var selectQuery = from x in dc.zakupy select x;


            SqlConnection con = new SqlConnection(KonfiguracjaBazy());
            con.Open();

            SqlCommand cmd = new SqlCommand("select data, cokupione, kwota from zakupy", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            da.Fill(ds, "Database1");
            con.Close();


            foreach (DataTable tabela in ds.Tables)
            {
                foreach (DataRow row in tabela.Rows)
                {
                    foreach (DataColumn kolumna in tabela.Columns)
                    {
                        test = row[kolumna].ToString();
                    }
                }
            }




            //DataSet ds = new DataSet();
            //DataTable dt = ds.Tables["zakupy"];

            //DataTable dt = new DataTable();
            //DataSet ds = new DataSet(dt["Database1"]);

            //dt.Select(x => x.kwota == kwota).ToList;


            //https://www.youtube.com/watch?v=zrzjuXV2qP0&ab_channel=ProgrammingGeek

            //Form1 form1 = new Form1();

            //SqlConnection con = new SqlConnection(KonfiguracjaBazy());
            //con.Open();

            ////SqlCommand szukanie_daty = new SqlCommand(@"select * from zakupy where data = '" + data + "'", con);
            //SqlCommand szukanie_daty = new SqlCommand(@"select * from zakupy", con);

            //SqlDataAdapter da = new SqlDataAdapter(szukanie_daty);
            //DataTable dt = new DataTable();//https://docs.microsoft.com/pl-pl/dotnet/api/system.data.datatable.select?view=net-6.0
            //DataSet ds = new DataSet();

            ////DataSet ds = new DataSet(Tables["Database1"]);

            //da.Fill(ds, "Database1");
            //con.Close();



            //dt = ds.Tables["Database1"];



            //https://stackoverflow.com/questions/20638351/find-row-in-datatable-with-specific-id

            //https://stackoverflow.com/questions/20638351/find-row-in-datatable-with-specific-id

            //szukanie w bazie danych c#
            //https://4programmers.net/Forum/C_i_.NET/172637-c_i_sql_wyszukiwanie_wartosci_w_bazie

            //DYNAMICZNE WYSZUKIWANIE W BAZIE
            //https://zajacmarek.com/2012/08/dynamiczne-wyszukiwanie-w-bazie-pierwsze-podejscie/
            return test;
        }
        //////////////////////////////////////////////////////////////////////////////////

    }
}
