namespace RPGSaga
{
    using System;
    using RPGSaga.Heroes;
    using RPGSaga.Abilities;

     public class Program
    {
        public static void Main(string[] args)
        {
            Knight player1 = new Knight("Hary", 100, 5);
            Logger.WriteLog($"name: {player1.Name}, hp: {player1.HP}, strength: {player1.Strength}");

            Knight player2 = new Knight("Boby", 100, 6);
            Logger.WriteLog($"name: {player1.Name}, hp: {player1.HP}, strength: {player1.Strength}");

            player1.SetOppnent(player2);
        }
    
    }
}