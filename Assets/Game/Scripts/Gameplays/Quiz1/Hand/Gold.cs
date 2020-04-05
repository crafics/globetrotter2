using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Hands
{

    /// <summary>
    /// Handles in-game gold income/outcome.
    /// Used obly by the host.
    /// Gold is a currency used to play cards during a match.
    /// For the currency used to buy and merge cards outside the match,
    /// see <see cref="DeckBuildingMenu._funds"/>.
    /// </summary>
    public class Gold : MonoBehaviour
    {

        #region Fields

        /// <summary>
        /// Starting gold count.
        /// </summary>
        [SerializeField] private int _startingGold = 3;

        /// <summary>
        /// Maximum gold a user can have at a time.
        /// </summary>
        [SerializeField] private int _maxGoldCount = 10;

        /// <summary>
        /// Gold income per second.
        /// </summary>
        [SerializeField] private float _goldPerSecond = 0.5f;

        #endregion

        #region Properties

        /// <summary>
        /// The ammount of gold this user currently have.
        /// </summary>
        /// <remarks>
        /// This value is not an integer, because gold income is linear, not discrete.
        /// This will help visualizing user's gold count.
        /// </remarks>
        public float CurrentGold { get; private set; }

        #endregion

        #region Monobehaviour

        /// <summary>
        /// Increases the ammount og gold this user have.
        /// </summary>
        private void Update()
        {
            CurrentGold = Mathf.Min(CurrentGold + _goldPerSecond * Time.deltaTime, _maxGoldCount);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked whenever user plays a card.
        /// </summary>
        public void ChangeGoldCount(float delta)
        {
            CurrentGold += delta;
        }

        /// <summary>
        /// Restarts user gold count.
        /// </summary>
        public void Restart()
        {
            CurrentGold = _startingGold;
        }

        #endregion

    }

}