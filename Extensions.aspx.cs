using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace CallawayWeb
{
    public partial class Extensiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.Visible = true;
                GetGrid();
            }
        }



        protected void GetGrid()
        {
            SQL sql = new SQL();
            sql.Base();

            // Verificar si se proporcionan las fechas de inicio y fin
            string startDate = TextBox2.Text;
            string endDate = TextBox1.Text;

            if (string.IsNullOrEmpty(startDate))
            {
                // Si no hay valor para StartDate, tomar la fecha actual menos 15 días
                startDate = DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd");
            }

            if (string.IsNullOrEmpty(endDate))
            {
                // Si no hay valor para EndDate, tomar la fecha actual
                endDate = DateTime.Now.ToString("yyyy-MM-dd");
            }

            // Pasar las fechas al procedimiento almacenado
            sql.AddParameter("@StartDate", startDate);
            sql.AddParameter("@EndDate", endDate);

            // Llamar al procedimiento almacenado para obtener los datos
            GridView1.DataSource = sql.SpWeb_GetExtensions();
            LbErrors.Text = sql.Errors;

            if (string.IsNullOrEmpty(LbErrors.Text))  // Verificar si no hubo errores
            {
                GridView1.DataBind();
            }
            else
            {
                // Mostrar el error si ocurrió alguno
                LbErrors.Text = "Error: " + LbErrors.Text;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            GetGrid();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string desc = e.Row.Cells[5].Text;

                //int cant = (from item in ((DataTable)Session["datos"]).AsEnumerable()
                //            where item.Field<string>("Descripcion") == desc
                //            select item).Count();

                if (desc == "" || desc == "&nbsp;")
                {
                    e.Row.BackColor = Color.LightCoral;
                }

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbErrors.Text = "";
            try
            {
                string desc = GridView1.SelectedRow.Cells[5].Text;
                if (desc == "" || desc == "&nbsp;")
                    {
                    TxOrder.Text = GridView1.SelectedRow.Cells[1].Text;
                    
                    
                    TxLinea.Text = GridView1.SelectedRow.Cells[7].Text;
                }
                else
                LbErrors.Text = "Extension already released";
            }
            catch (Exception exception)
            { LbErrors.Text = exception.ToString(); }
        }
        private void clear()
        { 
            TxOrder.Text ="";
                   
                   
                    TxLinea.Text = "";
                    LbErrors.Text = "";

                    //DDEmployee_Id.SelectedIndex = 0;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQL sql = new SQL();
                sql.Base();
                sql.AddParameter("@Order_ID", TxOrder.Text);
                
                sql.AddParameter("@Employee_Id", LbEmployee_Id0.Text);
                sql.SpWeb_UpdExtensiones();
                clear();
                GetGrid();
                LbErrors.Text = sql.Errors;

            }
            catch (Exception exception)
            {
                LbErrors.Text = exception.ToString(); 
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            GridViewExportUtil.Export("Extensiones.xls", this.GridView1);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Employee_Id", TextBox3.Text);
            sql.AddParameter("@pass", TextBox4.Text);
            sql.AddParameter("@operation_Id", "58");
            DataSet ds = sql.SpWeb_GetEmployee_Extensions();
            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "" & (ds.Tables[0].Rows.Count != 0))
            {
                
                LbEmployee_Id0.Text = ds.Tables[0].Rows[0][0].ToString();
                LbEmployee_Id.Text = ds.Tables[0].Rows[0][1].ToString();
                TextBox3.Text = "";
                TextBox4.Text = "";
                LbErrors0.Text = "";
                Panel2.Visible = false;
                Panel1.Visible = true;
            }
            else
            {
                TextBox3.Text = "";
                TextBox4.Text = "";
                LbErrors0.Text = "No authorization";
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();          
            sql.AddParameter("@order_Id", TxOrder.Text);
            GridView1.DataSource = sql.SpWeb_GetExtensions1();
            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "")
            {
                
                GridView1.DataBind();
                TxOrder.Text = "";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            clear();
            LbEmployee_Id.Text = "";
            LbEmployee_Id.Text = "";
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
    }
}