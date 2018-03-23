using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using chjSQLite;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowData();
            listView1.ItemsSource = dt.DefaultView;
        }
        public void ShowData()
        {
            dt = new DataTable();
            dt.Columns.Add("ContactID", System.Type.GetType("System.String"));
            dt.Columns.Add("FirstName", System.Type.GetType("System.String"));
            dt.Columns.Add("LastName", System.Type.GetType("System.String"));
            dt.Columns.Add("EmailAddress", System.Type.GetType("System.String"));

            //查询从50条起的20条记录 
            string sql = "select * from teacher ";
            SQLiteDBHelper db = new SQLiteDBHelper("E:\\科研\\726-横向项目\\sqlite\\db2.db");
            using (SQLiteDataReader reader = db.ExecuteReader(sql, null))
            {
               
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["ContactID"] = reader.GetString(0);
                    dr["FirstName"] = reader.GetString(1);
                    dr["LastName"] = reader.GetString(2);
                    dr["EmailAddress"] = reader.GetString(3);
                    dt.Rows.Add(dr);
                   
                    //Trace.WriteLine("ID:{0},TypeName{1}", reader.GetString(0), reader.GetString(1));
                    Trace.WriteLine("******************");
                    Trace.WriteLine(reader.GetString(0));
                    Trace.WriteLine(reader.GetString(1));
                    Trace.WriteLine(reader.GetString(2));
                    Trace.WriteLine(reader.GetString(3));
                    Trace.WriteLine("******************");
                }
            }
        } 
    }
}
