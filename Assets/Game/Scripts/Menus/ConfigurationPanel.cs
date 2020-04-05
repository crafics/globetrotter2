using UnityEngine;
using UnityEngine.UI;
using Game.Scripts.Session;
using System.Collections;
using Nakama;

namespace Game.Scripts.Menus
{

    public class ConfigurationPanel : SingletonMenu<ConfigurationPanel>
    {

        #region Properties
        private Client Client { get { return NakamaSessionManager.Instance.Client; } }
        private ISession Session { get { return NakamaSessionManager.Instance.Session; } }
        #endregion

        #region Mono

        /// <summary>
        /// Calls <see cref="Init"/> method upon connecting to Nakama.
        /// </summary>
        /*private void Awake()
        {
            //base.SetBackButtonHandler(MenuManager.Instance.HideTopMenu);
            if (NakamaSessionManager.Instance.IsConnected == false)
            {
                NakamaSessionManager.Instance.OnConnectionSuccess += Init;
            }
            else
            {
                Init();
            }
        }*/

        public override void Show()
        {
            //Client client = NakamaSessionManager.Instance.Client;
            //ISession session = NakamaSessionManager.Instance.Session;
            base.Show();
            Init();
        }

        /*public override void Hide()
        {
            base.Hide();
        }*/


        /*public override void Hide()
        {
            base.Hide();
            //MenuManager.Instance.HideTopMenu();
            //MenuManager.Instance.ShowMenu(null, true);
            //base.Hide();
            //MenuManager.Instance.ShowMenu(LoadingMenu.Instance, true);
            //MenuManager.Instance.HideTopMenu();
            //MenuManager.Instance.HideTopMenu();
        }*/

        #endregion

        #region Methods

        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(1);
            MenuManager.Instance.HideTopMenu();
        }

        async private void Init()
        {
            //NakamaSessionManager.Instance.OnConnectionSuccess -= Init;

            ConfigurationOperationResponse res = await ConfigurationManager.ReadAsync();
            var output = JsonUtility.ToJson(res, true);
            MenuManager.Instance.HideTopMenu();
            //StartCoroutine(WaitCoroutine());
            
            //Debug.Log("YESYESYES: " + output);

            //var rpcid = "rc";
            //var pokemonInfo = await Client.RpcAsync(Session, rpcid, payload);
            //IApiRpc responsePayload = await client.RpcAsync(session, "merge_cards", payload);
            //ConfigurationOperationResponse response = Nakama.TinyJson.JsonParser.FromJson<ConfigurationOperationResponse>(responsePayload.Payload);
            //Debug.LogFormat("AAA Read objects: [{0}]", string.Join(",\n  ", response));

            /*
            var result = await Client.ReadStorageObjectsAsync(Session, new StorageObjectId
            {
                Collection = "configuration",
                Key = "rc",
                UserId = null
            });
            Debug.LogFormat("BBB Read objects: [{0}]", string.Join(",\n  ", result.Objects));
            */

        }

        #endregion

    }

}