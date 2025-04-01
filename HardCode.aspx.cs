using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AjaxControlToolkit.AsyncFileUpload.Constants;

namespace CallawayWeb
{
    public partial class HardCode : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Employee_ID", TxbUser.Text);
            sql.AddParameter("@pass", TxbPassword.Text);
            sql.AddParameter("@operation_Id", "59");
            DataSet ds = sql.SpWeb_GetEmployee_Extensions();
            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "" & (ds.Tables[0].Rows.Count != 0))
            {
                LbEmployee_Id0.Text = ds.Tables[0].Rows[0][0].ToString();
                LbEmployee_Id.Text = ds.Tables[0].Rows[0][1].ToString();
                TxbUser.Text = "";
                TxbPassword.Text = "";
                LbErrors0.Text = "";
                Login.Visible = false;
                Panel1.Visible = true;
            }
            else
            {
                TxbUser.Text = "";
                TxbPassword.Text = "";
                LbErrors0.Text = "No access permissions";
            }
        }
    }
}