using PrjMVC.Models;
using System.Web.Mvc;

namespace PrjMVC.Controllers
{
    public partial class ProfileController : Controller
    {
        [HttpGet]
        public ActionResult ProfileList()
        {
            string connectionString = null;
            string providerName = null;

            ProfileListModel model = new ProfileListModel(connectionString, providerName);
            model.GetDataList();

            return View(model);
        }
    }
}