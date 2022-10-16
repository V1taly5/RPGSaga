namespace RPGSaga.Interface
{
    public interface IAbility
    {
        public string Name {get;}

        public double Damage {get; set; }

        public int UsageLimit {get; set; }

        public bool SkippingMove {get; set; } //зпставляет ли эта абилка пропустить противика ход

        public bool IsFire {get;} // проверка вызывает ли абилка возгорание проттвника

         public int Duration{ get; set; }

        public bool СheckUsageLimit();
    }
}
