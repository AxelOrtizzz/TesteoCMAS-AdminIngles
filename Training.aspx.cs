using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CallawayWeb
{
    public partial class Entrenamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEmployee_Ids_Click(object sender, EventArgs e)
        {
            PnlEmployee.Visible = true;
            PnlOperations.Visible = false;

        }

        protected void BtnOperations_Click(object sender, EventArgs e)
        {
            PnlOperations.Visible = true;
            PnlEmployee.Visible = false;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Employee_Id", TxbUser.Text);
            sql.AddParameter("@pass", TxbPass.Text);
            sql.AddParameter("@operation_Id", "60");
            DataSet ds = sql.SpWeb_GetEmployee_Extensions();
            LbErrors0.Text = sql.Errors;
            if (LbErrors0.Text == "" & (ds.Tables[0].Rows.Count != 0))
            {

                LbEmployee_Id0.Text = ds.Tables[0].Rows[0][0].ToString();
                LbEmployee_Id.Text = ds.Tables[0].Rows[0][1].ToString();
                TxbUser.Text = "";
                TxbPass.Text = "";
                LbErrors0.Text = "";
                Login.Visible = false;
                Panel1.Visible = true;
            }
            else
            {
                TxbUser.Text = "";
                TxbPass.Text = "";
                LbErrors0.Text = "error: you have not access";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PnlOperations.Visible = false;

        }
    }
}