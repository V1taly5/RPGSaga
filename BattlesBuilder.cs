namespace RPGSaga
{
    using RPGSaga.Generator;
    using RPGSaga.Heroes;
    public class BattlesBuilder
    {
        private TournamentListGenerator tournamentListGenerator;
        private Fight fight;
        private int size;
        private List<Player> tournamentList;


        public BattlesBuilder(int size)
        {
            System.Console.WriteLine(size);
            Size = size;
            tournamentListGenerator = new TournamentListGenerator(Size);
            tournamentList = new List<Player>();
        }

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                 if (value > 1 && value%2 == 0)
                {
                    size = value;
                }
                else
                {
                    size = 2;
                }
            }

        }

        public void StartTournament()
        {
            System.Console.WriteLine("sdsdsd");
            tournamentList = tournamentListGenerator.GenerateTournamentList();

            for(int i = 0; i < Size - 1; i++ )
            {
                Logger.WriteLog("");
                Logger.WriteLog($"Round: {i}");
                Logger.WriteLog("");
                Logger.WriteLog($"size-1: {Size - 1}");
                RunBattle(tournamentList);
            }

            foreach (var player in tournamentList)
            {
                Console.WriteLine(player);
            }
        }

        public List<Player> RunBattle(List<Player> players)
        {
            List<Player> playersList = new List<Player>(players);
            //playersList = players;
            

            foreach(var player in playersList)
            {
                System.Console.WriteLine(player.ToString());
                player.SetDefaultValues();
            }

            if (playersList.Count > 1)
            {
                tournamentList.Clear();
                for (int i = 0; i < playersList.Count; i += 2)
                {
                    System.Console.WriteLine($"оно {playersList.Count}");
                    System.Console.WriteLine($"{playersList[i]} {playersList[i+1]}");
                    System.Console.WriteLine("sdsdsd");
                    fight = new Fight(playersList[i], playersList[i+1]);
                    fight.SetOpponent();
                    tournamentList.Add(fight.StartFight());
                     
                }
            }
            
           return tournamentList;
        }

        public void GetWinner()
        {
            Logger.WriteLog("=======================================");
            Logger.WriteLog("Winner List");
            Logger.WriteLog("=======================================");
            Console.WriteLine(tournamentList[0]);
        }
 
    }
}