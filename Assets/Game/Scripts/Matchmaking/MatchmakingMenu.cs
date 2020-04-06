/**
 * Copyright 2019 The Knights Of Unity, created by Pawel Stolarczyk
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Scripts.Gameplays.Quiz1.NetworkCommunication;
using Game.Scripts.Menus;
using Game.Scripts.Session;
using Game.Scripts.Configuration;
using Nakama;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Matchmaking
{

    /// <summary>
    /// Panel informing user about their matchmaking progress.
    /// </summary>
    public class MatchmakingMenu : Menu
    {
        #region Fields

        [SerializeField] public MatchmakingGame matchmakingGame = null;

        /// <summary>
        /// Sprite indicating match searching progress.
        /// </summary>
        [SerializeField] private Text _title = null;

        /// <summary>
        /// Sprite indicating match searching progress.
        /// </summary>
        [SerializeField] private RectTransform _rotatingSymbol = null;

        /// <summary>
        /// <see cref="_rotatingSymbol"/> rotation speed.
        /// </summary>
        [SerializeField] private float _degreesPerSecond = 90;

        /// <summary>
        /// Mathmaker ticker used to leave queue or join match.
        /// </summary>
        private IMatchmakerTicket ticket;

        #endregion

        #region Mono

        /// <summary>
        /// Rotates <see cref="_degreesPerSecond"/>.
        /// </summary>
        private void Update()
        {
            if (gameObject.activeInHierarchy == true)
            {
                _rotatingSymbol.Rotate(Vector3.forward, -_degreesPerSecond * Time.deltaTime);
            }
        }

        #endregion

        #region Methods

        private void Awake()
        {
            base.SetBackButtonHandler(MenuManager.Instance.HideTopMenu);
        }

        /// <summary>
        /// Joins matchmaker queue and shows this panel.
        /// </summary>
        public async override void Show()
        {
            this._title.text = this.matchmakingGame.name;
            base.Show();
            this.matchmakingGame.matchmakingParams.stringProperties = new Dictionary<string, string>()
            {
                { "scene", this.matchmakingGame.scene }
            };
            await StartMatchmakerAsync();
            /*
            if (IsShown == false)
            {
                base.Show();
                SetBackButtonHandler(MenuManager.Instance.HideTopMenu);
                await StartMatchmakerAsync();
            }
            */
        }

        /// <summary>
        /// Leaves matchmaker queue and hides this panel.
        /// </summary>
        public async override void Hide()
        {
            await StopMatchmakerAsync(ticket);
            base.Hide();
            /*
            if (IsShown == true)
            {
                await StopMatchmakerAsync(ticket);
                base.Hide();
            }
            */
        }

        /// <summary>
        /// Joins matchmaker queue.
        /// </summary>
        /// <remarks>
        /// Nakama allows for joining multiple matchmakers, however for the purposes of this demo,
        /// we will allow only for joining a single matchmaking queue.
        /// </remarks>
        private async Task<bool> StartMatchmakerAsync()
        {
            if (ticket != null)
            {
                Debug.Log("Matchmaker already started");
                return false;
            }

            ISocket socket = NakamaSessionManager.Instance.Socket;

            // Create params object with default values
            /*
            MatchmakingParams param = new MatchmakingParams();
            param.minUserCount = matchmakingGame.matchmakingParams;
            param.maxUserCount = matchmakingGame.maxUserCount;
            param.query = matchmakingGame.query;
            */

            socket.ReceivedMatchmakerMatched += OnMatchmakerMatched;
            // Join the matchmaker
            ticket = await MatchmakingManager.EnterQueueAsync(socket, matchmakingGame.matchmakingParams);
            if (ticket == null)
            {
                Debug.Log("Couldn't start matchmaker" + Environment.NewLine + "Try again later");
                socket.ReceivedMatchmakerMatched -= OnMatchmakerMatched;
                return false;
            }
            else
            {
                // Matchmaker queue joined
                return true;
            }
        }

        /// <summary>
        /// Invoked whenever matchmaker finds an opponent.
        /// </summary>
        private void OnMatchmakerMatched(IMatchmakerMatched e)
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                ISocket socket = NakamaSessionManager.Instance.Socket;
                socket.ReceivedMatchmakerMatched -= OnMatchmakerMatched;

                StartCoroutine(LoadBattle(e));
            });
        }

        /// <summary>
        /// Leaves matchmaker queue.
        /// </summary>
        private async Task<bool> StopMatchmakerAsync(IMatchmakerTicket ticket)
        {
            if (ticket == null)
            {
                Debug.Log("Couldn't stop matchmaker; matchmaking hasn't been started yet");
                return false;
            }
            ISocket socket = NakamaSessionManager.Instance.Socket;
            bool good = await MatchmakingManager.LeaveQueueAsync(socket, ticket);

            this.ticket = null;
            socket.ReceivedMatchmakerMatched -= OnMatchmakerMatched;
            return good;
        }

        /// <summary>
        /// Starts the game scene and joins the match
        /// </summary>
        private IEnumerator LoadBattle(IMatchmakerMatched matched)
        {
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(matchmakingGame.scene, UnityEngine.SceneManagement.LoadSceneMode.Additive);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("_MainScene");
            MatchCommunicationManager.Instance.JoinMatchAsync(matched);
        }

        #endregion
    }

}