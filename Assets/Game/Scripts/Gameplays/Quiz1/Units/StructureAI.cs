using System.Collections.Generic;
using Game.Scripts.Gameplays.Quiz1.NetworkCommunication;
using Game.Scripts.Gameplays.Quiz1.Nodes;

namespace Game.Scripts.Gameplays.Quiz1.Units
{

    /// <summary>
    /// AI of nonmovable objects that could attack, like i.e. forts
    /// </summary>
    public class StructureAI : UnitAI
    {
        /*
        protected override void Update()
        {
            if (MatchCommunicationManager.Instance.IsHost && _unit.IsDestroyed == false)
            {
                if (_enemy)
                {
                    if (!_enemy.CurrentNode.ConnectedNodes.ContainsKey(_unit.CurrentNode))
                    {
                        FindAndSetEnemy();
                    }
                    if (_unit.IsWeaponReloaded)
                    {
                        if (_unit.CurrentNode.ConnectedNodes.ContainsKey(_enemy.CurrentNode))
                        {
                            SendAttackRequest(_enemy, _unit.Damage, _unit.AttackType);
                        }
                    }
                }
                else
                {
                    FindAndSetEnemy();
                }
            }
        }
        */

        /*
        public override bool RearrangeIfCan(Stack<UnitMove> unitsMovesStack)
        {
            return false;
        }
        */

        /*
        protected override Node SelectEnemyNeighbourNode(Stack<UnitMove> previousUnitsMoves = null)
        {
            return null;
        }
        */
    }

}