namespace RPGSaga
{
    using RPGSaga.Heroes;

    public class Fight
    {
        private Player _player_1;
        private Player _player_2;
        private Player loser;
        private Player winner;

        public Fight(Player player_1, Player player_2)
        {
            _player_1 = player_1;
            _player_2 = player_2;
        }

        public void SetOpponent()
        {
            _player_1.Opponent = _player_2;
            _player_2.Opponent = _player_1;
        }

        public Player StartFight()
        {
            Logger.WriteLog($"Name: {_player_1.Name}, HP: {_player_1.HP}, Strength: {_player_1.Strength} VS Name : {_player_2.Name}, HP: {_player_2.HP}, Strength: {_player_2.Strength}");
            while (!_player_1.IsDead && !_player_2.IsDead)
            {
                _player_1.MakeMove();
                Logger.WriteLog($"name: {_player_1.Name}, hp: {_player_1.HP}, strength: {_player_1.Strength}");

                _player_2.MakeMove();
                Logger.WriteLog($"name: {_player_2.Name}, hp: {_player_2.HP}, strength: {_player_2.Strength}");
            }
            if (_player_1.IsDead)
            {
                loser = _player_1;
                winner = _player_2;
            }
            else
            {
                loser = _player_2;
                winner = _player_1;
            }
            Logger.WriteLog($"Winer is {winner.Name}");
           
            return winner;
        }
    }
   
}
