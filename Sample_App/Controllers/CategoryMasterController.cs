using Microsoft.AspNetCore.Mvc;
using Sample_App.Models;
using Sample_App.Service;

namespace Sample_App.Controllers
{
    public class CategoryMasterController : Controller
    {
        CategoryService service = new CategoryService();
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetTableData([FromBody] Category category)
        {
            try
            {
                var Resp = service.GetTableData(category);
                return new JsonResult(Resp);
            }
            catch (Exception ex)
            {

                return new JsonResult("Error" + ex.Message.ToString());
            }
        }
        public ActionResult SubmitData([FromBody] Category category)
        {
            try
            {
                var Resp = service.SubmitData(category);
                return new JsonResult(Resp);
            }
            catch (Exception ex)
            {

                return new JsonResult("Error" + ex.Message.ToString());
            }
        }
        public ActionResult DeleteData([FromBody] Category category)
        {
            try
            {
                var Resp = service.DeleteData(category);
                return new JsonResult(Resp);
            }
            catch (Exception ex)
            {

                return new JsonResult("Error" + ex.Message.ToString());
            }
        }
    }
}

