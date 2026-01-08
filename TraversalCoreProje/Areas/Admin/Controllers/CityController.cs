using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination) 
        {
            destination.Status = true;
            destination.Image = "Unknown";
            destination.Description = "Unknown";
            destination.CoverImage = "Unknown";
            destination.Details1 = "Unknown";
            destination.Details2 = "Unknown";
            destination.Image2 = "Unknown";
            
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonvalues = JsonConvert.SerializeObject(values);
            return Json(jsonvalues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination) 
        {
            destination.Status = true;
            destination.Image = "Unknown";
            destination.Price = 1000;
            destination.Capacity = 10;
            destination.Description = "Unknown";
            destination.CoverImage = "Unknown";
            destination.Details1 = "Unknown";
            destination.Details2 = "Unknown";
            destination.Image2 = "Unknown";
            _destinationService.TUpdate(destination);
            var v =JsonConvert.SerializeObject(destination);
            return Json(v);

        }

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID = 1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityID = 2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //    new CityClass
        //    {
        //        CityID = 3,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //    }
        //};


    }
}
