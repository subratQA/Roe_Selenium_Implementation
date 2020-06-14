using Automtion.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automtion.Testing.Containers
{
    [TestClass]
    public class StudentTest
    {
        [DataTestMethod]
        [DataRow("{'driver':'CHROME','keyword':'Alexander','application':'http://kamburugoda.net/Student'}")]
        public void SearchStudentUITest(string testParams)
        {
            //generate Test parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            //exeute test with parameter
            var actual = new SearchStudent().WithTestParams(parameters).Execute().Actual;

            //assert the result
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("{'driver':'CHROME','firstName':'csharp','lastName':'student','application':'http://kamburugoda.net/Student'}")]
        public void CreateStudentUITest(string testParams)
        {
            //generate Test parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            //exeute test with parameter
            var actual = new SearchStudent().WithTestParams(parameters).Execute().Actual;

            //assert the result
            Assert.IsTrue(actual);
        }
    }
    
}
