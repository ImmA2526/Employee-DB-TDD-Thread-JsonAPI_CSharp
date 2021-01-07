using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System;
using Newtonsoft.Json;

namespace EmployeePayroll_Json_Tester
{

    public class EmployeeModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }

    [TestClass]
    public class JSONTester
    {
        RestClient client;

        public object JsonConvertor { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        private IRestResponse GetEmployeeList()
        {
            RestRequest request = new RestRequest("/Employee", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// UC 1 Retrive Record 
        /// </summary>
        
        [TestMethod]

        public void OnCalling_GetApi_ReturnList()
        {
            IRestResponse response = GetEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<EmployeeModels> dataResponse = JsonConvert.DeserializeObject<List<EmployeeModels>>(response.Content);
            Assert.AreEqual(3, dataResponse.Count);

            foreach (EmployeeModels e in dataResponse)
            {
                System.Console.WriteLine("ID: ", e.Id, "Name:", e.Name, "Basic Salary: ", e.Salary);
            }
        }
    }
}

