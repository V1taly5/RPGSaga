namespace RPGSaga
{
    using RPGSaga.Heroes;

    public class Fight
    {
        private Player player_1;
        private Player player_2;
        private Player loser;
        private Player winner;

        public Fight(Player Player_1, Player Player_2)
        {
            player_1 = Player_1;
            player_2 = Player_2;
        }

        public void SetOpponent()
        {
            player_1.Opponent = player_2;
            player_2.Opponent = player_1;
        }

        public Player StartFight()
        {
            Logger.WriteLog("Характеристики:");
            Logger.WriteLog($"Name: ({player_1.Name}), HP: {player_1.HP}, Strength: {player_1.Strength} VS Name: ({player_2.Name}), HP: {player_2.HP}, Strength: {player_2.Strength}");
            while (!player_1.IsDead && !player_2.IsDead)
            {
                player_1.MakeMove();
                //Logger.WriteLog($"name: {_player_1.Name}, hp: {_player_1.HP}, strength: {_player_1.Strength}");

                player_2.MakeMove();
                //Logger.WriteLog($"name: {_player_2.Name}, hp: {_player_2.HP}, strength: {_player_2.Strength}");
            }
            if (player_1.IsDead)
            {
                loser = player_1;
                winner = player_2;
            }
            else
            {
                loser = player_2;
                winner = player_1;
            }
            Logger.WriteLog($"Winer is {winner.Name}");
           
            return winner;
        }
    }
   
}
