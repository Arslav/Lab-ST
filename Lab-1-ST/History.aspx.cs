using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace Lab_1_ST
{
    public partial class History : System.Web.UI.Page
    {

        Dictionary<int, string> type_dict = new Dictionary<int, string>()
        {
            {0, "Приход" },
            {1, "Расход" },
        };
        int _account_id;
        int _client_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            var client_req = Request.QueryString["client_id"];
            var account_req = Request.QueryString["account_id"];
            if (!int.TryParse(client_req, out _client_id)) Response.Redirect("Default");
            if (!int.TryParse(account_req, out _account_id)) Response.Redirect($"Account?client_id={_client_id}");
            acoulr_lbl.Text = $"Счет: {_account_id}";
            var sql = $"SELECT * FROM history WHERE account_id = {_account_id}";
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var cmd = new MySqlCommand(sql, dbConn);
            var newTable = createDataTableTemplate(); //создаем таблицу, в которую будем записывать результат запроса
            var rdr = cmd.ExecuteReader();//выполняем запрос и записываем результат в массив
            while (rdr.Read())
            {
                var newRow = newTable.NewRow();
                newRow["id"] = rdr.GetInt32(0);
                newRow["type"] = type_dict[rdr.GetInt32(2)];
                newRow["sum"] = rdr.GetDouble(3);
                name_lbl.Text = GetName(rdr.GetInt32(1));
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
            var col2 = new DataColumn("type");
            var col3 = new DataColumn("sum");
            col1.DataType = typeof(int);
            col2.DataType = typeof(string);
            col3.DataType = typeof(double);
            table.Columns.Add(col1);
            table.Columns.Add(col2);
            table.Columns.Add(col3);
            return table;
        }

        public string GetName(int id)
        {
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var cmd = new MySqlCommand($"SELECT client.name FROM account, client WHERE Account.id = {id} AND client.id=Account.client_id", dbConn);
            var reader = cmd.ExecuteReader();
            reader.Read();
            var result = reader.GetString(0);
            reader.Close();
            dbConn.Close();
            return result;
        }

        protected void createButton_Click(object sender, EventArgs e)
        {
            Response.Redirect($"HistoryEdit?account_id={_account_id}&client_id={_client_id}");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);
            var history_id = GridView1.Rows[index].Cells[0].Text;
            Response.Redirect($"HistoryEdit?history_id={history_id}&account_id={_account_id}&client_id={_client_id}");
        }
    }
}