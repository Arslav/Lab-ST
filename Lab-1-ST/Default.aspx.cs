using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_1_ST
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sql = "SELECT * FROM client";
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var cmd = new MySqlCommand(sql, dbConn);
            var newTable = createDataTableTemplate(); //создаем таблицу, в которую будем записывать результат запроса
            var rdr = cmd.ExecuteReader();//выполняем запрос и записываем результат в массив
            while (rdr.Read())
            {
                var newRow = newTable.NewRow();
                newRow["id"] = rdr.GetInt32(0);
                newRow["name"] = rdr.GetString(1);
                newRow["age"] = rdr.GetInt32(2);
                newRow["work"] = rdr.GetString(3);
                newTable.Rows.Add(newRow);//добавление в таблицу строки с результатом запроса
            }
            rdr.Close();
            dbConn.Close();//закрываем соединение
            GridView1.DataSource = newTable;//присваиваем источник данных элекменту отображения таблицы
            GridView1.DataBind();//применяем источник данных
        }

        private DataTable createDataTableTemplate()//конструктор таблицы
        {
            var table = new DataTable();          
            var col1 = new DataColumn("id");
            var col2 = new DataColumn("name");
            var col3 = new DataColumn("age");
            var col4 = new DataColumn("work");
            col1.DataType = typeof(int);
            col2.DataType = typeof(string);            
            col3.DataType = typeof(int);          
            col4.DataType = typeof(string);
            table.Columns.Add(col1);
            table.Columns.Add(col2);
            table.Columns.Add(col3);
            table.Columns.Add(col4);
            return table;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);
            var id = GridView1.Rows[index].Cells[0].Text;
            if (e.CommandName == "view")
            {
               
                Response.Redirect($"Account?client_id={id}");
            }
            else if (e.CommandName == "edit")
            {
                Response.Redirect($"ClientEditor?client_id={id}");
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientEditor");
        }
    }
}