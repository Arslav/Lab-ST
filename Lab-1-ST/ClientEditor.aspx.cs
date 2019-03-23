using MySql.Data.MySqlClient;
using System;

namespace Lab_1_ST
{

    public partial class ClientEditor : System.Web.UI.Page
    {
        State _state; //Храним состояние формы (обновление записи или создание)
        int _client_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            var req = Request.QueryString["client_id"];
            if (Int32.TryParse(req, out _client_id)) _state = State.Update;
            else _state = State.Create;
          
            if (!IsPostBack) //Если форма не отправленна
            {
                if (_state == State.Update)
                {
                    var dbConn = new MySqlConnection(UserAccount.StrConnection);
                    dbConn.Open();
                    var cmd = new MySqlCommand($"SELECT * FROM client WHERE id = {_client_id}", dbConn);
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    name.Text = reader.GetString(1);
                    age.Text = reader.GetString(2);
                    work.Text = reader.GetString(3);
                    reader.Close();
                    dbConn.Close();
                }
                else delButton.Visible = false;
            }
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var sql = $"UPDATE Client SET name='{name.Text}',age='{age.Text}',work='{work.Text}' WHERE id='{_client_id}'";
            if (_state == State.Create) sql = $"INSERT INTO Client VALUES(null,'{name.Text}','{age.Text}','{work.Text}')";
            var cmd = new MySqlCommand(sql, dbConn);
            cmd.ExecuteNonQuery();
            dbConn.Close();
            Response.Redirect("Default");
        }

        protected void DelButton_Click(object sender, EventArgs e)
        {
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var sql = $"DELETE FROM Client WHERE id={_client_id}";
            var cmd = new MySqlCommand(sql, dbConn);
            cmd.ExecuteNonQuery();
            dbConn.Close();
            Response.Redirect("Default");
        }
    }
}