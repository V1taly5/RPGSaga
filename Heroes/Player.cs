namespace RPGSaga.Heroes
{
    using RPGSaga.Abilities;
    using RPGSaga.Interface;
    public abstract class Player : IPlayer
    {
        private int _strength;

        private bool _isSkip;

        public Player(string name, int hp, int strength)
        {
            Name = name;
            HP = hp;
            Strength = strength;
            IsDead = false;
            IsFire = false;
        }

        public string Name {get; set; }

        public int Strength 
        {
            get
            {
                return _strength;
            } 
            set
            {
                _strength = value;
            } 
        }

        public abstract Player Opponent{get; set;}

        public bool IsDead {get; set; }

        public bool IsFire {get; set; }

        public int HP {get; protected set; }

        public abstract void MakeMove();

        public abstract void DealDamage();

        public abstract void Addeffect(IAbility effect);

        public abstract void SetDefaultValues();
    }
}