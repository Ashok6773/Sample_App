using Microsoft.AspNetCore.Mvc;
using Sample_App.Models;
using Sample_App.Service;

namespace Sample_App.Controllers
{
    public class ProductMasterController : Controller
    {
        ProductService service = new ProductService();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }
        public ActionResult GetCategoryList([FromBody] Product product)
        {
            try
            {
                var Resp = service.GetCategoryList(product);
                return new JsonResult(Resp);
            }
            catch (Exception ex)
            {

                return new JsonResult("Error" + ex.Message.ToString());
            }
        }
        public ActionResult GetTableData([FromBody] Product product)
        {
            try
            {
                var Resp = service.GetTableData(product);
                return new JsonResult(Resp);
            }
            catch (Exception ex)
            {

                return new JsonResult("Error" + ex.Message.ToString());
            }
        }
        public ActionResult SubmitData([FromBody] Product product)
        {
            try
            {
                var Resp = service.SubmitData(product);
                return new JsonResult(Resp);
            }
            catch (Exception ex)
            {

                return new JsonResult("Error" + ex.Message.ToString());
            }
        }
        public ActionResult DeleteData([FromBody] Product product)
        {
            try
            {
                var Resp = service.DeleteData(product);
                return new JsonResult(Resp);
            }
            catch (Exception ex)
            {

                return new JsonResult("Error" + ex.Message.ToString());
            }
        }

    }
}
