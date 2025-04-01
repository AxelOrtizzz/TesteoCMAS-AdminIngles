using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CallawayWeb
{
    public class SQL:Base_Service

    {
        public DataSet SpWeb_SetML()
        {
            return ReadDS("SpWeb_SetML");
        }
        public DataSet SpWeb_SetMLPutters()
        {
            return ReadDS("SpWeb_SetMLPutters");
        }
       
        public DataSet SpWeb_GetEmployeeStatus()
        {
            return ReadDS("SpWeb_GetEmployeeStatus");
           
        }

        public void spWeb_DelBOM()
        {
            Write("spWeb_DelBOM");
        }
        public DataSet SpWeb_GetBOM()
        {
            return ReadDS("SpWeb_GetBOM");
           
        }



        public DataSet SpWeb_GetGenders()
        {
            return ReadDS("SpWeb_GetGenders");
           
        }
        
        public void SpWeb_DelModels()
        {
            Write("SpWeb_DelModels");
        }

        public void SpWeb_SetModel()
        {
            Write("SpWeb_SetModel");
        }
        public void spWeb_SetRawMaterial()
        {
            Write("spWeb_SetRawMaterial");
        }
        public void spWeb_SetRawMaterial2()
        {
            Write("spWeb_SetRawMaterial2");
        }
        public void SpWeb_SetEmployeeOperation()
        {
            Write("SpWeb_SetEmployeeOperation");
        }
        
        public void spWeb_SetSpec()
        {
            Write("spWeb_SetSpec");
        }
        public void SpWeb_SetEmployee()
        {
            Write("SpWeb_SetEmployee");
        }
        
        public void SpWeb_DelRawMaterial()
        {
            Write("SpWeb_DelRawMaterial");
        }
        public void SpWeb_DelEmployee()
        {
            Write("SpWeb_DelEmployee");
        }
        
        public void SpWeb_DelSpect()
        {
            Write("SpWeb_DelSpect");
        }
        public void SpWeb_DelTolerances()
        {
            Write("SpWeb_DelTolerances");
        }

        public DataSet SpWeb_GetModels()
        {
            return ReadDS("SpWeb_GetModels");
           
        }

        public DataSet SpWeb_GetEmployeeOperations()
        {
            return ReadDS("SpWeb_GetEmployeeOperations");

        }
        public DataSet SpWeb_GetSpecs()
        {
            return ReadDS("SpWeb_GetSpecs");

        }
        public DataSet SpWeb_GetOperationsXarea()
        {
            return ReadDS("SpWeb_GetOperationsXarea");

        }
        
        public DataSet SpWeb_GetRawMaterials()
        {
            return ReadDS("SpWeb_GetRawMaterials");

        }
        public DataSet SpWeb_GetAreas()
        {
            return ReadDS("SpWeb_GetAreas");
        }



        public DataSet SpWeb_GetEmployees()
        {
            return ReadDS("SpWeb_GetEmployees");

        }
      
        public DataSet SpWeb_GetOperations()
        {
            return ReadDS("SpWeb_GetOperations");

        }
        public DataSet SpWeb_GetLines()
        {
            return ReadDS("SpWeb_GetLines");

        }

        public DataSet spWeb_GetSpecsXmodel()
        {
            return ReadDS("spWeb_GetSpecsXmodel");
        }
        
        public void SpWeb_UpdtRawMaterials()
        {
            Write("SpWeb_UpdtRawMaterials");

        }
        public DataSet spWeb_GetOrderResults()
        {
            return ReadDS("spWeb_GetOrderResults");
        }

        public DataSet SpWeb_GetTestsResults()
        {
            return ReadDS("SpWeb_GetTestsResults");
        }

        public void SpWeb_UpdtSpec()
        {
            Write("SpWeb_UpdtSpec");
        }
        public DataSet SpWeb_GetRework()
        {
            return ReadDS("SpWeb_GetRework");
        }

        public DataSet spWeb_GetOrderOperationQty()
        {
            return ReadDS("spWeb_GetOrderOperationQty");
        }
       

        public void SpWeb_UpdExtensiones()
        {
            Write("SpWeb_UpdExtensiones");
        }
        
        public void spWeb_SetSpects()
        {
            Write("spWeb_SetSpects");
        }
        public DataSet SpWeb_GetModelExists()
        {
            return ReadDS("SpWeb_GetModelExists");
        }
        public DataSet SpWeb_GetRawMaterialExists()
        {
            return ReadDS("SpWeb_GetRawMaterialExists");
        }
        public DataSet SpWeb_GetFraction()
        {
            return ReadDS("SpWeb_GetFraction");
        }
        
        public void spWeb_SetBOM()
        {
            Write("spWeb_SetBOM");
        }
      

        public void SpWeb_SetTolerance()
        {
            Write("SpWeb_SetTolerance");
        }
        public void SpWeb_DelOperationEmployee()
        {
            Write("SpWeb_DelOperationEmployee");
        }
        
        public DataSet SpWeb_GetTolerances()
        {
            return ReadDS("SpWeb_GetTolerances");
        }

        public DataSet SpWeb_GetPartsImagesReport()
        {
            return ReadDS("SpWeb_GetPartsImagesReport");
        }
        public DataSet SpWeb_GetEmployeeOrder()
        {
            return ReadDS("SpWeb_GetEmployeeOrder");
        }
        public DataSet SpWeb_GetExtensions()
        {
            return ReadDS("SpWeb_GetExtensions");
        }
        public DataSet SpWeb_GetEmployee_Extensions()
        {
            return ReadDS("SpWeb_GetEmployee_Extensions");
        }
        public DataSet SpWeb_GetExtensions1()
        {
            return ReadDS("SpWeb_GetExtensions1");
        }
        
    }
}