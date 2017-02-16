using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodingChallenge.Application.Employees.Queries;
using CodingChallenge.Persistence;

namespace CodingChallenge.Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGetEmployeeListQuery _employeeListQuery;
        private readonly IGetEmployeeQuery _employeeQuery;

        public EmployeeController(IGetEmployeeListQuery getEmployeeListQuery, IGetEmployeeQuery getEmployeeQuery)
        {
            _employeeListQuery = getEmployeeListQuery;
            _employeeQuery = getEmployeeQuery;
        }

        public EmployeeController()
        {
            var databaseService = new DatabaseService();
            _employeeListQuery = new GetEmployeeListQuery(databaseService);
            _employeeQuery = new GetEmployeeQuery(databaseService);
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employeeModels = _employeeListQuery.Execute();
            return View(employeeModels);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employeeModel = _employeeQuery.Execute(id);
            return View(employeeModel);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Dependents")] EmployeeModel employe)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
