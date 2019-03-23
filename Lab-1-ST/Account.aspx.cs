using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_1_ST
{
    public partial class Account : Page
    {

        int _client_id;

        protected void Page_Load(object sender, EventArgs e)
        {  
            var req = Request.QueryString["client_id"];
            if (!int.TryParse(req, out _client_id)) Response.Redirect("Default");
            var sql = $"SELECT * FROM account WHERE client_id = {_client_id}";
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var cmd = new MySqlCommand(sql, dbConn);
            var newTable = createDataTableTemplate(); //создаем таблицу, в которую будем записывать результат запроса
            var rdr = cmd.ExecuteReader();//выполняем запрос и записываем результат в массив  
            while (rdr.Read())
            {
                var newRow = newTable.NewRow();
                newRow["id"] = rdr.GetInt32(0);
                newRow["balance"] = GetBalance(rdr.GetInt32(0));

                newTable.Rows.Add(newRow);//добавление в таблицу строки с результатом запроса
            }
            rdr.Close();
            dbConn.Close();//закрываем соединение
            var name = "Все счета: ";
            if (int.TryParse(req, out _client_id)) name = GetName(_client_id);
            name_lbl.Text = name;
            GridView1.DataSource = newTable;//присваиваем источник данных элекменту отображения таблицы
            GridView1.DataBind();//применяем источник данных
        }

        private DataTable createDataTableTemplate()//конструктор таблицы
        {
            var table = new DataTable();
            var col1 = new DataColumn("id");
            var col2 = new DataColumn("balance");
            col1.DataType = typeof(int);
            col2.DataType = typeof(string);
            table.Columns.Add(col1);
            table.Columns.Add(col2);
            return table;
        }
        
        public double GetBalance(int id)
        {
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var cmd = new MySqlCommand($"SELECT * FROM history WHERE account_id = {id}", dbConn);
            var rdr = cmd.ExecuteReader();
            var sum = 0.0;
            while (rdr.Read())
            {
                if (rdr.GetInt32(2) == 0) sum += rdr.GetDouble(3);
                else sum -= rdr.GetDouble(3);
            }
            dbConn.Close();
            return sum;
        }

        public string GetName(int id)
        {
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var cmd = new MySqlCommand($"SELECT * FROM client WHERE id = {id}", dbConn);
            var reader = cmd.ExecuteReader();
            reader.Read();
            var result = reader.GetString(1);
            reader.Close();
            dbConn.Close();
            return result;
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var cmd = new MySqlCommand($"INSERT INTO account VALUES(null,{_client_id})", dbConn);
            cmd.ExecuteNonQuery();
            dbConn.Close();
            Response.Redirect($"Account?client_id={_client_id}");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);
            var account_id = GridView1.Rows[index].Cells[0].Text;
            if (e.CommandName == "history") Response.Redirect($"History?account_id={account_id}&client_id={_client_id}");
            else if(e.CommandName == "delete")
            {
                var dbConn = new MySqlConnection(UserAccount.StrConnection);
                dbConn.Open();
                var sql = $"DELETE FROM account WHERE id={account_id}";
                var cmd = new MySqlCommand(sql, dbConn);
                cmd.ExecuteNonQuery();
                dbConn.Close();
                Response.Redirect($"Account?client_id={_client_id}");
            }
        }
    }
}