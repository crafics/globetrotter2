
namespace Game.Scripts.Gameplays.Quiz1.NetworkCommunication.MatchStates
{

    /// <summary>
    /// Used to store incomming messages while the match hasn't started yet.
    /// </summary>
    public class IncommingMessageState
    {

        #region Fields

        /// <summary>
        /// The code of incomming message.
        /// </summary>
        public long opCode;

        /// <summary>
        /// Data send with incomming message.
        /// </summary>
        public string message;

        #endregion

        public IncommingMessageState(long opCode, string message)
        {
            this.opCode = opCode;
            this.message = message;
        }

    }

}