using Game.Scripts.Gameplays.Quiz1.NetworkCommunication;
using Game.Scripts.Menus;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Gameplays.Quiz1.UI
{

    /// <summary>
    /// Menu showed at the end of a match.
    /// Shows who win as well as displays the funds gained for the match.
    /// </summary>
    public class SummaryMenu : Menu
    {

        #region Fields

        /// <summary>
        /// Displays the reward gained from the match.
        /// </summary>
        [SerializeField] private Text _rewardText = null;

        /// <summary>
        /// Shows who win the match.
        /// </summary>
        [SerializeField] private Text _header = null;

        /// <summary>
        /// Image visualizing local user's victory/defeat.
        /// </summary>
        [SerializeField] private Image _resultImage = null;


        [Space]
        /// <summary>
        /// Winning message displayed in <see cref="_header"/>.
        /// </summary>
        [SerializeField] private string _winHeader = string.Empty;

        /// <summary>
        /// Winning image displayed in <see cref="_resultImage"/>.
        /// </summary>
        [SerializeField] private Sprite _winSprite = null;

        [Space]
        /// <summary>
        /// Losing message displayed in <see cref="_header"/>.
        /// </summary>
        [SerializeField] private string _loseHeader = string.Empty;

        /// <summary>
        /// Losing image displayed in <see cref="_resultImage"/>.
        /// </summary>
        [SerializeField] private Sprite _loseSprite = null;

        #endregion

        #region Monobehaviour

        /// <summary>
        /// Sets the back button listener.
        /// </summary>
        private void Awake()
        {
            base.SetBackButtonHandler(Hide);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populates all text and image fields of this summary menu.
        /// </summary>
        public void SetResult(bool win, int reward)
        {
            if (win == true)
            {
                _header.text = _winHeader;
                _resultImage.sprite = _winSprite;
                _rewardText.text = $"+{reward}";
            }
            else
            {
                _header.text = _loseHeader;
                _resultImage.sprite = _loseSprite;
                _rewardText.text = $"+{reward}";
            }
        }

        /// <summary>
        /// Hides this menu.
        /// Unloads this scene and loads main menu.
        /// </summary>
        public override void Hide()
        {
            base.Hide();
            MatchCommunicationManager.Instance.LeaveGame();
        }

        #endregion

    }

}