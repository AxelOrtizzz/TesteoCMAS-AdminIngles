using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Web.Services;
using System.Data.OleDb;


namespace CallawayWeb
{
    public partial class About : Page
    {
        static string ViejaCabeza = "";
        static string ViejoGender = "";
        static string sharedFolderPath = @"\\cgmfs402\Tracebility\Images\";
        static DataTable TablaModelsNoGuardados = new DataTable();
        static DataTable myTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCombosRaw_Materials();
                RequiredFieldValidator20.Enabled = false;
                LoadPageAddRW();
                
            }
        }

        protected void MostrarMensaje(string mensaje, bool esExito)
        {
            string tipoMensaje = esExito ? "success" : "error";

            string script = $@"
                var mensajeElemento = document.getElementById('mensajes');
                mensajeElemento.innerText = '{mensaje}';
                mensajeElemento.style.color = '{(esExito ? "green" : "red")}';
                mensajeElemento.style.display = 'block';

                setTimeout(function() {{
                    mensajeElemento.style.display = 'none';
                    }}, 5000);
                ";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarMensaje", script, true);
        }

        [WebMethod]
        public static void EliminarImagenes()
        {
            try
            {
                string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/imgServidor/");

                if (Directory.Exists(folderPath))
                {
                    string[] archivos = Directory.GetFiles(folderPath, "*.*")
                                                 .Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png") || s.EndsWith(".gif"))
                                                 .ToArray();

                    foreach (string archivo in archivos)
                    {
                        File.Delete(archivo);
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar el error si lo deseas
                System.Diagnostics.Debug.WriteLine("Error deleting image " + ex.Message);
            }
        }

        protected void BtnModel_Click(object sender, EventArgs e)
        {
            AltaModel.Visible = true;
            AddBOM.Visible = false;
            AltaRaw_Materials.Visible = false;
            AddBOMInd.Visible = false;
            AddMasiveRM.Visible = false;
            AltaLimites.Visible = false;
            BtSaveRaw_Material.Visible = true;
            BtnUpdateRaw_Material.Visible = false;
            BtnDeleteRaw_Material.Visible = false;
            AddMasiveSpecs.Visible = false;
            LbErrors.Text = "";
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            AddMasiveSpecs.Visible = true;
            AddBOM.Visible = false;
            AddMasiveRM.Visible = false;
            AddBOMInd.Visible = false;
            AltaModel.Visible = false;
            AltaRaw_Materials.Visible = false;
            AltaLimites.Visible = false;
            BtSaveSpecs.Visible = false;
            BtnDeleteSpec.Visible = false;
            BtnUpdateSpec.Visible = false;
            LbErrors.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            AddMasiveRM.Visible = true;
            AddBOM.Visible = false;
            AddBOMInd.Visible = false;
            AddMasiveSpecs.Visible = false;
            AltaModel.Visible = false;
            AltaRaw_Materials.Visible = false;
            AltaLimites.Visible = false;
            BtSaveSpecs.Visible = false;
            BtnDeleteSpec.Visible = false;
            BtnUpdateSpec.Visible = false;
            LbErrors.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            AltaModel.Visible = false;
            AddBOM.Visible = false;
            AddBOMInd.Visible = false;
            AddMasiveRM.Visible = false;
            AddMasiveSpecs.Visible = false;
            AltaRaw_Materials.Visible = true;
            AltaLimites.Visible = false;
            BtSaveRaw_Material.Visible = true;
            BtnUpdateRaw_Material.Visible = false;
            BtnDeleteRaw_Material.Visible = false;
            BtSaveSpecs.Visible = false;
            BtnDeleteSpec.Visible = true;
            BtnUpdateSpec.Visible = true;
            //CargaCombosRaw_Materials();
            LbErrors.Text = "";

            // Limpiar los campos de texto en el formulario "Partes"
            TxtRaw_Material.Text = "";
            __TxtRaw_Material0.Text = ""; // Limpiar el campo de descripción
            TxtLoft.Text = "";
            TxGrip.Text = "";
            TxLength.Text = "";

            // Limpiar los DropDowns
            DDCategory0.SelectedIndex = 0; // Limpiar Dropdown de Categoría
            DDModels.SelectedIndex = 0;    // Limpiar Dropdown de Modelos
            DDRL.SelectedIndex = 0;         // Limpiar Dropdown de Mano
            DDMaterial.SelectedIndex = 0;   // Limpiar Dropdown de Material
            DDIsBlend.SelectedIndex = 0;      // Limpiar Dropdown de Dobla
            DDGender.SelectedIndex = 0;     // Limpiar Dropdown de Género

            // Limpiar la imagen
            //ImgParte.ImageUrl = ""; // Eliminar la imagen
            //ImgParte.Visible = false;

            // Limpiar el label de errores
            LbErrors.Text = "";
            ViewState.Clear();
        }
        protected void AddBOMInd_Click(object sender, EventArgs e)
        {
            AddBOMInd.Visible = true;
            AddBOM.Visible = false;
            AltaModel.Visible = false;
            AltaRaw_Materials.Visible = false;
            AddMasiveRM.Visible = false;
            AltaLimites.Visible = false;
            BtSaveRaw_Material.Visible = false;
            BtnUpdateRaw_Material.Visible = false;
            BtnDeleteRaw_Material.Visible = false;
            AddMasiveSpecs.Visible = false;
            LbErrors.Text = "";
        }

        protected void BtnSpects_Click(object sender, EventArgs e)
        {
            AltaModel.Visible = false;
            AddBOM.Visible = false;
            AddBOMInd.Visible = false;
            AddMasiveRM.Visible = false;
            AddMasiveSpecs.Visible = false;
            AltaRaw_Materials.Visible = false;
            AltaLimites.Visible = true;
            BtSaveSpecs.Visible = true;
            BtnDeleteSpec.Visible = false;
            BtnUpdateSpec.Visible = false;
            LbErrors.Text = "";
        }

        protected void BtnAddBOM_Click(object sender, EventArgs e)
        {
            AddBOM.Visible = true;
            AltaModel.Visible = false;
            AltaRaw_Materials.Visible = false;
            AddBOMInd.Visible = false;
            AddMasiveRM.Visible = false;
            AltaLimites.Visible = false;
            BtSaveRaw_Material.Visible = true;
            BtnUpdateRaw_Material.Visible = false;
            BtnDeleteRaw_Material.Visible = false;
            AddMasiveSpecs.Visible = false;
            LbErrors.Text = "";
        }

        protected void BtSaveModel_Click(object sender, EventArgs e)
        {
            LbErrors.Text = "";
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@model_Id", TxtModel.Text);
            sql.AddParameter("@description", TxtModelDesc.Text);
            sql.AddParameter("@ModelOr",TxtModelOr.Text);
            sql.AddParameter("@Order", TxtModelOrder.Text);
            sql.SpWeb_SetModel();
            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "")
            {
                LoadGridModels();
                TxtModel.Text = "";
                TxtModelDesc.Text = "";
                LbErrors.Text = "";
                TxtModelOr.Text = "";
                TxtModelOrder.Text = "";
                LbErrors.Text = "Model saved successfully.";
            }
        }

        protected void BtSaveRaw_Material_Click(object sender, EventArgs e)
        {
             LbErrors.Text = "";
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@RawMaterial_Id", TxtRaw_Material.Text);
            sql.AddParameter("@RawMaterial_Desc", __TxtRaw_Material0.Text);
            if (string.Equals(DDCategory0.SelectedValue, "SF"))
                sql.AddParameter("@RL", TxLength.Text);
            else
                if (string.Equals(DDCategory0.SelectedValue, "GRIP"))
                    sql.AddParameter("@RL", TxGrip.Text);
                else
                    sql.AddParameter("@RL", DDRL.SelectedValue);
            sql.AddParameter("@Model_id", DDModels.SelectedValue);
            sql.AddParameter("@Loft", TxtLoft.Text);
            sql.AddParameter("@Shaft_Material", DDMaterial.SelectedValue);
            sql.AddParameter("@Isblend", DDIsBlend.SelectedValue);
            sql.AddParameter("@Category", DDCategory0.SelectedValue);
            sql.AddParameter("@Gender", DDGender.SelectedValue);
            
            
            // Guardar la imagen en la carpeta compartida
            try
            {
                if (FileUploadImagen.HasFile && FileUploadImagen.FileContent.Length > 0)
                {
                    string fileExtension = Path.GetExtension(FileUploadImagen.FileName).ToLower();
                    if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".gif")
                    {
                        MostrarMensaje("Error: Only images in JPG, PNG, or GIF format are allowed.", false);
                        return;
                    }

                    // Nombre del archivo basado en el ID de la parte
                    string fileName = $"{TxtRaw_Material.Text}.jpg";
                    string fullPath = Path.Combine(sharedFolderPath, fileName);

                    // Guardar la imagen en la carpeta compartida
                    FileUploadImagen.SaveAs(fullPath);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar la imagen: " + ex.Message, false);
                return;
            }

            // Ejecutar procedimiento almacenado
            sql.spWeb_SetRawMaterial();
            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "")
            {
                ClearRaw_Materials();
                LbErrors.Text = "Raw Material Saved OK.";
                LoadGridRaw_Materials();
            }
            else
            {
                MostrarMensaje($"Error al guardar la parte: {LbErrors.Text}", false);
            }
        }
        protected void BtSaveSpects_Click(object sender, EventArgs e)
        {
            int cont=0;
            if (CheckBox1.Checked)
            {
                //SQL sql1 = new SQL();
                //sql1.Base();
                //sql1.AddParameter("@SKU", TxSKU.Text);
                //DataSet ds = sql1.SpWeb_GetSKUexists();
                // cont = Convert.ToInt32(ds.Tables[0].Rows[0]["contador"].ToString());
                cont = 1;
            }
            if ((CheckBox1.Checked & cont > 0) || (CheckBox1.Checked == false))
            {
                LbErrors.Text = "";
                SQL sql = new SQL();
                sql.Base();
                if (CheckBox1.Checked)
                    sql.AddParameter("@Model_id", TxSKU.Text);
                else
                    sql.AddParameter("@Model_id", DDModels0.SelectedValue);
                sql.AddParameter("@Operation_id", DDOperations.SelectedValue);
                sql.AddParameter("@Gender", DDGenderLim.SelectedValue);
                sql.AddParameter("@Loft", TxtLoftLim.Text);

                sql.AddParameter("@spec_desc", DDdescLim.SelectedValue);
                sql.AddParameter("@Spec_value_dec", TxtSpecDec.Text);
                sql.AddParameter("@Spec_value_frac", TxtSpecFrac.Text);
                sql.spWeb_SetSpec();
                LbErrors.Text = sql.Errors;
            }
            else
                LbErrors.Text = "SKU no exists";
            if (LbErrors.Text == "")
            {
                ClearSpects();
                LbErrors.Text = "Spec Saved OK.";
                LoadGridLimites();
            }
        }
        private void ClearSpects()
        {
            TxSKU.Text = "";
            DDModels0.SelectedIndex = 0;
            DDOperations.SelectedIndex = 0;
            DDGenderLim.Items.Clear();
            TxtLoftLim.Text = "";
            DDdescLim.Items.Clear();
            TxtSpecDec.Text = "";
            TxtSpecFrac.Text = "";
            BtSaveSpecs.Visible = true;
            BtnUpdateSpec.Visible = false;
            BtnDeleteSpec.Visible=true;
            LbErrorRaw_Materials.Text = "";
            //CargaCombosRaw_Materials();
        }
        private void ClearRaw_Materials()
        {
            DDCategory0.SelectedIndex = 0;
            TxLength.Text = "";
            //DDModels.SelectedIndex = 0;
            TxtRaw_Material.Text = "";
            __TxtRaw_Material0.Text = "";
            DDRL.SelectedIndex = 0;
            TxtLoft.Text="";
            DDMaterial.SelectedIndex = 0;
            DDIsBlend.SelectedIndex = 0;
            LbErrorRaw_Materials.Text = "";
            TxGrip.Text = "";
            TxGrip.Visible = false;
            //DDCategory0.SelectedIndex = 0;
        }
       
        private void LoadCombosRaw_Materials()
        {
            LoadModels();
            LoadModels1();
            LoadMaterials();
            LoadOperations();

        }

        private void LoadModels()
        {
            SQL sql = new SQL();
            sql.Base();
            DDModels.DataSource = sql.SpWeb_GetModels();
            DDModels.DataTextField = "Model_Id";
            DDModels.DataValueField = "Model_Id";
            DDModels.DataBind();
            DDModels.SelectedIndex= 0;
            
        }

        private void LoadModels1()
        {
            SQL sql = new SQL();
            sql.Base();
            DDModels0.DataSource = sql.SpWeb_GetModels();
            DDModels0.DataTextField = "Model_Id";
            DDModels0.DataValueField = "Model_Id";
            DDModels0.DataBind();
            DDModels0.SelectedIndex = 0;

        }
        private void LoadMaterials()
        {
            ListItem l = new ListItem("ST", "ST", true);
            DDMaterial.Items.Add(l);
            ListItem l1 = new ListItem("GR", "GR", true);
            DDMaterial.Items.Add(l1);
            ListItem l2 = new ListItem("IR", "IR", true);
            DDMaterial.Items.Add(l2);
            ListItem l3 = new ListItem("PT", "PT", true);
            DDMaterial.Items.Add(l3);
            ListItem l4 = new ListItem("WD", "WD", true);
            DDMaterial.Items.Add(l4);
        }
        private void LoadOperations()
        {
            SQL sql = new SQL();
            sql.Base();
            DDOperations.DataSource = sql.SpWeb_GetOperations();
            DDOperations.DataTextField = "Operation_desc";
            DDOperations.DataValueField = "Operation_id";
            DDOperations.DataBind();

        }
        private void LoadGridRaw_Materials()
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Category", DDCategory0.SelectedValue);
            GridView1.DataSource = sql.SpWeb_GetRawMaterials();
            GridView1.DataBind();
            LbErrorRaw_Materials.Text = "";
        }
        protected void DDModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargaGridRaw_Materials();
            //TxtRaw_Material.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            LbErrors.Text = GridView1.SelectedIndex.ToString();
            DDCategory0.SelectedValue = GridView1.SelectedRow.Cells[7].Text;
            if(string.Equals(DDCategory0.SelectedValue,"HD"))
            {
                if (GridView1.SelectedRow.Cells[3].Text == "&nbsp;" || GridView1.SelectedRow.Cells[3].Text == "  ")
                    DDModels.SelectedIndex = 0;
                else
                    DDModels.SelectedValue = GridView1.SelectedRow.Cells[3].Text.Trim().ToUpper();
                if (GridView1.SelectedRow.Cells[2].Text == "&nbsp;" || GridView1.SelectedRow.Cells[2].Text == "  ")
                    DDMaterial.SelectedIndex = 0;
                else
                    DDRL.Text = GridView1.SelectedRow.Cells[2].Text.Trim().ToUpper();
                TxtLoft.Text = GridView1.SelectedRow.Cells[4].Text.Trim();
                DDIsBlend.SelectedValue = GridView1.SelectedRow.Cells[6].Text.Trim().ToUpper(); 
            }
            TxtRaw_Material.Text = GridView1.SelectedRow.Cells[0].Text.Trim();
            __TxtRaw_Material0.Text = GridView1.SelectedRow.Cells[1].Text.Trim();

            if (string.Equals(DDCategory0.SelectedValue, "GRIP"))
            {
                TxtLoft.Text = GridView1.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                TxGrip.Visible = true;
                TxGrip.Text = GridView1.SelectedRow.Cells[2].Text.Trim();
            }
            if (string.Equals(DDCategory0.SelectedValue, "SF") || string.Equals(DDCategory0.SelectedValue, "HD"))
            {
                if (GridView1.SelectedRow.Cells[5].Text == "&nbsp;" || GridView1.SelectedRow.Cells[5].Text == "  ")
                    DDMaterial.SelectedIndex = 0;
                else
                    DDMaterial.SelectedValue = GridView1.SelectedRow.Cells[5].Text.Trim();
                TxLength.Text = GridView1.SelectedRow.Cells[2].Text.Trim();
            }
            if (GridView1.SelectedRow.Cells[9].Text == "&nbsp;" || GridView1.SelectedRow.Cells[9].Text == "  ")
                DDGender.SelectedIndex = 0;
            else
                DDGender.Text = GridView1.SelectedRow.Cells[9].Text.Trim();

            BtSaveRaw_Material.Visible = false;
            BtnUpdateRaw_Material.Visible = true;
            BtnDeleteRaw_Material.Visible = true;
            IdentifyCatRaw_Material();
            LbErrorRaw_Materials.Text = "";

            try
            {

                // Nombre del archivo de imagen
                string fileName = TxtRaw_Material.Text + ".jpg";
                string sharedImagePath = Path.Combine(sharedFolderPath, fileName);

                // Ruta de la carpeta en el proyecto (Content/imgServidor)
                string projectImagePath = Server.MapPath("~/Content/imgServidor/" + fileName);

                // Si la imagen ya existe en la carpeta del proyecto, eliminarla antes de copiar
                if (File.Exists(projectImagePath))
                {
                    File.Delete(projectImagePath);
                }

                // Copiar la imagen desde la carpeta compartida
                File.Copy(sharedImagePath, projectImagePath, true); // Sobrescribir si ya existe

                // Generar la URL relativa con un parámetro para evitar caché
                string imageUrl = $"/Content/imgServidor/{fileName}?cache_bust=" + DateTime.Now.Ticks.ToString();

                // Actualizar la imagen en la página
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarImagen", $"mostrarImagen('{imageUrl}');", true);
            }
            catch (Exception ex)
            {
                LbErrors.Text = "Error al cargar la imagen: " + ex.Message;
            }
        }

        protected void DDModels0_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridLimites();
        }
        private void LoadGridLimites()
        {
            SQL sql = new SQL();
            sql.Base();

            if (CheckBox1.Checked)
                sql.AddParameter("@model_Id", TxSKU.Text);
            else
                sql.AddParameter("@model_Id", DDModels0.SelectedValue);

            sql.AddParameter("@Operation_Id", DDOperations.SelectedValue);

            // Obtener el DataSet
            DataSet ds = sql.SpWeb_GetSpecs();

            // Verificar si el DataSet tiene datos antes de asignarlo al GridView
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable data = ds.Tables[0];

                // Imprimir cuántas filas se obtuvieron
                LbErrorRaw_Materials.Text = "Datos obtenidos: " + data.Rows.Count;

                // Asignar los datos al GridView
                GridView2.DataSource = data;
                GridView2.DataBind();
            }
            else
            {
                LbErrorRaw_Materials.Text = "No se encontraron datos en la consulta.";
            }
        }



        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == false)
            {
                DDModels0.SelectedValue = GridView2.SelectedRow.Cells[0].Text.ToString().Trim().ToUpper();
            }
            else
            {
                TxSKU.Text = GridView2.SelectedRow.Cells[0].Text.ToString().Trim();
                DDOperations.SelectedValue = GridView2.SelectedRow.Cells[1].Text.ToString().Trim();
                OperationChange();
                DDGenderLim.SelectedValue = GridView2.SelectedRow.Cells[3].Text.ToString().Trim();
                ViejoGender = GridView2.SelectedRow.Cells[3].Text.ToString().Trim();
                TxtLoftLim.Text = GridView2.SelectedRow.Cells[4].Text;
                ViejaCabeza = GridView2.SelectedRow.Cells[4].Text;
                DDdescLim.SelectedValue = GridView2.SelectedRow.Cells[5].Text.ToString().Trim().ToUpper();
                TxtSpecDec.Text = GridView2.SelectedRow.Cells[6].Text;
                TxtSpecFrac.Text = GridView2.SelectedRow.Cells[7].Text;
                BtSaveSpecs.Visible = false;
                BtnDeleteSpec.Visible = true;
                BtnUpdateSpec.Visible = true;
                LbErrorRaw_Materials.Text = "";
            }
        }


        protected void DeleteSpects()
        {
            SQL sql = new SQL();
            sql.Base();

            if (CheckBox1.Checked)
                sql.AddParameter("@model_Id", TxSKU.Text);
            else
            sql.AddParameter("@model_Id", DDModels0.SelectedValue);
            sql.AddParameter("@Operation_id", DDOperations.SelectedValue);
            sql.AddParameter("@Spect_desc", DDdescLim.SelectedValue);
            sql.AddParameter("@Gender", DDGenderLim.SelectedValue);

            sql.AddParameter("@Loft", TxtLoftLim.Text);
            sql.SpWeb_DelSpect();
            LoadGridLimites();
            LbErrorRaw_Materials.Text = "";

        }

        protected void IdentifyCatRaw_Material()
        {
            if (String.ReferenceEquals(DDCategory0.SelectedValue, "HD"))
            {
                DDRL.Enabled = true;
                RequiredFieldValidator7.Enabled = true;
                DDModels.Enabled = true;
                RequiredFieldValidator6.Enabled = true;
                TxtLoft.Enabled = true;
                RequiredFieldValidator5.Enabled = true;
                DDMaterial.Enabled = true;
                //DDMaterial.SelectedValue = "";
                RequiredFieldValidator8.Enabled = false;
                DDIsBlend.Enabled = true;
                RequiredFieldValidator9.Enabled = true;
                LbLongitud.Visible = false;
                TxLength.Visible = false;
            }
            if (String.ReferenceEquals(DDCategory0.SelectedValue, "GRIP"))
            {
                DDRL.Enabled = false;
                DDRL.SelectedValue = "";
                RequiredFieldValidator7.Enabled = false;
                DDModels.Enabled = false;
                DDModels.SelectedValue = "";
                RequiredFieldValidator6.Enabled = false;
                TxtLoft.Enabled = true;
                //TxtTipoRaw_Material.Text = "";
                RequiredFieldValidator5.Enabled = false;
                DDMaterial.Enabled = false;
                DDMaterial.SelectedValue = "";
                RequiredFieldValidator8.Enabled = false;
                DDIsBlend.Enabled = false;
                DDIsBlend.SelectedValue = "";
                RequiredFieldValidator9.Enabled = false;
                LbLongitud.Visible = false;
                TxLength.Visible = false;
            }
            if (String.ReferenceEquals(DDCategory0.SelectedValue, "SF"))
            {
                DDRL.Enabled = false;

                RequiredFieldValidator7.Enabled = false;
                DDModels.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                TxtLoft.Enabled = true;
                RequiredFieldValidator5.Enabled = false;
                DDMaterial.Enabled = true;
                RequiredFieldValidator8.Enabled = true;
                DDIsBlend.Enabled = false;
                RequiredFieldValidator9.Enabled = false;
                LbLongitud.Visible = true;
                TxLength.Visible = true;
                RequiredFieldValidator19.Enabled = false;
            }
            if (String.ReferenceEquals(DDCategory0.SelectedValue, "HC"))
            {
                DDRL.Enabled = false;

                RequiredFieldValidator7.Enabled = false;
                DDModels.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                TxtLoft.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
                DDMaterial.Enabled = false;
                RequiredFieldValidator8.Enabled = false;
                DDIsBlend.Enabled = false;
                RequiredFieldValidator9.Enabled = false;
                LbLongitud.Visible = false;
                TxLength.Visible = false;
            }
        }
        protected void DDCategory0_SelectedIndexChanged(object sender, EventArgs e)
        {

            ClearlodemasRaw_Materials();
            IdentifyCatRaw_Material();
            LoadGridRaw_Materials();
        }
        private void ClearlodemasRaw_Materials() {
            TxtRaw_Material.Text = "";
            __TxtRaw_Material0.Text="";
        }
        private void LoadGridRaw_MaterialsXRaw_Material()
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@RawMaterial_ID", TxtRaw_Material.Text);
            GridView1.DataSource = sql.SpWeb_GetRawMaterials();
            GridView1.DataBind();


            
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            __TxtRaw_Material0.Text = "";
            DDModels.SelectedIndex = 0;
            DDRL.SelectedIndex = 0;
            TxtLoft.Text = "";
            DDMaterial.SelectedIndex = 0;
            DDIsBlend.SelectedIndex = 0;
            BtSaveRaw_Material.Visible = true;
            BtnUpdateRaw_Material.Visible = false;
            BtnDeleteRaw_Material.Visible = false;
            LoadGridRaw_MaterialsXRaw_Material();
            // Limpiar mensajes previos
            LbErrors.Text = "";

            try
            {
                // Verificar que se haya ingresado una parte
                if (string.IsNullOrWhiteSpace(TxtRaw_Material.Text))
                {
                    MostrarMensaje("Por favor, ingrese una parte antes de buscar.", false);
                    return;
                }

                // Nombre del archivo basado en la parte ingresada
                string fileName = TxtRaw_Material.Text.Trim() + ".jpg";

                // Ruta de la carpeta compartida
                string sharedImagePath = Path.Combine(sharedFolderPath, fileName);

                // Ruta de la carpeta local donde se guardará la imagen
                string localFolderPath = Server.MapPath("~/Content/imgServidor/");
                string localImagePath = Path.Combine(localFolderPath, fileName);

                // Verificar si la imagen existe en la carpeta compartida
                if (!File.Exists(sharedImagePath))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarMensaje",
                        "document.getElementById('imagenPrevia').style.display = 'none';" +
                        "document.getElementById('textoPlaceholder').innerText = 'No hay imagen disponible';", true);

                    MostrarMensaje("No hay imagen disponible.", false);
                    return;
                }

                // Si la imagen ya existe en la carpeta local, eliminarla antes de copiar
                if (File.Exists(localImagePath))
                {
                    File.Delete(localImagePath);
                }

                // Copiar la imagen desde la carpeta compartida
                File.Copy(sharedImagePath, localImagePath, true);

                // Generar la URL relativa con un parámetro de caché para evitar que el navegador utilice la versión en caché
                string imageUrl = $"Content/imgServidor/{fileName}?cache_bust=" + DateTime.Now.Ticks.ToString();

                // Actualizar la imagen en la página con JavaScript
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarImagen",
                    $"document.getElementById('imagenPrevia').src = '{imageUrl}';" +
                    "document.getElementById('imagenPrevia').style.display = 'block';" +
                    "document.getElementById('textoPlaceholder').innerText = '';", true);

            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al buscar la imagen: " + ex.Message, false);
            }

        }

        protected void TxtRaw_Material_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnUpdateRaw_Material_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            //LbErrors.Text = GridView1.SelectedRow.Cells[0].Text;
            sql.AddParameter("@RawMaterial_Id", TxtRaw_Material.Text);
            sql.AddParameter("@RawMaterial_Desc", __TxtRaw_Material0.Text);
            if (string.Equals(DDCategory0.SelectedValue, "SF"))
                sql.AddParameter("@RL", TxLength.Text);
            else if (string.Equals(DDCategory0.SelectedValue, "GRIP"))
                sql.AddParameter("@RL", TxGrip.Text);
            else
                sql.AddParameter("@RL", DDRL.SelectedValue);
            //sql.AddParameter("@rl", DDRL.SelectedValue);
            sql.AddParameter("@Model_id", DDModels.SelectedValue);
            sql.AddParameter("@Loft", TxtLoft.Text);
            sql.AddParameter("@Shaft_Material",DDMaterial.Text );
            sql.AddParameter("@Isblend", DDIsBlend.Text );
            sql.AddParameter("@Category", DDCategory0.SelectedValue);
            sql.AddParameter("@Gender", DDGender.SelectedValue); 
            sql.SpWeb_UpdtRawMaterials();

            LoadGridRaw_Materials();
            BtSaveRaw_Material.Visible = true;
            BtnUpdateRaw_Material.Visible = false;
            BtnDeleteRaw_Material.Visible = false; 
            ClearRaw_Materials();

            if (FileUploadImagen.HasFile)
            {
                try
                {
                    string fileName = TxtRaw_Material.Text + ".jpg";
                    string imagePath = Path.Combine(@"\\cgmfs402\Tracebility\Images\", fileName);
                    string backupPath = Path.Combine(@"\\cgmfs402\Tracebility\Images\ImagesUpd\", fileName);

                    ClearRaw_Materials();

                    // Verifica si la carpeta es accesible
                    if (!Directory.Exists(@"\\cgmfs402\Tracebility\Images\"))
                    {
                        MostrarMensaje("La carpeta de imágenes no está disponible.", false);
                        return;
                    }

                    try
                    {
                        // Intenta eliminar la imagen existente
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }

                        // Guarda la nueva imagen en la carpeta principal
                        FileUploadImagen.SaveAs(imagePath);

                        // Verifica si la imagen se guardó correctamente
                        if (File.Exists(imagePath))
                        {
                            MostrarMensaje("Imagen actualizada correctamente.", true);
                            ImgParte.ImageUrl = imagePath + "?cache_bust=" + DateTime.Now.Ticks.ToString();
                        }
                        else
                        {
                            MostrarMensaje("No se pudo guardar la imagen en la ruta principal.", false);
                        }
                    }
                    catch (IOException)
                    {
                        // Si la imagen está en uso, guárdala en la carpeta temporal
                        FileUploadImagen.SaveAs(backupPath);

                        if (File.Exists(backupPath))
                        {
                            MostrarMensaje("La imagen está en uso en producción. Se guardó temporalmente y se actualizará más tarde.", true);
                        }
                        else
                        {
                            MostrarMensaje("Error al guardar la imagen en la carpeta temporal.", false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al guardar la imagen: " + ex.Message, false);
                }
            }
            else
            {
                ClearRaw_Materials();
            }
        }

        private void CargarImagen()
        {
            string fileName = $"{TxtRaw_Material.Text}.jpg"; // número de parte
            string filePath = $"\\\\cgmxfile400\\Tracebility\\Images\\{fileName}"; // Ruta de la carpeta compartida

            if (File.Exists(filePath))
            {
                ImgParte.ImageUrl = $"~/Content/imgServidor/{fileName}"; // URL relativa para mostrar en el navegador
            }
            else
            {
                ImgParte.ImageUrl = "~/Content/imgServidor/no-imagen.png"; // Imagen de "No disponible"
            }
        }

        protected void BtnDeleteRaw_Material_Click(object sender, EventArgs e)
        {
                       SQL sql = new SQL();
                       sql.Base();
                       LbErrors.Text = GridView1.SelectedRow.Cells[0].Text;
                       sql.AddParameter("@RawMaterial_Id", GridView1.SelectedRow.Cells[0].Text);
                       sql.SpWeb_DelRawMaterial();
                       LbErrorRaw_Materials.Text = sql.Errors;
                       if (string.Compare(LbErrorRaw_Materials.Text, "") == 0)
                       {
                           LoadGridRaw_Materials();
                           BtSaveRaw_Material.Visible = true;
                           BtnUpdateRaw_Material.Visible = false;
                           BtnDeleteRaw_Material.Visible = false;
                           ClearRaw_Materials();
                       }         
            
        }

        protected void DDOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperationChange();
            LoadGridLimites();
        }

        private void OperationChange()
        {
            DDGenderLim.Items.Clear();
            SQL sql1 = new SQL();
            sql1.Base();
            sql1.AddParameter("@Operation_id", DDOperations.SelectedValue.ToString());
            DDGenderLim.DataSource = sql1.SpWeb_GetGenders();
            DDGenderLim.DataTextField = "Gender";
            DDGenderLim.DataValueField = "Gender";
            DDGenderLim.DataBind();

            

            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Operation_id", DDOperations.SelectedValue);

            DDdescLim.DataSource = sql.spWeb_GetSpecsXmodel();
            DDdescLim.DataTextField = "Spec_desc".ToUpper();
            DDdescLim.DataValueField = "Spec_desc".ToUpper();
            DDdescLim.DataBind();
        }


        protected void DDGenderLim_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void TxtLimDec_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(TxtSpecDec.Text.ToString(), ""))
            {
                TxtSpecFrac.Text = "";
            }
            else
            {
                try
                {
                    if (string.Equals(DDOperations.SelectedValue, "20") || string.Equals(DDOperations.SelectedValue, "75") || string.Equals(DDdescLim.SelectedValue, "BALANCEO"))
                    {
                        if (string.Equals(DDOperations.SelectedValue, "75") || string.Equals(DDOperations.SelectedValue, "20"))
                            TxtSpecFrac.Text = TxtSpecDec.Text;
                        if (string.Equals(DDdescLim.SelectedValue, "BALANCEO"))
                        {
                            int valor = Convert.ToInt32(TxtSpecDec.Text);
                            if (valor == 114)
                                TxtSpecFrac.Text = "C2";
                            if (valor == 115)
                                TxtSpecFrac.Text = "C3";
                            if (valor == 116)
                                TxtSpecFrac.Text = "C4";
                            if (valor == 117)
                                TxtSpecFrac.Text = "C5";
                            if (valor == 118)
                                TxtSpecFrac.Text = "C6";
                            if (valor == 119)
                                TxtSpecFrac.Text = "C7";
                            if (valor == 120)
                                TxtSpecFrac.Text = "C8";
                            if (valor == 121)
                                TxtSpecFrac.Text = "C9";
                            if (valor == 122)
                                TxtSpecFrac.Text = "D0";
                            if (valor == 123)
                                TxtSpecFrac.Text = "D1";
                            if (valor == 124)
                                TxtSpecFrac.Text = "D2";
                            if (valor == 125)
                                TxtSpecFrac.Text = "D3";
                            if (valor == 126)
                                TxtSpecFrac.Text = "D4";
                            if (valor == 127)
                                TxtSpecFrac.Text = "D5";
                            if (valor == 128)
                                TxtSpecFrac.Text = "D6";
                        }
                    }
                    else
                    {
                        if (TxtSpecDec.Text.Length <= 10)
                        {
                            SQL sql = new SQL();
                            sql.Base();
                            sql.AddParameter("@Qty", TxtSpecDec.Text);
                            DataSet ds = sql.SpWeb_GetFraction();
                            TxtSpecFrac.Text = ds.Tables[0].Rows[0]["Fraction"].ToString();
                        }
                        else
                        {
                            TxtSpecFrac.Text = TxtSpecDec.Text;
                        }
                    }                 
                }
                catch {
                    LbErrors.Text = "errro: the value is not numeric";
                }
            }
        }

        protected void BtnUpdateSpects_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            //LbErrors.Text = GridView1.SelectedRow.Cells[0].Text;
            if (CheckBox1.Checked)
                sql.AddParameter("@model", TxSKU.Text);
            else
                sql.AddParameter("@model", DDModels0.SelectedValue);
            sql.AddParameter("@Operation_id", DDOperations.SelectedValue);
            sql.AddParameter("@Spec_desc", DDdescLim.SelectedValue);
            sql.AddParameter("@gender", DDGenderLim.SelectedValue);
            sql.AddParameter("@OldGender", ViejoGender);
            sql.AddParameter("@OldLoft", ViejaCabeza);
            sql.AddParameter("@Loft", TxtLoftLim.Text);
            sql.AddParameter("@decimal", TxtSpecDec.Text);
            sql.AddParameter("@fraction", TxtSpecFrac.Text);


            sql.SpWeb_UpdtSpec();
            LbErrors.Text=sql.Errors;
            LoadGridLimites();
            BtSaveSpecs.Visible = true;
            BtnUpdateSpec.Visible = false;
            BtnDeleteSpec.Visible = false;
            ClearSpects();
        }

        protected void BtnDeleteSpects_Click(object sender, EventArgs e)
        {
            DeleteSpects();
            ClearSpects();
        }

        

        

        protected void Button4_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/AddBOM.aspx");
        }



        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {   DDModels0.SelectedIndex = 0;
                DDModels0.Enabled = false;            
                TxSKU.Enabled = true;
                RequiredFieldValidator11.Enabled = false;
                RequiredFieldValidator20.Enabled = true;
            }
            else {
                TxSKU.Text = "";
                DDModels0.Enabled = true;
                TxSKU.Enabled = false;
                RequiredFieldValidator11.Enabled = true;
                RequiredFieldValidator20.Enabled = false;
            }
        }

        protected void TxSKU_TextChanged(object sender, EventArgs e)
        {
            LoadGridLimites();
        }

        protected void BtnSearchSpects_Click(object sender, EventArgs e)
        {
            LoadGridLimites();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            LoadGridModels();  
        }

        private void LoadGridModels()
        {
            SQL sql = new SQL();
            sql.Base();
           
            sql.AddParameter("@Model_ID", TxtModel.Text);
           
            GvModels.DataSource = sql.SpWeb_GetModels();
            GvModels.DataBind();
            
        }
        
        protected void GvModels_SelectedIndexChanged(object sender, EventArgs e)
        {
          TxtModel.Text=GvModels.SelectedRow.Cells[1].Text.Trim();
         TxtModelDesc.Text = GvModels.SelectedRow.Cells[2].Text.Trim();
         TxtModelOr.Text = GvModels.SelectedRow.Cells[3].Text.Trim();
         TxtModelOrder.Text = GvModels.SelectedRow.Cells[4].Text.Trim();
         BtnDeleteModel.Visible = true;
        }

        protected void BtnDeleteModel_Click(object sender, EventArgs e)
        {
               SQL sql = new SQL();
                       sql.Base();
                       sql.AddParameter("@Model", TxtModel.Text);
                       sql.SpWeb_DelModels();
                       LbErrorModels.Text = sql.Errors;
                       if (string.Compare(LbErrorModels.Text, "") == 0)
                       {
                           LoadGridModels();
                           BtnDeleteModel.Visible = false;
                           TxtModel.Text = "";
                           TxtModelDesc.Text = "";
                           TxtModelOr.Text = "";
                           TxtModelOrder.Text = "";
                       } 
            
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            ClearSpects();
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

        protected void BnSave_MasiveSpecs(object sender, EventArgs e)
        {
            try
            {
                DataTable errores = new DataTable();
                errores.Columns.Add("MODEL", typeof(String));
                errores.Columns.Add("OPERATION", typeof(String));
                errores.Columns.Add("DESCRIPTION", typeof(String));
                errores.Columns.Add("ERROR", typeof(String));
                DataRow row1;
                int CONTADOR = 0;
                LbInsertados.Text = "";
                foreach (GridViewRow row in GridView3.Rows)
                {
                    SQL sql = new SQL();
                    sql.Base();
                    sql.AddParameter("@Model_id", row.Cells[0].Text);
                    sql.AddParameter("@Operation_id", row.Cells[1].Text);
                    sql.AddParameter("@Gender", row.Cells[2].Text);
                    sql.AddParameter("@Loft", row.Cells[3].Text);
                    sql.AddParameter("@Spect_desc", row.Cells[4].Text);
                    sql.AddParameter("@Spect_value_dec", row.Cells[5].Text);
                    sql.spWeb_SetSpects();

                    LbErrors.Text = sql.Errors;
                    GridView3.DeleteRow(row.RowIndex);
                    GridView3.DataBind();
                    if (LbErrors.Text == "")
                    {
                        CONTADOR = CONTADOR + 1;
                    }
                    else
                    {
                        row1 = errores.NewRow();
                        row1["MODEL"] = row.Cells[0].Text;
                        row1["OPERATION"] = row.Cells[1].Text;
                        row1["DESCRIPTION"] = row.Cells[4].Text;
                        row1["ERROR"] = LbErrors.Text;
                        errores.Rows.Add(row1);
                        if (errores.Rows.Count > 50)
                        {
                            LbErrors.Text = "Too many errors in the file";
                            break;
                        }
                    }
                }
                
                LbInsertados.Text = CONTADOR.ToString() + " records were inserted";
                if (errores.Rows.Count > 0)
                {
                    LbMensaje.Text = "Errors were found in the following items: ";
                    GridView3.Visible = true;
                    GridView3.DataSource = errores;
                    GridView3.DataBind();

                }
                else
                {
                    LbMensaje.Text = "";
                    GridView3.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        public void Gridview1_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void BtnReadFile_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/App_Data/");
            LbErrors.Text = "";
            LbMensaje.Text = "";
            GridView3.DataSource = null;
            GridView3.DataBind();
            //String path = "C:\\CallawayDATA\\";
            if (FileUpload1.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
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
                    if (File.Exists(path + "Limits.xls"))
                        File.Delete(path + "Limits.xls");
                    //FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                    FileUpload1.PostedFile.SaveAs(path + "Limits.xls");
                    Label3.Text = "File uploaded!";
                    LeerExcell();
                    BnSave.Visible = true;
                }
                catch (Exception ex)
                {
                    Label3.Text = "File could not be uploaded." + ex.ToString();
                }
            }
            else
            {
                Label3.Text = "Cannot accept files of this type.";
            }
        }
        private void LeerExcell()
        {
            try
            {
                //En DataSource especificas la ruta del archivo 

                //string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=|DataDirectory|\Limits.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=No;IMEX=1" + '"';


                string CadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=|DataDirectory|\Limits.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0" + '"';

                DataTable myTable = new DataTable();
                myTable.Columns.Add("MODEL", typeof(String));
                myTable.Columns.Add("OPERATION", typeof(String));
                myTable.Columns.Add("GENDER", typeof(String));
                myTable.Columns.Add("LOFT", typeof(String));
                myTable.Columns.Add("DESCRIPTION", typeof(String));
                myTable.Columns.Add("SPECT", typeof(String));

                //myTable.Columns.Add("Model", typeof(String));
                //myTable.Columns.Add("Gender", typeof(String));
                //myTable.Columns.Add("Varilla", typeof(String));
                ////myTable.Columns.Add("Estación", typeof(Int16));
                //myTable.Columns.Add("Tipo", typeof(String));
                //myTable.Columns.Add("Loft", typeof(String));
                //myTable.Columns.Add("Lie", typeof(String));
                //myTable.Columns.Add("Tip Cut", typeof(String));
                //myTable.Columns.Add("Butt Cut", typeof(String));
                //myTable.Columns.Add("SW", typeof(String));
                //myTable.Columns.Add("Ferrule", typeof(Int64));
                //myTable.Columns.Add("Profundidad", typeof(String));
                //DataTable myTable2 = new DataTable();
                //myTable2.Columns.Add("Model_Id", typeof(String));
                //myTable2.Columns.Add("Operation_id", typeof(String));
                //myTable2.Columns.Add("Gender", typeof(String));
                //myTable2.Columns.Add("Tipo", typeof(Int16));
                //myTable2.Columns.Add("Limite_Desc", typeof(String));
                //myTable2.Columns.Add("Limite_Valor_Desc", typeof(String));


                using (OleDbConnection con = new OleDbConnection(CadenaConexion))
                {
                    try
                    {

                        //Usuario y dirección son columnas en la hoja de excel 
                        //string strSQL = "SELECT Model, Gender, Varilla, Tipo, Loft, Lie, [Tip Cut], [Butt Cut], SW, Ferrule, Profundidad FROM [Sheet1$]";
                        string strSQL = "SELECT MODEL, OPERATION, GENDER, LOFT, DESCRIPTION, SPECT FROM [Sheet1$]";

                        OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);


                        da.Fill(myTable);
                        GridView3.DataSource = myTable;
                        GridView3.DataBind();

                        //string Model;                
                        //string Gender;
                        //string tipo;
                        //string loft;
                        //string lie;
                        //string ButtCut;
                        //string TipCut;
                        //string SW;
                        //string Ferrule;
                        //string Profundidad;

                        //foreach (DataRow row in myTable.Select())
                        //{
                        //    Model = row["Model"].ToString();
                        //    Gender = "V" + row["Gender"].ToString() + row["Varilla"].ToString();
                        //    tipo = row["Tipo"].ToString();
                        //    loft = row["Loft"].ToString();
                        //    lie = row["Lie"].ToString();
                        //    TipCut = row["Tip Cut"].ToString();
                        //    ButtCut = row["Butt Cut"].ToString();
                        //    Ferrule = row["Ferrule"].ToString();
                        //    SW = row["SW"].ToString();
                        //    Profundidad = row["Profundidad"].ToString();
                        //    if (loft != "")
                        //    {
                        //        myTable2.Rows.Add(Model, DropDownList1.SelectedValue, Gender, tipo, "LOFT", loft);
                        //    }
                        //    if (lie != "")
                        //    {
                        //        myTable2.Rows.Add(Model, DropDownList2.SelectedValue, Gender, tipo, "LIE", lie);
                        //    }
                        //    if (TipCut != "")
                        //    {
                        //        myTable2.Rows.Add(Model, DropDownList3.SelectedValue, Gender, tipo, "TIP CUT", TipCut);
                        //    }
                        //    if (ButtCut != "")
                        //    {
                        //        myTable2.Rows.Add(Model, DropDownList4.SelectedValue, Gender, tipo, "BUTT CUT", ButtCut);
                        //    }
                        //    if (SW != "")
                        //    {
                        //        myTable2.Rows.Add(Model, DropDownList5.SelectedValue, Gender, tipo, "BALANCEO", SW);
                        //    }
                        //    if (Ferrule != "")
                        //    {
                        //        myTable2.Rows.Add(Model, DropDownList6.SelectedValue, Gender, tipo, "FERRULE", Ferrule);

                        //    }
                        //    if (Profundidad != "")
                        //    {
                        //        myTable2.Rows.Add(Model, DropDownList7.SelectedValue, Gender, tipo, "PROFUNDIDAD", Profundidad);
                        //    }

                        //}
                        //GridView1.DataBind();



                        //GridView2.DataSource = myTable2;
                        //GridView2.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Label3.Text = ex.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Label3.Text = ex.ToString();
            }

        }

        protected void LoadPageAddRW()
        {
                if (!myTable.Columns.Contains("Raw_Material"))
                {
                    myTable.Columns.Add("RAW_MATERIAL", typeof(String));
                    myTable.Columns.Add("DESCRIPTION", typeof(String));
                    myTable.Columns.Add("RL", typeof(String));
                    myTable.Columns.Add("MODEL", typeof(String));
                    myTable.Columns.Add("LOFT", typeof(String));
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
                string strSQL = "SELECT RAW_MATERIAL, DESCRIPTION, RL, MODEL, LOFT, MATERIAL, ISBLEND, CATEGORY, GENDER FROM [Sheet1$]";

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
                    if (row["CATEGORY"].ToString() == "HD")
                    {
                        SQL sql = new SQL();
                        sql.Base();
                        sql.AddParameter("@Model_Id", row["MODEL"].ToString());
                        DataSet DS = sql.SpWeb_GetModelExists();
                        if (Convert.ToInt16(DS.Tables[0].Rows[0][0]) == 0)
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
                    ButtonSRW.Visible = false;
                    GridViewRW2.DataSource = TablaModelsNoGuardados;
                    GridViewRW2.DataBind();
                    GridViewRW1.Visible = false;
                }
                else
                {
                    GridViewRW2.Visible = false;
                    ButtonSRW.Visible = true;
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
                    sql.AddParameter("@Loft", dr["LOFT"].ToString().ToUpper());
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
                    else
                    {
                        row1 = errores.NewRow();
                        row1["RAW_MATERIAL"] = dr["RAW_MATERIAL"].ToString();
                        row1["ERROR"] = LbErrors.Text;
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
                LbErrors1.Text = ex.ToString();
            }
        }
        protected void ClearGrids()
        {
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
                LbModel.Text = GridViewRW2.SelectedRow.Cells[2].Text;
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

        protected void BtnAB(object sender, EventArgs e)
        {
            LbMessage.Text = "";
            Boolean fileOK = false;
            String path = Server.MapPath("~/App_Data/");
            //String path = "C:\\CallawayDATA\\";
            if (BtnBrowserAB.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(BtnBrowserAB.FileName).ToLower();
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
                    //ClearGrids();
                    if (File.Exists(path + "Product.xls"))
                        File.Delete(path + "Product.xls");
                    //FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                    BtnBrowserAB.PostedFile.SaveAs(path + "Product.xls");
                    Label1.Text = "File uploaded!";
                    LeerExcellAB();
                    //BnSave.Visible = true;
                }
                catch (Exception ex)
                {
                    Label1.Text = "File could not be uploaded." + ex.ToString();
                }
            }
            else
            {
                Label1.Text = "Cannot accept files of this type.";
            }
        }

        private void LeerExcellAB()
        {
            try
            {


                //En DataSource especificas la ruta del archivo 
                //string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=|DataDirectory|\Product.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1" + '"';
                string CadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=|DataDirectory|\Product.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0" + '"';


                DataTable myTable = new DataTable();
                myTable.Columns.Add("PRODUCT", typeof(String));
                myTable.Columns.Add("RAW_MATERIAL", typeof(String));




                OleDbConnection con = new OleDbConnection(CadenaConexion);

                //Usuario y dirección son columnas en la hoja de excel 
                //string strSQL = "SELECT Model, Gender, Varilla, Tipo, Loft, Lie, [Tip Cut], [Butt Cut], SW, Ferrule, Profundidad FROM [Sheet1$]";
                string strSQL = "SELECT PRODUCT, RAW_MATERIAL FROM [Sheet1$]";

                OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                da.Fill(myTable);
                GridViewAB1.DataSource = myTable;
                GridViewAB1.DataBind();


                DataView view = new DataView(myTable);
                DataTable distinctValues = view.ToTable(true, "RAW_MATERIAL");

                //GridView2.DataSource = distinctValues;
                //GridView2.DataBind();


                DataTable TablaModelsNoGuardados = new DataTable();
                DataColumn column1;
                DataColumn column2;

                DataRow row1;
                // DataView view1;
                column1 = new DataColumn();
                column1.DataType = Type.GetType("System.String");
                column1.ColumnName = "RAW_MATERIAL";

                TablaModelsNoGuardados.Columns.Add(column1);


                column2 = new DataColumn();
                column2.DataType = Type.GetType("System.String");
                column2.ColumnName = "ERROR";
                TablaModelsNoGuardados.Columns.Add(column2);

                foreach (DataRow row in distinctValues.Select())
                {
                    SQL sql = new SQL();
                    sql.Base();
                    sql.AddParameter("@RawMaterial_ID", row["RAW_MATERIAL"].ToString());
                    DataSet DS = sql.SpWeb_GetRawMaterialExists();
                    if (Convert.ToInt16(DS.Tables[0].Rows[0][0]) == 0)
                    {
                        row1 = TablaModelsNoGuardados.NewRow();
                        row1["RAW_MATERIAL"] = row["RAW_MATERIAL"].ToString();
                        row1["ERROR"] = "Model no exists";
                        TablaModelsNoGuardados.Rows.Add(row1);
                    }

                }
                if (TablaModelsNoGuardados.Rows.Count > 0)
                {
                    //DataView view1 = new DataView(TablaModelsNoGuardados);
                    //DataTable distinctValues1 = view.ToTable(true, "Raw_Material", "ERROR");

                    GridViewAB2.Visible = true;
                    BtnSaveAB.Visible = false;
                    GridViewAB2.DataSource = TablaModelsNoGuardados;
                    GridViewAB2.DataBind();
                    GridViewAB1.Visible = false;
                }
                else
                {
                    GridViewAB2.Visible = false;
                    BtnSaveAB.Visible = true;
                    GridViewAB1.Visible = true;
                }

            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
            }

        }

        protected void BnSaveAB(object sender, EventArgs e)
        {
            try
            {
                DataTable errores = new DataTable();
                errores.Columns.Add("PRODUCT", typeof(String));
                errores.Columns.Add("RAW_MATERIAL", typeof(String));
                errores.Columns.Add("ERROR", typeof(String));
                DataRow row1;
                foreach (GridViewRow row in GridViewAB1.Rows)
                {


                    SQL sql = new SQL();
                    sql.Base();
                    sql.AddParameter("@product_ID", row.Cells[0].Text);
                    sql.AddParameter("@RawMaterial", row.Cells[1].Text);

                    sql.spWeb_SetBOM();
                    LbErrors.Text = sql.Errors;
                    //GridView1.DeleteRow(row.RowIndex);
                    //GridView1.DeleteRow(row.RowIndex);
                    if (LbErrors.Text == "")
                    {
                        GridViewAB1.Visible = false;
                        LbMessage.Text = "Raw Materials Saved ok.";
                    }
                    else
                    {
                        row1 = errores.NewRow();
                        row1["PRODUCT"] = row.Cells[1].Text;
                        row1["RAW_MATERIAL"] = row.Cells[1].Text;
                        row1["ERROR"] = LbErrors.Text;
                        errores.Rows.Add(row1);
                    }
                }
                if (errores.Rows.Count > 0)
                {
                    LbMessage.Text = "Errors were found in the following elements: ";
                    GridViewAB3.Visible = true;
                    GridViewAB3.DataSource = errores;
                    GridViewAB3.DataBind();

                }
                else
                {
                    GridViewAB3.Visible = false;

                }
            }
            catch (Exception ex)
            {
                LbMessage.Text = "";
                LbErrors.Text = ex.ToString();
            }

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

    }
}