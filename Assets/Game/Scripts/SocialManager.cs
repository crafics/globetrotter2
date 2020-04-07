using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Nakama;
using Game.Scripts.Utils;
using Game.Scripts.Session;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

namespace Game.Scripts
{
    public class SocialManager : Singleton<SocialManager>
    {
        // Start is called before the first frame update
        async void Start()
        {
            //NakamaSessionManager.Instance.ConnectGoogle();

/*
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            // enables saving game progress.
            //.EnableSavedGames()
            // registers a callback to handle game invitations received while the game is not running.
            //.WithInvitationDelegate(<callback method>)
            // registers a callback for turn based match notifications received while the
            // game is not running.
            //.WithMatchDelegate(<callback method>)
            // requests the email address of the player be available.
            // Will bring up a prompt for consent.
            //.RequestEmail()
            // requests a server auth code be generated so it can be passed to an
            //  associated back end server application and exchanged for an OAuth token.
            //.RequestServerAuthCode(false)
            // requests an ID token be generated.  This OAuth token can be used to
            //  identify the player to other services such as Firebase.
            //.RequestIdToken()
            .Build();

            PlayGamesPlatform.InitializeInstance(config);
            // recommended for debugging:
            PlayGamesPlatform.DebugLogEnabled = true;
            // Activate the Google Play Games platform
            PlayGamesPlatform.Activate();
            SignIn();
*/          
        }

        void SignIn()
        {
            // authenticate user:
            //var session = await client.LinkFacebookAsync(session, accesstoken);
            //Debug.LogFormat("Session: '{0}'.", session.AuthToken);
            /*
            Social.localUser.Authenticate(success => {
            if (success)
            {
                Debug.Log("Authentication successful");
                string userInfo = "Username: " + Social.localUser.userName +
                    "\nUser ID: " + Social.localUser.id +
                    "\nIsUnderage: " + Social.localUser.underage;
                Debug.Log(userInfo);
                Debug.Log(Social.localUser);
            }
            else
                Debug.Log("Authentication failed");
            });
            */
            //Social.localUser.Authenticate((bool success) => {
            // handle success or failure
            //Debug.Log("test2");
            //});
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}