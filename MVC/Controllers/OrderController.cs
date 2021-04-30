using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            IEnumerable<mvcOderModel> ordList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Order").Result;
            ordList = response.Content.ReadAsAsync<IEnumerable<mvcOderModel>>().Result;
            return View(ordList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id==0)
                return View(new mvcOderModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Order/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcOderModel>().Result);

            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcOderModel ord)
        {
            if (ord.ORDERID == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Order", ord).Result;
                TempData["SuccessMessage"] = "Saved Successfully!!!";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Order/"+ord.ORDERID, ord).Result;
                TempData["SuccessMessage"] = "updated Successfully!!!";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Order/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "deleted Successfully!!!";
            return RedirectToAction("Index");
        }
    }
}