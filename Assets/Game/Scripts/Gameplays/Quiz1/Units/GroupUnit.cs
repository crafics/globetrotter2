using System.Linq;
using System.Collections.Generic;
using Game.Scripts.Gameplays.Quiz1.Nodes;
using Game.Scripts.Gameplays.Quiz1.Cards;

namespace Game.Scripts.Gameplays.Quiz1.Units
{

    /// <summary>
    /// Unit containing some subunits with separate attack values and health
    /// </summary>
    public class GroupUnit : Unit
    {
        /// <summary>
        /// Sum of damage of al subunits
        /// </summary>
        public override int Damage { get { return SubUnits.Sum(su => su.Damage); } }

        /// <summary>
        /// List of all subunits in unit
        /// </summary>
        public List<SubUnit> SubUnits;

        public override void Init(PlayerColor owner, string ownerId, int id, Node startNode, Card card)
        {
            if (SubUnits.Count <= 0)
            {
                Destroy();
            }
            base.Init(owner, ownerId, id, startNode, card);
            foreach (SubUnit subUnit in SubUnits)
            {
                subUnit.Init(_card);
                subUnit.OnDestroyed += RemoveSubUnit;
            }
        }

        public override void TakeDamage(int damage, AttackType attackType)
        {
            if (attackType == AttackType.Simple)
            {
                SubUnits[0].TakeDamage(damage);
            }
            else if (attackType == AttackType.AoE)
            {
                List<SubUnit> temp = new List<SubUnit>(SubUnits);
                foreach (SubUnit subUnit in temp)
                {
                    subUnit.TakeDamage(damage);
                }
            }
        }

        private void RemoveSubUnit(SubUnit subUnit)
        {
            SubUnits.Remove(subUnit);
            if (SubUnits.Count <= 0)
            {
                Destroy();
            }
        }
    }

}