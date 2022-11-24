namespace RPGSaga.Heroes
{
    using RPGSaga.Interface;
    using RPGSaga.Abilities;
    using RPGSaga;

    public class Wizard : Player
    {
        private bool _isSkip;
        private Player _opponent;
        List<IAbility> _abilities;
        List<IAbility> _effectsList;

        public Wizard(string name, int hp, int strength)
       : base(name, hp, strength)
       {
        _abilities = new List<IAbility>() {new Hit(strength), new Spellbinding()};
        _effectsList = new List<IAbility>();
        // что-то ещё
       }

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

        public override void MakeMove()
        {
            _isSkip = false;
            List<IAbility> effects =_effectsList;
            foreach (var effect in _effectsList)
            {
                if (effect.SkippingMove)
                {
                    _isSkip = true;
                    Logger.WriteLog($"{ToString()} is skipping step");
                }

                if (effect.IsFire)
                {
                    IsFire = true;
                    Logger.WriteLog($"{ToString()} is burning");
                }

                if (IsFire)
                {
                    HP -= 2;
                }

                HP -= (int)effect.Damage;

                if (HP <= 0)
                {
                    IsDead = true;
                    return;
                }

                if (HP <= 0)
                {
                    IsDead = true;
                    return;
                }

                effect.Duration -= 1;

                if (effect.Duration <= 0)
                {
                    _effectsList.Remove(effect);
                }
                
                if(_effectsList.Count<=1)
                {
                    break;
                }
            }
            Logger.WriteLog($"{ToString()} has {HP} HP");
            Logger.WriteLog("-------------------------------------------------------");
        
            if (!_isSkip )
            {
                DealDamage();
            }
        }
        public override void Addeffect(IAbility effect)
        {
            _effectsList.Add(effect);
        }

        public void SetOppnent(Player opponent)
        {    
            _opponent = opponent;
        }

        public override void DealDamage()
        {
            int index = Random.Shared.Next(0, _abilities.Count);
            _opponent.Addeffect(_abilities[index]);
            Logger.WriteLog($"{this.Name} применяет {_abilities[index].Name} и наносит {(int)_abilities[index].Damage}");
            _abilities[index].UsageLimit -=1;
            if (_abilities[index].UsageLimit == 0)
            {
                Logger.WriteLog($"{ToString()} used maximum times of {_abilities[index].Name}");
                _abilities.RemoveAt(index);
            }
            
        }

        public override void SetDefaultValues()
        {
            HP = 100;
            IsDead = false;
            IsFire = false;
            AddAbilities();
        }

        public override string ToString()
        {
            return $"Wizard: {Name}";
        }

        protected void AddAbilities()
        {
            _abilities.Clear();
            _abilities.Add(new Hit(Strength));
            _abilities.Add(new Spellbinding());
        }
    }
}