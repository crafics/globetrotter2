using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Cards
{

    /// <summary>
    /// Contains all the information of a single instance of playable card.
    /// </summary>
    [Serializable]
    public class Card
    {
        #region Fields

        /// <summary>
        /// Determines the underlying <see cref="GetCardInfo"/> scriptable object.
        /// </summary>
        [SerializeField] public CardType cardType;

        /// <summary>
        /// The level of this card instance.
        /// Cards gain additional benefits with every level.
        /// </summary>
        [SerializeField] public int level;

        /// <summary>
        /// If true, this card is used in its owner's deck.
        /// </summary>
        [NonSerialized] public bool isUsed;

        /// <summary>
        /// Contains all stats and in-game object prefab of this card.
        /// </summary>
        [NonSerialized] private CardInfo _cardInfo;

        #endregion

        #region Methods


        /// <summary>
        /// Returns <see cref="CardInfo"/> containing all stats and in-game object prefab
        /// reference of this card.
        /// </summary>
        public CardInfo GetCardInfo()
        {
            if (_cardInfo == null)
            {
                SetCardInfo(CardListSingleton.Instance.AllCards);
                if (_cardInfo == null)
                {
                    SetCardInfo(CardListSingleton.Instance.StartingTowers);
                    if (_cardInfo == null)
                    {
                        Debug.LogError("No card with type " + cardType + " found in Card List");
                    }
                }
            }
            return _cardInfo;
        }

        /// <summary>
        /// Sets the <see cref="GetCardInfo"/> property based on
        /// this instance's <see cref="cardType"/>.
        /// </summary>
        /// <param name="cardList">
        /// Scriptable object containing a list of all awailable cards.
        /// </param>
        private void SetCardInfo(CardList cardList)
        {
            foreach (CardInfo cardInfo in cardList.CardInfos)
            {
                if (cardInfo.CardType == cardType)
                {
                    this._cardInfo = cardInfo;
                    return;
                }
            }
        }

        /// <summary>
        /// Returns true if both card instances has the same <see cref="level"/>
        /// and shares the <see cref="cardType"/>.
        /// </summary>
        public bool IsCopy(Card other)
        {
            if (other == null || this == null)
            {
                return false;
            }
            return this.level == other.level && this.cardType == other.cardType;
        }

        /// <summary>
        /// Serializes this class
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> Serialize()
        {
            return new Dictionary<string, string> {
            { "card_type", ((int)this.cardType).ToString() },
            { "level", this.level.ToString() },
            { "is_used", isUsed.ToString() }
        };
        }

        #endregion
    }

}