
using System.Collections.Generic;

namespace Game.Scripts.Gameplays.Quiz1.NetworkCommunication.MatchStates
{

    /// <summary>
    /// Reward received for the match.
    /// </summary>
    public class MatchMessageReward : MatchMessage<MatchMessageReward>
    {

        /// <summary>
        /// Contains the reward recived for winning/losing the match.
        /// </summary>
        public Dictionary<string, int> reward;

        public MatchMessageReward(Dictionary<string, int> reward)
        {
            this.reward = reward;
        }
    }

}