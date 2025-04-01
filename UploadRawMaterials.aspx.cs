using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data; 

namespace CallawayWeb
{
    public partial class UploadParts : System.Web.UI.Page
    {
        static DataTable TablaModelsNoGuardados = new DataTable();
        static DataTable myTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
             {
                 if (!myTable.Columns.Contains("Raw_Material"))
                 {
                     myTable.Columns.Add("RAW_MATERIAL", typeof(String));
                     myTable.Columns.Add("DESCRIPTION", typeof(String));
                     myTable.Columns.Add("RL", typeof(String));
                     myTable.Columns.Add("MODEL", typeof(String));
                     myTable.Columns.Add("TYPE", typeof(String));
                     myTable.Columns.Add("MATERIAL", typeof(String));
                     myTable.Columns.Add("ISBLEND", typeof(String));
                     myTable.Columns.Add("CATEGORY", typeof(String));
                     myTable.Columns.Add("GENDER", typeof(String));
                 }
                //-------------------
                 if (!TablaModelsNoGuardados.Columns.Contains("MODEL"))
                 {
                     DataColumn column1;

                     // DataView view1;
                     column1 = new DataColumn();
                     column1.DataType = Type.GetType("System.String");
                     column1.ColumnName = "MODEL";
                     TablaModelsNoGuardados.Columns.Add(column1);
                 }
            }
        }

