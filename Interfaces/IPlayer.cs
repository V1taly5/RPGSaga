namespace RPGSaga.Heroes
{
    public abstract class IPlayer
    {
       
        
        string ?Name {get; set; }

        public int Strength {get; set; }
        
        public int HP {get; set; }

        public bool IsDead {get; set; }

        public bool IsFire {get; set; }

    }
}