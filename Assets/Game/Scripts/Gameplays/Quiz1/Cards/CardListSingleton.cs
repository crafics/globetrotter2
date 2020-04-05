using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Cards
{
    /// <summary>
    /// Singleton containing the list of all available cards in game.
    /// </summary>
    public class CardListSingleton : Singleton<CardListSingleton>
    {
        #region Fields

        /// <summary>
        /// Reference to list of all available cards.
        /// </summary>
        [SerializeField] private CardList _allCards = null;

        /// <summary>
        /// Reference to list of all starting towers.
        /// </summary>
        [SerializeField] private CardList _startingTowers = null;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the list of all available cards.
        /// </summary>
        public CardList AllCards => _allCards;

        /// <summary>
        /// Returns the list of all starting towers.
        /// </summary>
        public CardList StartingTowers => _startingTowers;

        #endregion

        #region Monobehaviour

        /// <summary>
        /// Makes this gameobject persistent throughout the game.
        /// </summary>
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        #endregion
    }
}
