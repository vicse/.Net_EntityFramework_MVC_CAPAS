//using Service;
using System.Linq;
using System.Web.Mvc;
//using Domain;
using MVCAJAX.Models;
using System.Threading.Tasks;
using System;

namespace MVCAJAX.Controllers
{    

    public class StudentController : Controller
    {
        //private StudentService service = new StudentService();
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();

        public ActionResult IndexRazor()
        {

            /*var model = (from c in service.Get()
                         select new StudentModel
                         {
                             ID = c.StundentID,
                             StudentAddress = c.StudentAddress,
                             StudentName = c.StudentName
                         }).ToList();*/

            var response = Task.Run(() => proxy.GetStudentsAsync());
            return View(response.Result.listado);
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent()
        {

            var response = Task.Run(() => proxy.GetStudentsAsync());
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
            //return Json( service.Get(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Busqueda(string nombre)
        {
            var response = Task.Run(() => proxy.BuscarStudentsAsync(nombre));
            return Json(response.Result.listado , JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult EstudentDetail(int Id)
        {

            var response = Task.Run(() => proxy.GetByIdAsync(Id));
            return Json(response.Result.objeto, JsonRequestBehavior.AllowGet);
            //return Json(service.GetById(Id), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult CreateStudent(StudentModel std)
        {
            std.FechaCreacion = DateTime.Today;
            //service.Insert(std);

            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;           
           
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }


        [HttpPost]
        public ActionResult UpdateStudent(StudentModel std)
        {
            std.FechaModificacion = DateTime.Today;
            //service.Update(std, Id);
            var response = Task.Run(() => proxy.UpdateAsync(std));
            string message = response.Result.Mensaje;

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }

        [HttpPost]
        public ActionResult DeleteStudent(int Id)
        {
            //service.Delete(Id);
            var response = Task.Run(() => proxy.DeleteStudentAsync(Id));
            string message = response.Result.Mensaje;

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }



    }
}