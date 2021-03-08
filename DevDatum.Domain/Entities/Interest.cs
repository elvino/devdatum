using System;

namespace DevDatum.Domain.Entities
{
    public class Interest
    {
        public Interest(decimal initialValue, int time) 
        {
            InitialValue = initialValue;
            Time = time;
        }

        public Interest(int id, string name, decimal finalValue, decimal initialValue, int time)
        {
            Id = id;
            Name = name;
            FinalValue = finalValue;
            InitialValue = initialValue;
            Time = time;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal FinalValue { get; private set; }
        public decimal InitialValue { get; private set; }
        public int Time { get; private set; }

        public decimal CalculateFee(decimal fee)
        {
            FinalValue = InitialValue * (decimal)(Math.Pow((double)(1 + fee), Time));
            return Math.Truncate(FinalValue * 100) / 100;
        }
    }
}
