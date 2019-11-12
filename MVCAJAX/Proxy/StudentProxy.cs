using MVCAJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Text;

namespace MVCAJAX.Proxy
{
    public class StudentProxy
    {
        public async Task<ResponseProxy<StudentModel>> GetStudentsAsync()
        {

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/GetAllStudents");
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentModel>>(result);

                return new ResponseProxy<StudentModel>
                {
                    Exitoso = true,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                    listado = students
                };

            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }

        public async Task<ResponseProxy<StudentModel>> GetByIdAsync(int id)
        {

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/GetStudent", "/", id);

            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var student = JsonConvert.DeserializeObject<StudentModel>(result);

                return new ResponseProxy<StudentModel>
                {
                    Exitoso = true,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                    objeto = student
                };

            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }

        public async Task<ResponseProxy<StudentModel>> BuscarStudentsAsync(string dato)
        {

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/BusquedaStudents", "?nombre=", dato);

            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentModel>>(result);

                return new ResponseProxy<StudentModel>
                {
                    Exitoso = true,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                    listado = students
                };

            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }

        public async Task<ResponseProxy<StudentModel>> InsertAsync(StudentModel model)
        {

            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/InsertStudent");

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<StudentModel>
                {
                    Exitoso = exito,
                    Codigo = 0,
                    Mensaje = "Exito",                    
                };

            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }
       

        public async Task<ResponseProxy<StudentModel>> UpdateAsync(StudentModel model)
        {

            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/UpdateStudent");

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<StudentModel>
                {
                    Exitoso = exito,
                    Codigo = 0,
                    Mensaje = "Exito",
                };

            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }

        public async Task<ResponseProxy<StudentModel>> DeleteStudentAsync(int id)
        {

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/DeleteStudent", "/", id);

            var response = client.DeleteAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<StudentModel>
                {
                    Exitoso = exito,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",                    
                };

            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Exitoso= false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }




    }
}