
using Nakama.TinyJson;

namespace Game.Scripts.Gameplays.Quiz1.NetworkCommunication.MatchStates
{
    /// <summary>
    /// Base class for all match messages
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MatchMessage<T>
    {
        /// <summary>
        /// Parses json gained from server to MatchMessage class object
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Parse(string json)
        {
            return JsonParser.FromJson<T>(json);
        }

        /// <summary>
        /// Creates string with json to be send as match state message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string ToJson(T message)
        {
            return JsonWriter.ToJson(message);
        }
    }
}