        protected void BtnReadRW(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/App_Data/");
            //String path = "C:\\CallawayDATA\\";
            if (FileUploadRW.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(FileUploadRW.FileName).ToLower();
                String[] allowedExtensions = { ".xls", ".xlsx" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    ClearGrids();
                    if (File.Exists(path + "Parts.xls"))
                        File.Delete(path + "Parts.xls");
                    //FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                    FileUploadRW.PostedFile.SaveAs(path + "Parts.xls");
                    LabelRW1.Text = "File uploaded!";
                    LeerExcellRW();
                    //BnSave.Visible = true;
                }
                catch (Exception ex)
                {
                    LabelRW1.Text = "File could not be uploaded." + ex.ToString();
                }
            }
            else
            {
                LabelRW1.Text = "Cannot accept files of this type.";
            }
        }
        private void LeerExcellRW()
        {
            try
            {
                myTable.Clear();
                
                //En DataSource especificas la ruta del archivo 
                 //string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=|DataDirectory|\Parts.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1" + '"';
                 string CadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=|DataDirectory|\Parts.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0" + '"';

                
                //myTable.Columns.Add("Raw_Material", typeof(String));
                //myTable.Columns.Add("DESCRIPCION", typeof(String));
                //myTable.Columns.Add("RL", typeof(String));
                //myTable.Columns.Add("Model", typeof(String));
                //myTable.Columns.Add("TIPO", typeof(String));
                //myTable.Columns.Add("MATERIAL", typeof(String));
                //myTable.Columns.Add("DOBLADO", typeof(String));
                //myTable.Columns.Add("CATEGORIA", typeof(String));
                //myTable.Columns.Add("Gender", typeof(String));



                OleDbConnection con = new OleDbConnection(CadenaConexion);

                //Usuario y dirección son columnas en la hoja de excel 
                //string strSQL = "SELECT Model, Gender, Varilla, Tipo, Loft, Lie, [Tip Cut], [Butt Cut], SW, Ferrule, Profundidad FROM [Sheet1$]";
                string strSQL = "SELECT RAW_MATERIAL, DESCRIPTION, RL, MODEL, TYPE, MATERIAL, ISBLEND, CATEGORY, GENDER FROM [Sheet1$]";

                OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);


                da.Fill(myTable);
                GridViewRW1.DataSource = myTable;
                GridViewRW1.DataBind();


                DataView view = new DataView(myTable);
                DataTable distinctValues = view.ToTable(true, "MODEL", "CATEGORY");

                GridViewRW2.DataSource = distinctValues;
                GridViewRW2.DataBind();
                
                
                //DataTable TablaModelsNoGuardados = new DataTable();
               // DataColumn column1;
               DataRow row1;
               //// DataView view1;
               // column1 = new DataColumn();
               // column1.DataType = Type.GetType("System.String");
               // column1.ColumnName = "Model";
               // TablaModelsNoGuardados.Columns.Add(column1);

                foreach (DataRow row in distinctValues.Select())
                {
                    if (row["CATEGORY"].ToString()=="HD")
                    {
                    SQL sql = new SQL();
                    sql.Base();
                    sql.AddParameter("@Model_Id", row["MODEL"].ToString());
                    DataSet DS = sql.SpWeb_GetModelExists();
                    if ( Convert.ToInt16(DS.Tables[0].Rows[0][0])==0)
                    {
                        row1 = TablaModelsNoGuardados.NewRow();
                        row1["MODEL"] = row["Model_Exists"].ToString();
                        TablaModelsNoGuardados.Rows.Add(row1);
                    }
                    }
                }
                if (TablaModelsNoGuardados.Rows.Count > 0)
                {
                    GridViewRW2.Visible = true;
                    BnSave.Visible = false;
                    GridViewRW2.DataSource = TablaModelsNoGuardados;
                    GridViewRW2.DataBind();
                    GridViewRW1.Visible = false;
                }
                else
                {
                    GridViewRW2.Visible = false;
                    BnSave.Visible = true;
                    GridViewRW1.Visible = true;
                }

            }
            catch (Exception ex)
            {
                LabelRW1.Text = ex.ToString();
            }

        }

        protected void BnSaveRW(object sender, EventArgs e)

        {
            LbErrors.Text = "";
            try
            {
                  DataTable errores = new DataTable();
                  errores.Columns.Add("RAW_MATERIAL", typeof(String));
                  errores.Columns.Add("ERROR", typeof(String));
                  DataRow row1;

                for (int i = myTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = myTable.Rows[i];
                SQL sql = new SQL();
                sql.Base();
                sql.AddParameter("@RawMaterial_Id", dr["RAW_MATERIAL"].ToString().ToUpper());
                sql.AddParameter("@RawMaterial_Desc", dr["DESCRIPTION"].ToString().ToUpper());
                sql.AddParameter("@RL", dr["RL"].ToString().ToUpper());
                sql.AddParameter("@Model_id", dr["MODEL"].ToString().ToUpper());
                sql.AddParameter("@Loft", dr["TYPE"].ToString().ToUpper());
                sql.AddParameter("@shaft_Material", dr["MATERIAL"].ToString().ToUpper());
                sql.AddParameter("@Isblend", dr["ISBLEND"].ToString().ToUpper());
                sql.AddParameter("@Category", dr["CATEGORY"].ToString().ToUpper());
                sql.AddParameter("@Gender", dr["GENDER"].ToString().ToUpper());
                sql.spWeb_SetRawMaterial2();
                LbErrors.Text = sql.Errors;
                if (LbErrors.Text == "")
                {
                    dr.Delete();
                    GridViewRW1.DataSource = myTable;
                    GridViewRW1.DataBind();
                }
                else {
                    row1 = errores.NewRow();
                    row1["RAW_MATERIAL"] = dr["RAW_MATERIAL"].ToString();
                    row1["ERROR"]=LbErrors.Text;
                    errores.Rows.Add(row1);
                }
            }
                if (errores.Rows.Count > 0)
                {
                    GridViewRW3.ForeColor = System.Drawing.Color.Red;
                    GridViewRW3.Visible = true;
                    GridViewRW3.DataSource = errores;
                    GridViewRW3.DataBind();
                   
                }
                else
                {
                    GridViewRW3.Visible = false;
                   
                }

            }
        catch (Exception ex)
        {
            LbErrors1.Text =  ex.ToString();
        }
        }
        protected void ClearGrids() {
            LbErrors.Text = "";
            LbErrors1.Text = "";
            GridViewRW1.DataSource = null;
            DataBind();
            GridViewRW3.DataSource = null;
            DataBind();
            GridViewRW2.DataSource = null;
            DataBind();
            myTable.Clear();
            TablaModelsNoGuardados.Clear();
            
            
        }
        protected void GridViewRW2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LbModel.Text= GridViewRW2.SelectedRow.Cells[2].Text;
                var textbox = GridViewRW2.SelectedRow.Cells[1].FindControl("TxDescripcion") as TextBox; 
                LbDescripcion.Text = textbox.Text;
                LbErrors.Text = "";
                SQL sql = new SQL();
                sql.Base();
                sql.AddParameter("@model_Id", LbModel.Text);
                sql.AddParameter("@description", LbDescripcion.Text);
                sql.SpWeb_SetModel();
                LbErrors.Text = sql.Errors;
                if (LbErrors.Text == "")
                {
                    for (int i = TablaModelsNoGuardados.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = TablaModelsNoGuardados.Rows[i];
                        if (dr["Model"].ToString() == LbModel.Text)
                        {
                            dr.Delete();
                        }
                    }
                    GridViewRW2.DataSource = TablaModelsNoGuardados;
                    GridViewRW2.DataBind();
                    if (TablaModelsNoGuardados.Rows.Count == 0)
                    {
                        //GridView2.Visible = false;
                        BnSave.Visible = true;
                        GridViewRW1.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
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