using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Nakama;
using Game.Scripts.Utils;

namespace Game.Scripts
{
    public class Universe : Singleton<Universe>
    {
        #region Fields

        public GameObject camera;

        public GameObject sun;

        public GameObject globe;

        #endregion

        #region Mono

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(camera);
            DontDestroyOnLoad(sun);
            DontDestroyOnLoad(globe);
            StartCoroutine(LoadMainCoroutine());
        }

        #endregion

        /// <summary>
        /// Loads main menu scene and then leaves match
        /// </summary>
        /// <returns></returns>
        private IEnumerator LoadMainCoroutine()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
            while (operation.isDone == false)
            {
                yield return null;
            }
        }


    }

}