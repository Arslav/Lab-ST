using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_1_ST
{
    public partial class HistoryEdit : System.Web.UI.Page
    {
        State _state;
        int _history_id;
        int _client_id;
        int _account_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            var history_req = Request.QueryString["history_id"];
            var client_req = Request.QueryString["client_id"];
            var acount_req = Request.QueryString["account_id"];
            if (!Int32.TryParse(acount_req, out _account_id)) Response.Redirect("Default");
            if (!Int32.TryParse(client_req, out _client_id)) Response.Redirect("Default");
            if (Int32.TryParse(history_req, out _history_id)) _state = State.Update;
            else _state = State.Create;
            if (!IsPostBack)
            { 
                if (_state == State.Update)
                {
                    var dbConn = new MySqlConnection(UserAccount.StrConnection);
                    dbConn.Open();
                    var cmd = new MySqlCommand($"SELECT * FROM history WHERE id = {_history_id}", dbConn);
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    type.SelectedValue = reader.GetString(2);
                    sum.Text = reader.GetString(3);
                    reader.Close();
                    dbConn.Close();
                }
                else delButton.Visible = false;
            }
        }

        protected void DelButton_Click(object sender, EventArgs e)
        {
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var sql = $"DELETE FROM history WHERE id={_history_id}";
            var cmd = new MySqlCommand(sql, dbConn);
            cmd.ExecuteNonQuery();
            dbConn.Close();
            Response.Redirect($"History?account_id={_account_id}&client_id={_client_id}");
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            var dbConn = new MySqlConnection(UserAccount.StrConnection);
            dbConn.Open();
            var sql = $"UPDATE history SET type='{type.SelectedValue}',sum='{sum.Text}' WHERE id='{_history_id}'";
            if (_state == State.Create) sql = $"INSERT INTO history VALUES(null,'{_account_id}','{type.SelectedValue}','{sum.Text}')";
            var cmd = new MySqlCommand(sql, dbConn);
            cmd.ExecuteNonQuery();
            dbConn.Close();
            Response.Redirect($"History?account_id={_account_id}&client_id={_client_id}");
        }
    }
}