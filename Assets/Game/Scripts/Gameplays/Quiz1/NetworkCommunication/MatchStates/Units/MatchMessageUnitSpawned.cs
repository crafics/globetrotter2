
namespace Game.Scripts.Gameplays.Quiz1.NetworkCommunication.MatchStates
{
    /// <summary>
    /// Contains data about spawned unit
    /// </summary>
    public class MatchMessageUnitSpawned : MatchMessage<MatchMessageUnitSpawned>
    {
        public readonly string OwnerId;
        public readonly int UnitId;
        public readonly int NodeX;
        public readonly int NodeY;

        public MatchMessageUnitSpawned(string ownerId, int unitId, int nodeX, int nodeY)
        {
            OwnerId = ownerId;
            UnitId = unitId;
            NodeX = nodeX;
            NodeY = nodeY;
        }
    }
}
