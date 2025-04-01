using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallawayWeb
{
    public partial class UCEmployee_IdOperation : System.Web.UI.UserControl
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
            DDAreaOp.DataSource = sql.SpWeb_GetAreas();
            DDAreaOp.DataTextField = "Area";
            DDAreaOp.DataValueField = "Area";
            DDAreaOp.DataBind();
            DDAreaOp.SelectedIndex = 0;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
           
            SQL sql = new SQL();
            sql.Base();
            if (string.Compare(TxbEmployeeId.Text, "") != 0)
                sql.AddParameter("@Employee_id", TxbEmployeeId.Text);
            if (string.Compare(TxbEmployeeName.Text, "") != 0)
                sql.AddParameter("@Employee_Name", TxbEmployeeName.Text);
            GridView1.DataSource = sql.SpWeb_GetEmployees();
            GridView1.DataBind();
        }
        private void CargaOperations(string area)
        {
            DDoperations.Items.Clear();
             SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@area", area);
            DDoperations.DataSource = sql.SpWeb_GetOperationsXarea();
            DDoperations.DataTextField = "Operation_desc";
            DDoperations.DataValueField = "Operation_id";
            DDoperations.DataBind();
            if(DDoperations.Items.Count>0)
            DDoperations.SelectedIndex = 0;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            TxbEmployeeId.Text = GridView1.SelectedRow.Cells[1].Text;
            TxbEmployeeName.Text = GridView1.SelectedRow.Cells[2].Text;
            DDAreaOp.SelectedValue = GridView1.SelectedRow.Cells[3].Text.Trim();
            CargaOperations(GridView1.SelectedRow.Cells[3].Text.Trim());
            CargaPanel();
        }

        private void CargaPanel()
        {
            LbID.Text = TxbEmployeeId.Text;
            LbNombre.Text=TxbEmployeeName.Text;
            SQL sql = new SQL();
            sql.Base();
            if (string.Compare(TxbEmployeeId.Text, "") != 0)
                sql.AddParameter("@Employee_Id", TxbEmployeeId.Text);

            GridView2.DataSource = sql.SpWeb_GetEmployeeOperations();
            GridView2.DataBind();
            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Employee_ID", TxbEmployeeId.Text);
            sql.AddParameter("@Operation_ID", DDoperations.SelectedValue.ToString());
            sql.SpWeb_SetEmployeeOperation();
            LbErrors.Text = sql.Errors;
            if (string.Compare(LbErrors.Text, "") == 0)
            {
                CargaPanel();
                //Clear();
            }
        }
        private void Clear()
    {
        TxbEmployeeId.Text = "";
        TxbEmployeeName.Text = "";
        DDoperations.Items.Clear();
        GridView1.DataSource = null;
        GridView1.DataBind();
        DDAreaOp.SelectedIndex = 0;
    }

        protected void DDArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaOperations(DDAreaOp.SelectedValue);
            
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
             SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Employee_Id", LbID.Text);
            sql.AddParameter("@Operation_ID", GridView2.SelectedRow.Cells[1].Text);
            sql.SpWeb_DelOperationEmployee();
            LbErrors.Text = sql.Errors;
            if (string.Compare(LbErrors.Text, "") == 0)
                CargaPanel();

            
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Clear();
            LbID.Text = "";
            LbNombre.Text = "";
            GridView2.DataSource = null;
            GridView2.DataBind();
        }

       
    }
}