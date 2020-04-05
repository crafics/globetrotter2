using System.Collections.Generic;
using Game.Scripts.Gameplays.Quiz1.Cards;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Decks
{
    /// <summary>
    /// Contains a list of all used and unused cards owned by a user.
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// The name of this deck.
        /// </summary>
        [SerializeField] public string deckName = "Deck Name";

        /// <summary>
        /// List of all cards owned by the deck owner that are currently not in the deck.
        /// </summary>
        [SerializeField] public List<Card> unusedCards = new List<Card>();

        /// <summary>
        /// List of all cards owned by the deck owner that are currently in the deck.
        /// </summary>
        [SerializeField] public List<Card> usedCards = new List<Card>();
    }
}
