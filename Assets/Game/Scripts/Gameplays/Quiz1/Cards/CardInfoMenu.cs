using Game.Scripts.Menus;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Gameplays.Quiz1.Cards
{
    /// <summary>
    /// Popup window displaying informations of supplied <see cref="Card"/>.
    /// </summary>
    public class CardInfoMenu : SingletonMenu<CardInfoMenu>
    {
        #region Fields

        /// <summary>
        /// Textfield displaying the name of <see cref="_displayedCard"/>.
        /// </summary>
        [SerializeField] private Text _cardName = null;

        /// <summary>
        /// Textfield displaying the level of <see cref="_displayedCard"/>.
        /// </summary>
        [SerializeField] private Text _cardLevel = null;

        /// <summary>
        /// Textfield displaying the description of <see cref="_displayedCard"/>.
        /// </summary>
        [SerializeField] private Text _cardDescription = null;

        /// <summary>
        /// The image representing <see cref="_displayedCard"/>.
        /// </summary>
        [SerializeField] private Image _cardImage = null;

        /// <summary>
        /// The card this <see cref="CardInfoMenu"/> is displaying info of.
        /// Can be set by invoking <see cref="SetCard(Card)"/> method.
        /// </summary>
        private Card _displayedCard;

        #endregion

        #region Mono

        /// <summary>
        /// Sets the back button listener.
        /// </summary>
        protected override void Awake()
        {
            base.SetBackButtonHandler(MenuManager.Instance.HideTopMenu);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the card to be displayed by this menu.
        /// </summary>
        public void SetCard(Card card)
        {
            _displayedCard = card;
            _cardLevel.text = card.level.ToString();
            _cardName.text = card.GetCardInfo().Name;
            _cardDescription.text = card.GetCardInfo().Description;
            _cardImage.sprite = card.GetCardInfo().Sprite;
        }

        #endregion
    }
}
