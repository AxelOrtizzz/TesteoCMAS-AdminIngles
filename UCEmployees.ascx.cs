using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CallawayWeb
{
    public partial class UCEmployees : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAreas();
            }
        }
        public void GetAreas()
        { 
            SQL sql = new SQL();
            sql.Base();
            DDArea.DataSource = sql.SpWeb_GetAreas();
            DDArea.DataTextField = "Area";
            DDArea.DataValueField = "Area";
            DDArea.DataBind();
            DDArea.SelectedIndex = 0;
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            LbErrors.Text = "";
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Employe_id", TxbEmployeeID.Text);
            sql.AddParameter("@Employe_Name", TxbName .Text);
            sql.AddParameter("@ShopFlor_Area", DDArea.SelectedValue);
            sql.AddParameter("@Stado", DDEstado.SelectedValue);
            sql.AddParameter("@Pass", TxPassword.Text);
            sql.SpWeb_SetEmployee();
            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "")
            {
                Clear();
                LbErrors.Text = "Employee successfully saved.";
               
            }
        }
        private void Clear()
        {
            TxbEmployeeID .Text = "";
            TxbName .Text = "";
            DDArea.SelectedIndex = 0;
            GridView1.DataSource = null;
            GridView1.DataBind();
            DDEstado.SelectedIndex = 0;
            TxPassword.Text = "";
            

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            SQL sql = new SQL();
            sql.Base();
            if(string.Compare(TxbEmployeeID .Text, "") != 0)
                sql.AddParameter("@Employee_id",TxbEmployeeID .Text);
            if (string.Compare(TxbName  .Text, "") != 0)
                sql.AddParameter("@Employee_Name", TxbName .Text);
            GridView1.DataSource = sql.SpWeb_GetEmployees();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           TxbEmployeeID .Text= GridView1.SelectedRow.Cells[1].Text;
           TxbName .Text = GridView1.SelectedRow.Cells[2].Text;
           DDArea.SelectedValue = GridView1.SelectedRow.Cells[3].Text.Trim();
           TxPassword.Text = GridView1.SelectedRow.Cells[6].Text.Trim();
          // DDEstado.SelectedValue = bool.Parse(GridView1.SelectedRow.Cells[4].Text).ToString();
           //CheckBox c = (CheckBox)GridView1.SelectedRow.FindControl("CheckBox1");
           //if (c.Checked == true)
           //{
           //    DDArea.SelectedValue = "1";
           //    //do something
           //}
           //else if (c.Checked == false)
           //{
           //    DDArea.SelectedValue = "0";
           //    //do something 
           //}
           SQL sql = new SQL();
           sql.Base();
           sql.AddParameter("@id", TxbEmployeeID .Text);
            DataSet ds = sql.SpWeb_GetEmployeeStatus();
           string resultado = ds.Tables[0].Rows[0][0].ToString();
            if (resultado=="False")
                DDEstado.SelectedValue = "0";
            else
                DDEstado.SelectedValue = "1";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@id", TxbEmployeeID .Text);
            sql.SpWeb_DelEmployee();
            LbErrors.Text = sql.Errors;
            if (string.Compare(LbErrors.Text, "") == 0)
                Clear();
        }
    }
}