
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using UnityEngine;

namespace Game.Scripts.Matchmaking
{

    [Serializable]
    public class MatchmakingParams
    {
        /// <summary>
        /// Defines how the user wants to find their opponents.
        /// More information here: https://heroiclabs.com/docs/gameplay-matchmaker/#query
        /// </summary>
        public string query = "*";

        /// <summary>
        /// The minimum number of players for a match to start.
        /// </summary>
        public int minUserCount = 0;

        /// <summary>
        /// The maximum number of players for a match to start.
        /// </summary>
        public int maxUserCount = 0;

        /// <summary>
        /// String properties used by <see cref="query"/> for better matchmaking experience.
        /// </summary>
        public Dictionary<string, string> stringProperties = new Dictionary<string, string>();

        /// <summary>
        /// Numeric properties used by <see cref="query"/> for better matchmaking experience.
        /// </summary>
        public Dictionary<string, double> numericProperties = new Dictionary<string, double>();

    }

}