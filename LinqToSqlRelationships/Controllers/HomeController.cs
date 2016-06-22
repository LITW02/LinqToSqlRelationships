using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToSqlRelationships.Models;
using PersonCars.Data;

namespace LinqToSqlRelationships.Controllers
{
    public class MySession
    {
        private Dictionary<int, Dictionary<string, object>> _session = new Dictionary<int, Dictionary<string, object>>();
        private static int _id = 0;

        public int NewSession()
        {
            _id++;
            _session.Add(_id, new Dictionary<string, object>());
            return _id;
        }

        public Dictionary<string, object> GetSession(int id)
        {
            return _session[id];
        } 

    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Session["cartId"] = 100;

            //if (Session["cartId"] != null)
            //{
            //    int x = (int)Session["cartId"];    
            //}
            var repo = new PersonRepository(Properties.Settings.Default.ConStr);
            return View(new IndexViewModel { People = repo.GetPeople() });
        }
        
        public ActionResult AddCar(int personId)
        {
            var repo = new PersonRepository(Properties.Settings.Default.ConStr);
            return View(new AddCarViewModel { Person = repo.GetById(personId) });
        }

        [HttpPost]
        public ActionResult AddCar(Car car)
        {
            var repo = new CarsRepository(Properties.Settings.Default.ConStr);
            repo.AddCar(car);
            return Redirect("/home/index");
        }

    }
}
