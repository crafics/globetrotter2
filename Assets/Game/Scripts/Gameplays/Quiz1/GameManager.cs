using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Scripts.Gameplays.Quiz1.UI;
using Game.Scripts.Gameplays.Quiz1.NetworkCommunication;
using Game.Scripts.Gameplays.Quiz1.NetworkCommunication.MatchStates;
using Game.Scripts.Session;
using Game.Scripts.Utils;
using Nakama;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1
{
    public class GameManager : Singleton<GameManager>
    {
        #region Fields
        //[SerializeField] private Transform _cameraHolder = null;
        //[SerializeField] private SummaryMenu _summary = null;
        private float _timerStart;
        #endregion

        #region Monobehaviour

        private void Start()
        {
            MatchCommunicationManager.Instance.OnGameEnded += OnGameEnded;

            if (MatchCommunicationManager.Instance.GameStarted == true)
            {
                OnMatchJoined();
            }
            else
            {
                MatchCommunicationManager.Instance.OnGameStarted += OnMatchJoined;
            }
        }

        protected override void OnDestroy()
        {
            MatchCommunicationManager.Instance.OnGameStarted -= OnMatchJoined;
            MatchCommunicationManager.Instance.OnGameEnded -= OnGameEnded;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                MatchCommunicationManager.Instance.LeaveGame();
            }
        }

        #endregion

        #region Methods

        /*
        public void InitMap(Node[,] nodes, Vector2Int mapSize)
        {
            Nodes = nodes;
            MapSize = mapSize;
        }
        */

        private async Task SendMatchMessageUnitSpawnedAsync()
        {
            MatchMessageUnitSpawned message = new MatchMessageUnitSpawned("abc",2,3,4);
            //string json = JsonUtility.ToJson(message, true);
            //string json = MatchMessage<T>.ToJson(message);
            MatchCommunicationManager.Instance.SendMatchStateMessage(MatchMessageType.UnitSpawned, message);
        }

        private async void OnMatchJoined()
        {
            MatchCommunicationManager.Instance.OnGameStarted -= OnMatchJoined;
            await SendMatchMessageUnitSpawnedAsync();
            /*
            foreach (IUserPresence presence in MatchCommunicationManager.Instance.Players)
            {
                await SendMatchMessageUnitSpawnedAsync(presence);
            }
            */
        }

        private async void OnGameEnded(MatchMessageGameEnded message)
        {
        }

        #endregion
    }
}