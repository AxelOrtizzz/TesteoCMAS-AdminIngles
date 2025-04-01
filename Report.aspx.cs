using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallawayWeb
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

        }

     
        private void SetUpGridResults()
        { 
        SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@order_Id", TxtOrder.Text);
            GridView2.DataSource = sql.spWeb_GetOrderResults();
            LbErrors.Text = sql.Errors;
            GridView2.DataBind();
            if (GridView2.Rows.Count != 0)
            {
                ImageButton2.Visible = true;
                LbNoData2.Visible = false;
            }
            else
            {
                ImageButton2.Visible = false;
                LbNoData2.Visible = true;
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value);
        }

        protected void BtnSearchOrder_Click(object sender, EventArgs e)
        {
            SetUpGridResults();
            SetUpGridResultadosTests();
            SetUpGridRework();
            SetUpGridPiezas();
            SetupGridEmployee();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            SetUpGridResults();
            this.GridView2.AllowPaging = false;
            this.GridView2.DataBind();
            GridViewExportUtil.Export("Resultados.xls", this.GridView2);
        }
        private void SetUpGridResultadosTests()
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@order_id", TxtOrder.Text);
            GridView3.DataSource = sql.SpWeb_GetTestsResults();
            LbErrors.Text = sql.Errors;
            GridView3.DataBind();
            if (GridView3.Rows.Count != 0)
            {
                ImageButton3.Visible = true;
                LbNoData3.Visible = false;
                Label1.Visible = true;
            }
            else
            {
                ImageButton3.Visible = false;
                LbNoData3.Visible = true;
                Label1.Visible = false;
            }
        }

        private void SetUpGridRework()
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@order_Id", TxtOrder.Text);
            GridView4.DataSource = sql.SpWeb_GetRework();
            LbErrors.Text = sql.Errors;
            GridView4.DataBind();
            if (GridView4.Rows.Count != 0)
            {
                ImageButton4.Visible = true;
                LbNoData4.Visible = false;
                Label2.Visible = true;
            }
            else
            {
                ImageButton4.Visible = false;
                LbNoData4.Visible = true;
                Label2.Visible = false;
            }
        }
        private void SetUpGridPiezas()
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@order_id", TxtOrder.Text);
            GridView5.DataSource = sql.spWeb_GetOrderOperationQty();
            LbErrors.Text = sql.Errors;
            GridView5.DataBind();
            if (GridView5.Rows.Count != 0)
            {
                ImageButton5.Visible = true;
                LbNoData5.Visible = false;
                Label3.Visible = true;
            }
            else
            {
                ImageButton5.Visible = false;
                LbNoData5.Visible = true;
                Label3.Visible = false;
            }
        }

        private void SetupGridEmployee()
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@order_ID", TxtOrder.Text);
            GridView6.DataSource = sql.SpWeb_GetEmployeeOrder();
            LbErrors.Text = sql.Errors;
            GridView6.DataBind();
            if (GridView6.Rows.Count != 0)
            {
                ImageButton6.Visible = true;
                LbNoData6.Visible = false;
                Label4.Visible = true;
            }
            else
            {
                ImageButton6.Visible = false;
                LbNoData6.Visible = true;
                Label4.Visible = false;
            }
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            SetUpGridResultadosTests();
            this.GridView3.AllowPaging = false;
            this.GridView3.DataBind();
            GridViewExportUtil.Export("ResultadosTests.xls", this.GridView3);
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            SetUpGridRework();
            this.GridView4.AllowPaging = false;
            this.GridView4.DataBind();
            GridViewExportUtil.Export("Rework.xls", this.GridView4);
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            SetUpGridPiezas();
            this.GridView5.AllowPaging = false;
            this.GridView5.DataBind();
            GridViewExportUtil.Export("PiezasdelaOrder.xls", this.GridView5);
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            SetupGridEmployee();
            this.GridView6.AllowPaging = false;
            this.GridView6.DataBind();
            GridViewExportUtil.Export("EmployeesOrder.xls", this.GridView6);
        }

    }
}