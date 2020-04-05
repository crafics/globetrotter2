using System;

namespace Game.Scripts.Gameplays.Quiz1.Cards
{
    /// <summary>
    /// Stores response received after performing an operation on deck (e.g. card swap, card merge)
    /// </summary>
    [Serializable] public class CardOperationResponse
    {
        /// <summary>
        /// If true, operation was performed successfully.
        /// </summary>
        public bool response;

        /// <summary>
        /// If <see cref="response"/> is false, this will hold the error message
        /// </summary>
        public string message;
    }
}
