using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Linq;

namespace CallawayWeb
{
    public partial class AltaLimitesML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LbMensaje.Text = "";
            Boolean fileOK = false;
            //String path = Server.MapPath("~/");
            String path = Server.MapPath("~/App_Data/");
            LbPath.Text = path;
            //String path = "C:\\CallawayDATA\\";
            if (BtnBrowser.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(BtnBrowser.FileName).ToLower();
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
                    if (File.Exists(path + "ML.xls"))
                        File.Delete(path + "ML.xls");
                    //FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                    BtnBrowser.PostedFile.SaveAs(path + "ML.xls");
                    
                    Preview();
                    //LeerExcell1();
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
        private void Preview()
        {
            try
            {
                if (CheckBox1.Checked == false)
                {
                    //En DataSource especificas la ruta del archivo 
                    // string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=|DataDirectory|\SETS.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;Importmixedtypes=text;typeguessrows=0" + '"';
                    string CadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=|DataDirectory|\ML.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0" + '"';
                    DataTable myTable = new DataTable();
                    myTable.Columns.Add("Club Loft", typeof(String));
                    myTable.Columns.Add("Club Part Number", typeof(String));
                    myTable.Columns.Add("Material Description", typeof(String));
                    myTable.Columns.Add("Flex", typeof(String));
                    myTable.Columns.Add("Swing Weight (points) ± 1", typeof(String));
                    myTable.Columns.Add("Overall Club Weight (grams) +/- 5", typeof(String));
                    myTable.Columns.Add("*(1) Tip Cut  Length (inches) +/- 1/16", typeof(String));
                    myTable.Columns.Add("**(2) Cut Shaft Length (inches) +/- 1/16", typeof(String));
                    myTable.Columns.Add("USGA Club Length 2 (inches) +/- 1/16", typeof(String));
                    myTable.Columns.Add("Club Loft (Degrees) +/- 1", typeof(String));
                    myTable.Columns.Add("Club Lie (Degrees) +/- 1", typeof(String));
                    //myTable.Columns.Add("Resultado", typeof(String));
                    OleDbConnection con = new OleDbConnection(CadenaConexion);

                    //Usuario y dirección son columnas en la hoja de excel 
                    //string strSQL = "SELECT Model, Gender, Varilla, Tipo, Loft, Lie, [Tip Cut], [Butt Cut], SW, Ferrule, Profundidad FROM [Sheet1$]";
                    string strSQL = "SELECT [Club Loft], [Club Part Number], [Material Description], [Flex], [Swing Weight (points) ± 1], [Overall Club Weight (grams) +/- 5], [*(1) Tip Cut  Length (inches) +/- 1/16], [**(2) Cut Shaft Length (inches) +/- 1/16], [USGA Club Length 2 (inches) +/- 1/16], [Club Loft (Degrees) +/- 1], [Club Lie (Degrees) +/- 1] FROM [Maderas$]";

                    OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);
                    da.Fill(myTable);
                    int i = 0;
                    GridView2.DataSource = myTable;
                    GridView2.DataBind();
                    GridView2.Visible = true;
                    BnSave.Visible = true;
                }
                else
                {
                    //En DataSource especificas la ruta del archivo 
                    // string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=|DataDirectory|\SETS.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;Importmixedtypes=text;typeguessrows=0" + '"';
                    string CadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=|DataDirectory|\ML.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0" + '"';
                    DataTable myTable = new DataTable();
                    myTable.Columns.Add("Model", typeof(String));
                    myTable.Columns.Add("**Length Inches ± 1/8", typeof(String));
                    myTable.Columns.Add("*Finished Cut Shaft Length Inches  ±1/16", typeof(String));
                    myTable.Columns.Add("Club Weight grams, ± 10 Reference", typeof(String));
                    myTable.Columns.Add("Club Loft ± 1 deg", typeof(String));
                    myTable.Columns.Add("Club Lie ± 1 deg", typeof(String));
                    myTable.Columns.Add("Shaft Offset ±056", typeof(String));
                    myTable.Columns.Add("Finished Club Part Number", typeof(String));
                    myTable.Columns.Add("Material Description", typeof(String));
                    
                    //myTable.Columns.Add("Resultado", typeof(String));
                    OleDbConnection con = new OleDbConnection(CadenaConexion);

                    //Usuario y dirección son columnas en la hoja de excel 
                    //string strSQL = "SELECT Model, Gender, Varilla, Tipo, Loft, Lie, [Tip Cut], [Butt Cut], SW, Ferrule, Profundidad FROM [Sheet1$]";
                    string strSQL = "SELECT [Model], [**Length Inches ± 1/8], [*Finished Cut Shaft Length Inches  ±1/16], [Club Weight grams, ± 10 Reference], [Club Loft ± 1 deg], [Club Lie ± 1 deg], [Shaft Offset ±056], [Finished Club Part Number], [Material Description] FROM [Putters$]";

                    OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);
                    da.Fill(myTable);
                    int i = 0;
                    GridView2.DataSource = myTable;
                    GridView2.DataBind();
                    GridView2.Visible = true;
                    BnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {
                LbErrors.Text = ex.ToString();
            }

        }
        private void LeerExcell1()
        {
            try
            {
                if (CheckBox1.Checked == false)
                {

                    //En DataSource especificas la ruta del archivo 
                    // string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=|DataDirectory|\SETS.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;Importmixedtypes=text;typeguessrows=0" + '"';
                    string CadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=|DataDirectory|\ML.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0" + '"';


                    DataTable myTable = new DataTable();
                    myTable.Columns.Add("Club Loft", typeof(String));
                    myTable.Columns.Add("Club Part Number", typeof(String));
                    myTable.Columns.Add("Material Description", typeof(String));
                    myTable.Columns.Add("Flex", typeof(String));
                    myTable.Columns.Add("Swing Weight (points) ± 1", typeof(String));
                    myTable.Columns.Add("Overall Club Weight (grams) +/- 5", typeof(String));
                    myTable.Columns.Add("*(1) Tip Cut  Length (inches) +/- 1/16", typeof(String));
                    myTable.Columns.Add("**(2) Cut Shaft Length (inches) +/- 1/16", typeof(String));
                    myTable.Columns.Add("USGA Club Length 2 (inches) +/- 1/16", typeof(String));
                    myTable.Columns.Add("Club Loft (Degrees) +/- 1", typeof(String));
                    myTable.Columns.Add("Club Lie (Degrees) +/- 1", typeof(String));
                    myTable.Columns.Add("Resultado", typeof(String));
                    OleDbConnection con = new OleDbConnection(CadenaConexion);

                    //Usuario y dirección son columnas en la hoja de excel 
                    //string strSQL = "SELECT Model, Gender, Varilla, Tipo, Loft, Lie, [Tip Cut], [Butt Cut], SW, Ferrule, Profundidad FROM [Sheet1$]";
                    string strSQL = "SELECT [Club Loft], [Club Part Number], [Material Description], [Flex], [Swing Weight (points) ± 1], [Overall Club Weight (grams) +/- 5], [*(1) Tip Cut  Length (inches) +/- 1/16], [**(2) Cut Shaft Length (inches) +/- 1/16], [USGA Club Length 2 (inches) +/- 1/16], [Club Loft (Degrees) +/- 1], [Club Lie (Degrees) +/- 1] FROM [Maderas$]";

                    OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);





                    da.Fill(myTable);
                    int i = 0;
                    foreach (DataRow row in myTable.Select())
                    {
                        //int numberOfRecords = myTable.AsEnumerable().Where(x => x["PADRE"].ToString() == row["PADRE"].ToString()).ToList().Count;
                        //int numberOfRecords = myTable.ToString().ToList().Count;


                        SQL sql = new SQL();
                        sql.Base();
                        sql.AddParameter("@Club_Loft", row["Club Loft"].ToString());
                        sql.AddParameter("@Part_Number", row["Club Part Number"].ToString());
                        sql.AddParameter("@shaft_Material", row["Material Description"].ToString());
                        sql.AddParameter("@Flex", row["Flex"].ToString());
                        sql.AddParameter("@Swing_Weight", row["Swing Weight (points) ± 1"].ToString());
                        sql.AddParameter("@Overall_Club_Weight", row["Overall Club Weight (grams) +/- 5"].ToString());
                        sql.AddParameter("@Tip_Cut_Length", row["*(1) Tip Cut  Length (inches) +/- 1/16"].ToString());
                        sql.AddParameter("@Cut_Shaft_Length", row["**(2) Cut Shaft Length (inches) +/- 1/16"].ToString());
                        sql.AddParameter("@USGA_Club_Length", row["USGA Club Length 2 (inches) +/- 1/16"].ToString());
                        sql.AddParameter("@Club_Loft_degrees", row["Club Loft (Degrees) +/- 1"].ToString());
                        sql.AddParameter("@Club_Lie_degrees", row["Club Lie (Degrees) +/- 1"].ToString());
                        try {
                            DataSet DS = sql.SpWeb_SetML();
                            myTable.Rows[i]["Resultado"] = DS.Tables[0].Rows[0][0].ToString();
                        }
                        catch (Exception ex) 
                        {
                            LbErrors.Text = sql.Errors;
                        }
                        i++;

                    }

                    GridView1.DataSource = myTable;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    Label1.Text = "¡Saved Data!";
                }
                else
                {
                    //En DataSource especificas la ruta del archivo 
                    // string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=|DataDirectory|\SETS.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;Importmixedtypes=text;typeguessrows=0" + '"';
                    string CadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=|DataDirectory|\ML.xls;" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0" + '"';
                    DataTable myTable = new DataTable();
                    myTable.Columns.Add("Model", typeof(String));
                    myTable.Columns.Add("**Length Inches ± 1/8", typeof(String));
                    myTable.Columns.Add("*Finished Cut Shaft Length Inches  ±1/16", typeof(String));
                    myTable.Columns.Add("Club Weight grams, ± 10 Reference", typeof(String));
                    myTable.Columns.Add("Club Loft ± 1 deg", typeof(String));
                    myTable.Columns.Add("Club Lie ± 1 deg", typeof(String));
                    myTable.Columns.Add("Shaft Offset ±056", typeof(String));
                    myTable.Columns.Add("Finished Club Part Number", typeof(String));
                    myTable.Columns.Add("Material Description", typeof(String));

                    myTable.Columns.Add("Resultado", typeof(String));
                    OleDbConnection con = new OleDbConnection(CadenaConexion);

                    //Usuario y dirección son columnas en la hoja de excel 
                    //string strSQL = "SELECT Model, Gender, Varilla, Tipo, Loft, Lie, [Tip Cut], [Butt Cut], SW, Ferrule, Profundidad FROM [Sheet1$]";
                    string strSQL = "SELECT [Model], [**Length Inches ± 1/8], [*Finished Cut Shaft Length Inches  ±1/16], [Club Weight grams, ± 10 Reference], [Club Loft ± 1 deg], [Club Lie ± 1 deg], [Shaft Offset ±056], [Finished Club Part Number], [Material Description] FROM [Putters$]";

                    OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);
                    da.Fill(myTable);
                    int i = 0;

                    foreach (DataRow row in myTable.Select())
                    {
                        //int numberOfRecords = myTable.AsEnumerable().Where(x => x["PADRE"].ToString() == row["PADRE"].ToString()).ToList().Count;
                        //int numberOfRecords = myTable.ToString().ToList().Count;


                        SQL sql = new SQL();
                        sql.Base();
                        sql.AddParameter("@Model", row["Model"].ToString());
                        sql.AddParameter("@Length", row["**Length Inches ± 1/8"].ToString());
                        sql.AddParameter("@FinishedCut", row["*Finished Cut Shaft Length Inches  ±1/16"].ToString());
                        sql.AddParameter("@Weight", row["Club Weight grams, ± 10 Reference"].ToString());
                        sql.AddParameter("@ClubLoft", row["Club Loft ± 1 deg"].ToString());
                        sql.AddParameter("@ClubLie", row["Club Lie ± 1 deg"].ToString());
                        sql.AddParameter("@Shaft", row["Shaft Offset ±056"].ToString());
                        sql.AddParameter("@FinishedClub", row["Finished Club Part Number"].ToString());
                        sql.AddParameter("@shaft_MaterialDescription", row["Material Description"].ToString());

                        DataSet DS = sql.SpWeb_SetMLPutters();
                        myTable.Rows[i]["Resultado"] = DS.Tables[0].Rows[0][0].ToString();
                        i++;

                    }

                    GridView1.DataSource = myTable;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    Label1.Text = "¡Saved Data!";


                }

                }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
            }

        }

        protected void BnSave_Click(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            LeerExcell1();
        }       
    }
}