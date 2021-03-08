using DevDatum.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevDatum.Tests.Domain
{
    [TestClass]
    public class InterestTests
    {
        private readonly Fees fees = new Fees(1, "Juro BB");
        private readonly Interest interest = new Interest(100, 5);

        [TestMethod]
        [TestCategory("Domain")]
        public void Create_New_Interest_Check_Fee_Check_Tax_Fee_Fixed_Decimal()
        {
            //Criado um novo objeto verificar se a taxa é um valor fixo
            var tax = fees.GetTaxFee;
            Assert.AreEqual(0.01M, tax);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Create_New_Interest_Check_Month_More_Than_Zero()
        {
            //Criado um novo objeto verificar se o mes é maior que zero
            var inter = interest.Time > 0 ? true : false;
            Assert.AreEqual(inter, true);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Create_New_Interest_Check_Month_Less_Equals_Than_Twelve()
        {
            //Criado um novo objeto verificar se o mes é menor ou igual a doze
            var inter = interest.Time <= 12 ? true : false;
            Assert.AreEqual(inter, true);
        }
    }
}
