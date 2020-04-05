namespace Game.Scripts.Gameplays.Quiz1.NetworkCommunication.MatchStates
{
    /// <summary>
    /// Sent at the end of the match.
    /// Contains information about winner and loser of a current match.
    /// </summary>
    public class MatchMessageGameEnded : MatchMessage<MatchMessageGameEnded>
    {

        #region Fields

        /// <summary>
        /// User ID of the winner.
        /// </summary>
        public string winnerId;

        /// <summary>
        /// User ID of the loser.
        /// </summary>
        public string loserId;

        /// <summary>
        /// Id of the match.
        /// </summary>
        public string matchId;

        /// <summary>
        /// The number of destroyed towers owned by the winner.
        /// Each destroyed tower increases the score of the loser.
        /// </summary>
        public int winnerTowersDestroyed;

        /// <summary>
        /// The number of destroyed towers owned by the loser.
        /// Each destroyed tower increases the score of the winner.
        /// </summary>
        public int loserTowersDestroyed;

        /// <summary>
        /// Duration of the match.
        /// </summary>
        public float time;

        #endregion

        public MatchMessageGameEnded(string winnerId, string loserId, string matchId, int winnerTowersDestroyed, int loserTowersDestroyed, float time)
        {
            this.winnerId = winnerId;
            this.loserId = loserId;
            this.matchId = matchId;
            this.winnerTowersDestroyed = winnerTowersDestroyed;
            this.loserTowersDestroyed = loserTowersDestroyed;
            this.time = time;
        }
    }

}