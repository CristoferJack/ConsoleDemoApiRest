using ConsoleDemoApiRest.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace ConsoleDemoApiRest
{
    class Program
    {
        static void Main(string[] args)
        {
            getPersonaData();
        }

        public static void getPersonaData()
        {
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/");
            var request = new RestRequest("employees");
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string stringRespuesta = response.Content;
                Rootobject result = JsonConvert.DeserializeObject<Rootobject>(stringRespuesta);

                if (result.data.Count > 0)
                {
                    crearDataEnPersonaApiRest(result.data);
                }

            }
            else
            {
                Console.Write("Error");
            }
        }

        
        private static void crearDataEnPersonaApiRest(List<Datum>listaData)
        {
            var personas = mapDataToPersonas(listaData);

            cargarPersonasEnApi(personas);
        }

        private static List<Persona> mapDataToPersonas(List<Datum> listaData)
        {
            var personas = new List<Persona>();
            foreach (var item in listaData)
            {
                var persona = new Persona();
                persona.nombre = item.employee_name;
                persona.salario = item.employee_salary;
                persona.edad = item.employee_age;
                persona.documento = "11111111";
                persona.perfil = "Ninguno";
                personas.Add(persona);
            }
            return personas;
        }

        private static void cargarPersonasEnApi(List<Persona> personas)
        {

            var client = new RestClient("http://192.168.0.13:5000");     

            foreach (var item in personas)
            {
                var request = new RestRequest("/persona", Method.POST);

                request.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;

                request.AddJsonBody(item);

                try
                {
                    IRestResponse response = client.Execute(request);
                    var content = response.Content;
                    Console.WriteLine("Empleado agregado... ID: " + content);
                }
                catch (Exception error)
                {
                    Console.WriteLine("Empleado no agregado: " + item.id);
                    Console.WriteLine("Mensaje de error: " + error.Message);
                }
            }
        }
    }
}
