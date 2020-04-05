namespace Game.Scripts.Gameplays.Quiz1.NetworkCommunication.MatchStates
{
    /// <summary>
    /// Used to easily get op code for sending and reading match state messages
    /// </summary>
    public enum MatchMessageType
    {
        #region MATCH

        MatchStarted,

        MatchEnded,

        MatchReward,

        #endregion

        #region PLAYERS

        UnitSpawned,

        #endregion

    }
}
