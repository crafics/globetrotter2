using System;

namespace Game.Scripts.Menus
{
    [Serializable]
    public class ConfigurationOperationResponse
    {
        public int max_player_level;
        public int minVersion;
        public int reachable_levels;
    }
}
