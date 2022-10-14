namespace RPGSaga.Heroes
{
    using RPGSaga.Interface;
    using RPGSaga.Abilities;

    public class Knight : Player
    {

        private Player _opponent;

        List<IAbility> _abilities;
        List<IAbility> _effectsList;
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
            _opponent.Addeffect(_abilities[index]);
        }


    }
}