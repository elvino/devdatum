using DevDatum.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevDatum.Tests.Domain
{
    [TestClass]
    public class FeesTests
    {
        private Fees fees = new Fees(1, "Juro CPFL");
        

        [TestMethod]
        [TestCategory("Domain")]
        public void Create_New_Fee_Check_Tax_Fee_Fixed_Decimal()
        {
            //Criado um novo onjeto verificar se a taxa é um valor fixo
            var tax = fees.GetTaxFee;
            Assert.AreEqual(0.01M, tax);
        }
    }
}
