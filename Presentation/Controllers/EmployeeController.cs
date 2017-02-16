using System.Web.Mvc;
using CodingChallenge.Application.Employees.Commands;
using CodingChallenge.Application.Employees.Queries;
using CodingChallenge.Persistence;

namespace CodingChallenge.Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGetEmployeeListQuery _employeeListQuery;
        private readonly IGetEmployeeQuery _employeeQuery;
        private readonly ICreateEmployeeCommand _createEmployeeCommand;

        public EmployeeController(IGetEmployeeListQuery getEmployeeListQuery, IGetEmployeeQuery getEmployeeQuery)
        {
            _employeeListQuery = getEmployeeListQuery;
            _employeeQuery = getEmployeeQuery;
        }

        public EmployeeController()
        {
            // ToDo: Implement IoC
            var databaseService = new DatabaseService();
            _employeeListQuery = new GetEmployeeListQuery(databaseService);
            _employeeQuery = new GetEmployeeQuery(databaseService);
            _createEmployeeCommand = new CreateEmployeeCommand(databaseService);
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
        public ActionResult Create([Bind(Include = "Name,Dependents")] EmployeeModel employeeModel)
        {
            try
            {
                _createEmployeeCommand.Execute(employeeModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employeeModel);
            }
        }
    }
}
