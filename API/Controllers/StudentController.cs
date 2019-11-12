using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

using API.Models;
using API.Repository;
using Domain;
using Service;

namespace API.Controllers
{
    public class StudentController : ApiController
    {

        StudentService Service;

        public StudentController()
        {
            Service = new StudentService();
        }        

        [HttpGet]
        public JsonResult<List<StudentModel>> GetAllStudents()
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();

            List<Student> studentList = Service.Get();
            List<StudentModel> Students = new List<StudentModel>();

            foreach (var item in studentList)
            {
                Students.Add(mapObj.Translate(item));

            }

            return Json<List<StudentModel>>(Students);

        }

        [HttpGet]
        public JsonResult<StudentModel> GetStudent(int Id)
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();

            Student dalStudent = Service.GetById(Id);
            StudentModel Student = new StudentModel();
            Student = mapObj.Translate(dalStudent);

            return Json<StudentModel>(Student);

        }
     
        [HttpGet]
        public JsonResult<List<StudentModel>> BusquedaStudents(string nombre)
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();

            List<Student> studentList = Service.Busqueda(nombre);
            List<StudentModel> Students = new List<StudentModel>();

            foreach (var item in studentList)
            {
                Students.Add(mapObj.Translate(item));

            }            

            return Json<List<StudentModel>>(Students);

        }

        [HttpPost]
        public bool InsertStudent(StudentModel Student)
        {

            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
                Student StudentObj = new Student();
                StudentObj = mapObj.Translate(Student);
                Service.Insert(StudentObj);
                status = true;
            }

            return status;

        }

        [HttpPut]
        public bool UpdateStudent(StudentModel Student)
        {

            bool status = false;            
            EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
            Student StudentObj = new Student();
            StudentObj = mapObj.Translate(Student);
            Service.Update(StudentObj);
            status = true;        
            return status;

        }

        [HttpDelete]
        public bool DeleteStudent(int id)
        {

            bool status = false;
            Service.Delete(id);
            status = true;
            return status;

        }
    }
}
