using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetAccess
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("a");
            String AccessConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=O:\\WorkPlace\\GitDefault\\DotNetAccess\\DotNetAccess.accdb";
            String Select = "SELECT * FROM UserInfo";
            DataSet MyDataSet = new DataSet();
            OleDbConnection MyAccessDBConn = null;
            try
            {
                MyAccessDBConn = new OleDbConnection(AccessConnStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }
            try
            {
                OleDbCommand MyAccessCommand = new OleDbCommand(Select, MyAccessDBConn);
                OleDbDataAdapter MyDataAdapter = new OleDbDataAdapter(MyAccessCommand);

                MyAccessDBConn.Open();
                MyDataAdapter.Fill(MyDataSet,"UserInfo");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to Read the Data. \n{0}", ex.Message);
                return;
            }
            finally
            {
                MyAccessDBConn.Close();
            }
            try
            {
                DataTableCollection Dta = MyDataSet.Tables;
                foreach (DataTable Table in Dta)
                {
                    Console.WriteLine("Found Table {0}", Table.TableName);
                }
                DataRowCollection dtr = MyDataSet.Tables["UserInfo"].Rows;
                foreach (DataRow Row in dtr)
                {
                    System.Diagnostics.Debug.WriteLine("UserID is {0},UserName is {1}", Row[1], Row[2]);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}