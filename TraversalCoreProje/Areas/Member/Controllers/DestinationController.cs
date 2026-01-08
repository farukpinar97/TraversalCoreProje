using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{

    [Area("Member")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        //public IActionResult GetCitiesSearchByName(string searchString) 
        //{
        //    ViewData["CurrentFilter"] = searchString;
        //    var values = from x in destinationManager.TGetList() select x;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        values = values.Where(y => y.City.Contains(searchString));
        //    }
        //    return View(values.ToList());
        //}
        public IActionResult GetCitiesSearchByName(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var values = destinationManager.TGetList();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                values = values
                    .Where(y => y.City
                    .Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(values);
        }
    }
}
