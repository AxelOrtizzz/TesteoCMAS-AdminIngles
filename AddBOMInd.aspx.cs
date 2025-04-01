using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallawayWeb
{
    public partial class AltaProductRaw_MaterialInd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearchBM_Click(object sender, EventArgs e)
        {
            LbErrors.Text = "";
            GetGrid();
        }
        private void GetGrid()
        {
            try
            {
                SQL sql = new SQL();
                sql.Base();
                sql.AddParameter("@Product_Id", TxbProduct.Text);

                GridViewBOM.DataSource = sql.SpWeb_GetBOM();

                GridViewBOM.DataBind();
                if (GridViewBOM.Rows.Count == 0)
                {
                    LbErrors.Text = "There is no data";
                }
            }
            catch (Exception ex)
            {
                LbErrors.Text = ex.ToString();
            }

        }

        protected void BtnSaveBOM_Click(object sender, EventArgs e)
        {
            try
            {
                SQL sql = new SQL();
                sql.Base();
                sql.AddParameter("@product_ID", TxbProduct.Text);
                sql.AddParameter("@RawMaterial", TxbRawMaterial.Text);

                sql.spWeb_SetBOM();                
                LbErrors.Text = sql.Errors;
                if (LbErrors.Text == "")
                {
                    TxbRawMaterial.Text = "";
                    GetGrid();
                }
            }
            catch (Exception ex)
            {
                LbErrors.Text = ex.ToString();
            }
           
        }

        protected void GridViewBOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SQL sql = new SQL();
                sql.Base();
                sql.AddParameter("@product_Id", GridViewBOM.SelectedRow.Cells[1].Text.Trim());
                sql.AddParameter("@RawMaterial_Id", GridViewBOM.SelectedRow.Cells[2].Text.Trim());
                sql.spWeb_DelBOM();
                GetGrid();
            }
            catch (Exception ex)
            {
                LbErrors.Text = ex.ToString();
            }
        }

        protected void BtnModel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Alta.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Alta.aspx");
        }

        protected void BtnLimites_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Alta.aspx");
        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/UploadSpecs.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UploadRawMaterials.aspx");
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/AddBOM.aspx");
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddBOMInd.aspx");
        }
    }
}