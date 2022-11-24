namespace RPGSaga.Interfaces
{
    using System.Collections.Generic;
    using RPGSaga.Heroes;

    public interface ITournamentListGenerator
    {
        int ListSize { get; set; }

        List<Player> GenerateTournamentList();
    }
}