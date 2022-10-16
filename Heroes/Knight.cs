namespace RPGSaga.Heroes
{
    using RPGSaga.Interface;
    using RPGSaga.Abilities;
    using RPGSaga;

    public class Knight : Player
    {

        private Player _opponent;

        List<IAbility> _abilities;
        List<IAbility> _effectsList;

        public override Player Opponent 
        {
            get
            {
                return _opponent;
            }

            set
            {
                _opponent = value;
            }
        }

       public Knight(string name, int hp, int strength)
       : base(name, hp, strength)
       {
        _abilities = new List<IAbility>() {new Hit(strength), new VengeanceStrike(strength)};
        _effectsList = new List<IAbility>();
        // что-то ещё
       }

       public void SetOppnent(Player opponent)
       {
            _opponent = opponent;
       }

        public override void Addeffect(IAbility effect)
        {
            _effectsList.Add(effect);
        }

        public override void DealDamage()
        {
            int index = Random.Shared.Next(0, _abilities.Count());
            Logger.WriteLog($"{this.Name} применяет {_abilities[index].Name} и наносит {(int)_abilities[index].Damage}");
            System.Console.WriteLine();
            _opponent.Addeffect(_abilities[index]);
        }
        
         public override void MakeMove()
         {
            DealDamage();
            foreach (var effect in _effectsList)
                {
                    HP -= (int)effect.Damage;
                    if (HP <= 0)
                    {
                        IsDead = true;
                        return;
                    }
                }
           
         }

    }
}