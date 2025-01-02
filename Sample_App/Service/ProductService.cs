using Newtonsoft.Json;
using Sample_App.Models;
using System.Data;

namespace Sample_App.Service
{
    public class ProductService
    {
        Helper helper = new Helper();
        public string GetCategoryList(Product product)
        {
            var resp = string.Empty;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                DataTable dt = new DataTable();

                dictionary.Add("@CRUD", "CATEGORIES");
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
        public string GetTableData(Product product)
        {
            var resp = string.Empty;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                DataTable dt = new DataTable();

                dictionary.Add("@PRODUCTID", product.PRODUCTID);
                dictionary.Add("@CRUD", "READ");
                dt = helper.getData_Datatable(dictionary, "PRODUCTMASTER_CRUD");

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
        public string SubmitData(Product product)
        {
            var resp = string.Empty;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                DataTable dt = new DataTable();

                dictionary.Add("@PRODUCTID", product.PRODUCTID);
                dictionary.Add("@CATEGORYID", product.CATEGORYID);
                dictionary.Add("@PRODUCTNAME", product.PRODUCTNAME);
                dictionary.Add("@DESCRIPTION", product.DESCRIPTION);
                dictionary.Add("@CRUD", "CREATE");
                dt = helper.getData_Datatable(dictionary, "PRODUCTMASTER_CRUD");

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
        public string DeleteData(Product product)
        {
            var resp = string.Empty;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                DataTable dt = new DataTable();

                dictionary.Add("@PRODUCTID", product.PRODUCTID);
                dictionary.Add("@CRUD", "DELETE");
                dt = helper.getData_Datatable(dictionary, "PRODUCTMASTER_CRUD");

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
