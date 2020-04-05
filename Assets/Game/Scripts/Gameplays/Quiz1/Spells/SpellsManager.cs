using System.Collections.Generic;
using Game.Scripts.Gameplays.Quiz1.Cards;
using Game.Scripts.Gameplays.Quiz1.NetworkCommunication;
using Game.Scripts.Gameplays.Quiz1.NetworkCommunication.MatchStates;
using Game.Scripts.Gameplays.Quiz1.Units;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Spells
{

    /// <summary>
    /// Manager resolving spells activation. Contains also object pooling mechanic for spells.
    /// </summary>
    public class SpellsManager : MonoBehaviour
    {
        /// <summary>
        /// List of disabled spells objects
        /// </summary>
        private List<ISpell> _nonactiveSpells = new List<ISpell>();

        /// <summary>
        /// List of active spells objects
        /// </summary>
        private List<ISpell> _activeSpells = new List<ISpell>();

        private void Start()
        {
            //MatchCommunicationManager.Instance.OnSpellActivated += ResolveSpellActivation;
            //MatchCommunicationManager.Instance.OnCardPlayed += ActivateSpell;
        }

        /// <summary>
        /// Activates spell object of type given in message on node given in message
        /// </summary>
        /// <param name="message"></param>
		/*
        private void ActivateSpell(MatchMessageCardPlayed message)
        {
            if (message.Card.cardType == CardType.Fireball)
            {
                GetNonactiveSpellOfType(SpellType.Fireball).Activate(GameManager.Instance.Nodes[message.NodeX, message.NodeY], message.PlayerId);
            }
        }
        */

        /// <summary>
        /// Resolves spell activation on given node
        /// </summary>
        /// <param name="message"></param>
		/*
        private void ResolveSpellActivation(MatchMessageSpellActivated message)
        {
            ISpell spell = GetNonactiveSpellOfType(message.SpellType);

            _nonactiveSpells.Remove(spell);
            _activeSpells.Add(spell);

            spell.OnHide += HideSpell;

            spell.Show(GameManager.Instance.Nodes[message.NodeX, message.NodeY]);

            List<Unit> impactedUnits = new List<Unit>();

            foreach (int unitId in message.ImpactedUnitsIds)
            {
                impactedUnits.Add(UnitsManager.Instance.GetUnit(unitId));
            }

            spell.MakeImpactOnUnits(impactedUnits);
        }
        */

        /// <summary>
        /// Gets disabled spell object or spawn one if could not find any
        /// </summary>
        /// <param name="spellType"></param>
        /// <returns></returns>
		/*
        private ISpell GetNonactiveSpellOfType(SpellType spellType)
        {
            ISpell spell = _nonactiveSpells.Find(s => s.SpellType == spellType);

            if (spell == null)
            {
                GameObject prefab = Resources.Load<GameObject>("Spells/" + spellType.ToString());
                spell = Instantiate(prefab, transform).GetComponent<ISpell>();
                _nonactiveSpells.Add(spell);
            }

            return spell;
        }
        */

        /// <summary>
        /// Hides spell object and adds it to nonactive spells list
        /// </summary>
        /// <param name="spell"></param>
		/*
        private void HideSpell(ISpell spell)
        {
            _activeSpells.Remove(spell);
            _nonactiveSpells.Add(spell);
        }
        */
    }

}