namespace DevDatum.Domain.Entities
{
    public class Fees
    {
        public Fees() 
        {
            this.SetTaxFee();
        }
        public Fees(int id, string name)
        {
            Id = id;
            Name = name;
            SetTaxFee();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Fee { get; private set; }

        private void SetTaxFee() => Fee = 0.01M;

        public decimal GetTaxFee => Fee;
    }
}
