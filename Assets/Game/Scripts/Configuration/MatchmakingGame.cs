using System.Collections.Generic;
using System;
using UnityEngine;
using Game.Scripts.Matchmaking;

namespace Game.Scripts.Configuration
{
    [Serializable]
    public class MatchmakingGame
    {
        public string name = "";
        public string scene = "";
        public MatchmakingParams matchmakingParams = null;
    }
}