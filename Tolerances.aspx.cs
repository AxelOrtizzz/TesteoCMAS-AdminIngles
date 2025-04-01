using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallawayWeb
{
    public partial class Tolerances : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaModels1();
            }
        }
        private void CargaModels1()
        {
            SQL sql = new SQL();
            sql.Base();
            DDModels.DataSource = sql.SpWeb_GetModels();
            DDModels.DataTextField = "Model_Id";
            DDModels.DataValueField = "Model_Id";
            DDModels.DataBind();
            DDModels.SelectedIndex = 0;

        }
        private void TraerLimites()
        {
            DDLimites.Items.Clear();  // Limpiar el Dropdown
            SQL sql = new SQL();
            sql.Base();

            // Agregar parámetros si los checkboxes están marcados
            if (CheckBox1.Checked)
            {
                sql.AddParameter("@Model_Id", DDModels.SelectedValue);
            }
            if (CheckBox2.Checked)
            {
                sql.AddParameter("@Model_Id", TxSKU.Text);
            }

            // Obtener el DataSet
            DataSet ds = sql.spWeb_GetSpecsXmodel();

            // Validar si el DataSet tiene tablas y filas
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // Asegurarse de que la columna "Spec_desc" exista
                if (ds.Tables[0].Columns.Contains("Spec_desc"))
                {
                    // Asignar DataSource
                    DDLimites.DataSource = ds.Tables[0];  // Asignar primera tabla
                    DDLimites.DataTextField = "Spec_desc"; // Establecer el campo de texto
                    DDLimites.DataValueField = "Spec_desc"; // Establecer el campo de valor
                    DDLimites.DataBind();  // Realizar el bind
                }
                else
                {
                    DDLimites.Items.Add(new ListItem("Error: Columna no encontrada", ""));
                }
            }
            else
            {
                DDLimites.Items.Add(new ListItem("No hay datos disponibles", ""));
            }
        }

        private void clear()
        {
            DDModels.SelectedIndex = 0;
            CheckBox1.Checked = false;
            DDModels.Enabled = false;
            CheckBox2.Checked = false;
            TxSKU.Text = "";
            TxSKU.Enabled = false;
            DDLimites.Items.Clear();
            TxTolerance.Text = "";
            TxToleranceMin.Text = "";
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                DDModels.Enabled = true;
                CheckBox2.Checked = false;
                TxSKU.Text = "";
                TxSKU.Enabled = false;
               
            }
            else 
            {
                DDModels.SelectedIndex = 0;
                DDModels.Enabled = false;
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                TxSKU.Enabled = true;
                CheckBox1.Checked = false;
                DDModels.SelectedIndex = 0;
                DDModels.Enabled = false;
            }
            else
            {
                TxSKU.Text = "";
                TxSKU.Enabled = false;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
            TraerLimites();
            FillGrid();
        }
        protected void FillGrid()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            SQL sql = new SQL();
            sql.Base();
            if (CheckBox2.Checked)
                sql.AddParameter("@Model_Id", TxSKU.Text);
            else
                sql.AddParameter("@Model_Id", DDModels.SelectedValue);

            GridView1.DataSource = sql.SpWeb_GetTolerances();
            GridView1.DataBind();
        
        }
        protected void DDModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraerLimites();
            FillGrid();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            LbErrors.Text = "";
            SQL sql = new SQL();
            sql.Base();

            // Validar y convertir TxTolerance.Text a decimal
            decimal toleranceUp = 0;
            decimal toleranceDown = 0;

            // Validación de tolerancia superior
            if (!decimal.TryParse(TxTolerance.Text, out toleranceUp))
            {
                LbErrors.Text = "El valor de Tolerance Up no es un número válido o está fuera de formato.";
                return; // Detener la ejecución si hay un error de conversión
            }

            // Validación de tolerancia inferior
            if (!decimal.TryParse(TxToleranceMin.Text, out toleranceDown))
            {
                LbErrors.Text = "El valor de Tolerance Down no es un número válido o está fuera de formato.";
                return; // Detener la ejecución si hay un error de conversión
            }

            // Verificar si los valores tienen más de 5 decimales
            if (Math.Round(toleranceUp, 5) != toleranceUp || Math.Round(toleranceDown, 5) != toleranceDown)
            {
                LbErrors.Text = "Los valores de tolerancia deben tener un máximo de 5 decimales.";
                return; // Detener si los valores tienen más de 5 decimales
            }

            // Si la conversión es exitosa, agregar los parámetros a la consulta
            if (CheckBox2.Checked)
                sql.AddParameter("@model_ID", TxSKU.Text);
            else
                sql.AddParameter("@model_ID", DDModels.SelectedValue);

            sql.AddParameter("@Spec", DDLimites.SelectedValue);
            sql.AddParameter("@ToleranceUp", toleranceUp);   // Usar valores convertidos a decimal
            sql.AddParameter("@ToleranceDown", toleranceDown); // Usar valores convertidos a decimal

            sql.SpWeb_SetTolerance();

            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "")
            {
                FillGrid();
                clear();
            }
        }


        protected void BtnDelete_Click(object sender, EventArgs e)
        {
           LbErrors.Text="";
            SQL sql = new SQL();
            sql.Base();

            if (CheckBox2.Checked)
                sql.AddParameter("@model_id", TxSKU.Text);
            else
            sql.AddParameter("@model_id", DDModels.SelectedValue);
            sql.AddParameter("@Spec", DDLimites.SelectedValue);
           
            sql.SpWeb_DelTolerances();
            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "")
            {   
                FillGrid();
                clear();               
            }
            
        }

        }
    }
