using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Cards
{
    /// <summary>
    /// Scriptable object containing a list of <see cref="CardInfo"/>.
    /// Used for easy card management and distinction.
    /// </summary>
    [CreateAssetMenu(fileName = "CardList", menuName = "Deck/Card List")]
    public class CardList : ScriptableObject
    {

        /// <summary>
        /// List of card infos stored by this object.
        /// </summary>
        [SerializeField] private List<CardInfo> cardInfos = null;

        /// <summary>
        /// Returns the list of card infos stored in this scriptable object.
        /// </summary>
        public List<CardInfo> CardInfos => cardInfos;

    }
}
