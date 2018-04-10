using ProveVarie.DataAccess;
using ProveVarie.Models;
using ProveVarie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProveVarie.Controllers
{
    public class CarnetController : Controller
    {
        private AppDbContext context = new AppDbContext();
        private IRepository<Carnet> _repository;
        private IRepository<CostCenter> _costCentersRepository;
        //private List<string> _costCenters;
        //private List<CostCenter> _costCenters;

        public CarnetController()
        {
            _repository = new CarnetEntityFrameworkRepository(context);
            _costCentersRepository = new CostCenterEntityFrameworkRepository(context);
        }

        //public CarnetController(IRepository<Carnet> repository,
        //                        IRepository<CostCenter> costCentersRepository)
        //{
        //    _repository = repository;
        //    _costCentersRepository = costCentersRepository;
        //    //_costCenters = _costCentersRepository
        //    //    .FindAll();
        //        //.Select(x => x.Name).ToList();
        //}



        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            var model = new Carnet();


            return View(model);
        }

        [HttpPost]
        public ActionResult Register(Carnet model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ID == 0)
            {
                model.RegistrationDate = DateTime.Now;
                _repository.Insert(model);
            }


            return RedirectToAction(nameof(Register));
        }

        [HttpGet]
        public ActionResult Assignment()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //var model = new Carnet();

            ViewData["_costCenters"] = _costCentersRepository.FindAll();

            //return View(model);
            return View();
        }

        //[HttpGet]
        //public ActionResult Assignment(int id)
        //{
        //    Carnet model;

        //    if (id == 0)
        //    {
        //        model = new Carnet();

        //    }
        //    else
        //    {
        //        model = _repository.Find(id);
        //        if (model == null)
        //        {
        //            return HttpNotFound();
        //        }
        //    }

        //    ViewData["costCenters"] = _costCentersRepository.FindAll();

        //    return View(model);
        //    // popolare dropdown
        //    //var model = new CostCenterDropdown()
        //    //{
        //    //    //ID = carnet.ID,
        //    //    //Name = employee.Name,
        //    //    CostCenters = _costCenters
        //    //    .Select(x => new SelectListItem
        //    //{
        //    //    Value = x.ID.ToString(),
        //    //    Text = x.Name
        //    //})
        //    //};
        //}

        [HttpPost]
        public ActionResult Assignment(Carnet model, CostCenterDropdown list)
        {
            model.AssignmentDate = DateTime.Now;
            model.CostCenter = (CostCenter)list.CostCenters.Where(x => x.Selected);
            model.CostCenterID = model.CostCenter.ID;

            var result = _repository.Update(model);

            if (!result)
                return new HttpNotFoundResult("Non c'è un blocchetto corrispondente");

            return RedirectToAction(nameof(Assignment));
        }

    }
}