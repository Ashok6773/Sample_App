using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample_App.Models;
using System.Data;
using System.Reflection;

namespace Sample_App.Service
{
    public class CategoryService
    {
        Helper helper = new Helper();
        public string GetTableData(Category category)
        {
            var resp = string.Empty;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                DataTable dt = new DataTable();

                dictionary.Add("@CATEGORY_ID", category.CATEGORYID);
                dictionary.Add("@CRUD", "READ");
                dt = helper.getData_Datatable(dictionary, "MANAGECATEGORIES");

                if (dt.Rows.Count > 0)
                {
                    resp = JsonConvert.SerializeObject(dt);
                }
                else
                {
                    resp = "Error : Data not found";
                }

                return resp;
            }
            catch (Exception ex)
            {

                return "Error" + ex.Message.ToString();
            }
        }

        public string SubmitData(Category category)
        {
            var resp = string.Empty;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                DataTable dt = new DataTable();

                dictionary.Add("@CATEGORY_ID", category.CATEGORYID);
                dictionary.Add("@CATEGORY_NAME", category.CATEGORYNAME);
                dictionary.Add("@DESCRIPTION", category.DESCRIPTION);
                dictionary.Add("@CRUD", "CREATE");
                dt = helper.getData_Datatable(dictionary, "MANAGECATEGORIES");

                if (dt.Rows.Count > 0)
                {
                    resp = JsonConvert.SerializeObject(dt);
                }
                else
                {
                    resp = "Error : while saving data";
                }

                return resp;
            }
            catch (Exception ex)
            {

                return "Error" + ex.Message.ToString();
            }
        }
        public string DeleteData(Category category)
        {
            var resp = string.Empty;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                DataTable dt = new DataTable();

                dictionary.Add("@CATEGORY_ID", category.CATEGORYID);
                dictionary.Add("@CRUD", "DELETE");
                dt = helper.getData_Datatable(dictionary, "MANAGECATEGORIES");

                if (dt.Rows.Count > 0)
                {
                    resp = JsonConvert.SerializeObject(dt);
                }
                else
                {
                    resp = "Error : Data not found";
                }

                return resp;
            }
            catch (Exception ex)
            {

                return "Error" + ex.Message.ToString();
            }
        }


    }
}
