using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SB.Models;
using SB.Extensions;
using static SB.Models.Customer;

namespace SB.Controllers
{

    public class CustomersController : Controller
    {
        private SBData db = new SBData();


        // GET: Customers
        // [Authorize(Roles = "Seller")]
        public ActionResult Index(int? sellerId, string searchName, string genreId, string cityId, string regionId, string classificationId, string customerSellerId, string dateStart, string dateEnd)
        {
            var role = User.GetRole();
            var id = User.GetId();
            
            var customers = from c in db.Customer.Include("Classification").Include("Gender").Include("User")
                            select c;

            #region filters
           
            if (!String.IsNullOrEmpty(searchName))
            {
                customers = customers.Where(s => s.Name.Contains(searchName));
            }
            if (!String.IsNullOrEmpty(genreId))
            {
                var genderEnum = (GenderEnum)Enum.Parse(typeof(GenderEnum), genreId);
                customers = customers.Where(s => s.GenderId ==  (int)genderEnum);
            }
            if (!String.IsNullOrEmpty(cityId))
            {
                var idCity = int.Parse(cityId);
                customers = customers.Where(s => s.CityId == idCity);
            }
            if (!String.IsNullOrEmpty(regionId))
            {
                var idRegion = int.Parse(regionId);
                customers = customers.Where(s => s.RegionId ==idRegion );
            }
            if (!String.IsNullOrEmpty(classificationId))
            {
                var idClass = int.Parse(classificationId);
                customers = customers.Where(s => s.ClassificationId == idClass);
            }
            if (!String.IsNullOrEmpty(customerSellerId))
            {
                var idSeller = int.Parse(customerSellerId);
                customers = customers.Where(s => s.UserId == idSeller);
            }
            if (!String.IsNullOrEmpty(dateStart))
            {
                DateTime enteredDate = DateTime.Parse(dateStart);
                customers = customers.Where(s => DbFunctions.TruncateTime(s.LastPurchase) >= enteredDate);
            }
            if (!String.IsNullOrEmpty(dateEnd))
            {
                DateTime enteredDate = DateTime.Parse(dateEnd);
                customers = customers.Where(s => DbFunctions.TruncateTime(s.LastPurchase) <= enteredDate);

            }

            #endregion

            #region viewbags

            ViewBag.Cities = new SelectList(db.City.ToList(), "Id", "Name");
            ViewBag.Regions = new SelectList(db.Region.ToList(), "Id", "Name");
            ViewBag.Classifications = new SelectList(db.Classification.ToList(), "Id", "Name");
            ViewBag.Sellers = new SelectList(db.UserSys.Where(x => x.UserRoleId != 1).ToList(), "Id", "Login");
            ViewBag.Role = role;
            ViewBag.UserName = User.GetFullName();

            #endregion


            if (sellerId.HasValue)
            {
                if (!(id == sellerId.Value.ToString()))
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "You are not authorized to access this controller action.");
                else
                    return View(customers.Where(x => x.UserId == sellerId.Value).ToList());
            }
            return View(customers.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
