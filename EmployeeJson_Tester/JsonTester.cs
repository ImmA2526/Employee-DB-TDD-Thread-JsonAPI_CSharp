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

        /// <summary>
        /// UC 2 Shoulds the return add employee.
        /// </summary>

        [TestMethod]
        public void ShouldReturnAddEmployee_BY_API()
        {
            RestRequest request = new RestRequest("/Employee", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("Name", "Asif");
            jObjectbody.Add("Salary", "90000");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            EmployeeModels dataResponse = JsonConvert.DeserializeObject<EmployeeModels>(response.Content);
            Assert.AreEqual("Asif", dataResponse.Name);
            Assert.AreEqual("90000", dataResponse.Salary);
        }

        /// <summary>
        /// UC 3 Add Multiple Employee
        /// </summary>
        [TestMethod]
        public void AddMultiple_Employee_BY_API()
        {
            List<EmployeeModels> addMultiple = new List<EmployeeModels>();
            addMultiple.Add(new EmployeeModels { Name = "Ashraf", Salary = "350000" });
            addMultiple.Add(new EmployeeModels { Name = "Umme", Salary = "450000" });
            addMultiple.Add(new EmployeeModels { Name = "Raju", Salary = "5500000" });
            addMultiple.ForEach(record =>
            {
                RestRequest request = new RestRequest("/Employee", Method.POST);
                JObject jObjectBody = new JObject();
                jObjectBody.Add("Name", record.Name);
                jObjectBody.Add("Salary", record.Salary);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                EmployeeModels dataResorce = JsonConvert.DeserializeObject<EmployeeModels>(response.Content);
                Assert.AreEqual(record.Name, dataResorce.Name);
                Assert.AreEqual(record.Salary, dataResorce.Salary);
                Console.WriteLine(response.Content);
            });
        }

        /// <summary>
        /// UC 4 Update Salary
        /// </summary>

        [TestMethod]
        public void UpdateSalary_By_API()
        {
            RestRequest request = new RestRequest("/Employee/5", Method.PUT);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("Name", "Umme");
            jObjectbody.Add("Salary", "888888");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            EmployeeModels dataResponse = JsonConvert.DeserializeObject<EmployeeModels>(response.Content);
            Assert.AreEqual("Umme", dataResponse.Name);
            Assert.AreEqual("888888", dataResponse.Salary);
        }

        /// <summary>
        /// UC 5 Delete Employee
        /// </summary>
        [TestMethod]
        public void DeleteEmploye_By_API()
        {
            RestRequest request = new RestRequest("/Employee/3", Method.DELETE);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}

