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
            Logger.WriteLog($"name: {player2.Name}, hp: {player2.HP}, strength: {player2.Strength}");


            Fight f1 = new Fight(player1, player2);
            f1.SetOpponent();
            f1.StartFight();
        } 
    }
}