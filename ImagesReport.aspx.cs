using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Security.Principal;


namespace CallawayWeb
{
    public partial class ImagesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaGrid();
        }
        protected void CargaGrid()
        {
            LbMsg.Text = "";
            Label1.Text = "";
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Raw_Material", typeof(String));
            tabla.Columns.Add("Descripcion", typeof(String));
            tabla.Columns.Add("RL", typeof(String));
            tabla.Columns.Add("Model", typeof(String));
            tabla.Columns.Add("Tipo", typeof(String));
            tabla.Columns.Add("Material", typeof(String));
            tabla.Columns.Add("Dobla", typeof(String));
            tabla.Columns.Add("Categoria", typeof(String));
            tabla.Columns.Add("Fecha", typeof(String));
            DataRow row1;
            string nombre = "";
            string path = "";
            int counter = 0;
            SQL sql = new SQL();
            sql.Base();
            DataSet DS = sql.SpWeb_GetPartsImagesReport();

            //-------------------CREDENCIALES-------------------------------------------------------------------------
            IntPtr logonToken = WindowsIdentity.GetCurrent().Token;
            var windowsIdentity = new WindowsIdentity(logonToken);
            using (var impersonationContext = windowsIdentity.Impersonate())
            {
                // Connect, read, write


                //------------------------------------------------------------------------------------------

                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    nombre = dr["RawMaterial_Id"].ToString();
                    //path = "D:\\CallawayImages\\" + nombre + ".jpg";
                    path = "\\\\cgmxfile400\\ProcessEngineering\\Tracebility\\Images\\" + nombre + ".jpg";
                    // path = "\\\\cgmxfile400\\CallawayAdmin\\ProcessEngineering\\Traceability\\Images\\" + nombre + ".jpg";               
                    //LbErrors.Text = path;

                    if (File.Exists(path))
                    {
                        counter++;
                    }
                    else
                    {
                        row1 = tabla.NewRow();
                        row1["Raw_Material"] = dr["RawMaterial_Id"].ToString();
                        row1["Descripcion"] = dr["RawMaterial_Desc"].ToString();
                        row1["RL"] = dr["RL"].ToString();
                        row1["Model"] = dr["Model_Id"].ToString();
                        row1["Tipo"] = dr["Loft"].ToString();
                        row1["Material"] = dr["Shaft_Material"].ToString();
                        row1["Dobla"] = dr["isBlend"].ToString();
                        row1["Categoria"] = dr["CategorY"].ToString();
                        row1["Fecha"] = dr["Date_Inserted"].ToString();
                        tabla.Rows.Add(row1);
                    }
                }

            }//LLAVE CORRESPONDIENTE A LAS CREDENCIALES
            //LbPath.Text = path;
            //LbPath.Text = windowsIdentity.Name;
            if (tabla.Rows.Count > 0)
            {
                ImageButton1.Visible = true;
              
                GridView1.DataSource = tabla;
                GridView1.DataBind();
                Label1.Text = "Se encontraron " + GridView1.Rows.Count.ToString() + " Raw_Material numbers without image on server:";
                LbMsg.Text = counter.ToString() + " Raw_Material with your image stored.";
            }
            else
            {
                LbMsg.Text = counter.ToString() + " Raw_Material with your image stored. There are no Raw_Material Numbers without images.";
                ImageButton1.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //CargaGrid();
                //this.GridView1.AllowPaging = false;
                //this.GridView1.DataBind();
                GridViewExportUtil.Export("Raw_Materials.xls", this.GridView1);
            }
            catch (Exception ex)
            {
                LbErrors.Text = ex.ToString();
            }
        }
    }
}