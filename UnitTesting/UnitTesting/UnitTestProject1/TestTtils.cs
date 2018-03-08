//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Utilities;

//namespace Utility.Test
//{
    
//    [TestClass]
    
//    public class TestTtils
//    {
        
//        private TestContext context;
//        public TestContext Context
//        {
//            get
//            {
//                return context;
//            }

//            set
//            {
//                context = value;
//            }
//        }
        
//        [DeploymentItem(".\\data.xml"), TestMethod]
//        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
//            ".\\data.xml", "Row", DataAccessMethod.Sequential)]

       
//        public void MathUtils_SumTwoNumbers_Should_SumRight()
//        {
            
//            var utils = new MathUtils();
//            int a = int.Parse((string)Context.DataRow["A"]);
//            int b = int.Parse((string)Context.DataRow["B"]); 
//            int res = int.Parse((string)Context.DataRow["Expected"]);

//            var result = utils.Sum(a, b);

//            Assert.AreEqual(res, result);
//        }
//    }
//}
