/**
 * Copyright 2019 Heroic Labs and contributors
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

using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Scripts.Session;
using Nakama;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Menus
{
    public static class ConfigurationManager
    {
        public static async Task<ConfigurationOperationResponse> ReadAsync()
        {
            Client client = NakamaSessionManager.Instance.Client;
            ISession session = NakamaSessionManager.Instance.Session;

            var payload = "{\"PokemonName\": \"dragonite\"}";

            IApiRpc responsePayload = await client.RpcAsync(session, "remote_configuration", payload);
            ConfigurationOperationResponse response = Nakama.TinyJson.JsonParser.FromJson<ConfigurationOperationResponse>(responsePayload.Payload);

            return response;
            /*
            var pokemonInfo = await Client.RpcAsync(Session, rpcid, payload);
            */

            //IApiRpc responsePayload = await client.RpcAsync(session, "rc", payload);
            //CardOperationResponse response = Nakama.TinyJson.JsonParser.FromJson<CardOperationResponse>(responsePayload.Payload);

            //Task<IApiRpc> responsePayload = client.RpcAsync(session, rpcid, payload);
            //CardOperationResponse response = Nakama.TinyJson.JsonParser.FromJson<CardOperationResponse>(responsePayload.Payload);
            /*

            Dictionary<string, Dictionary<string, string>> cardPayload = new Dictionary<string, Dictionary<string, string>>
        {
            { "first", card1.Serialize() },
            { "second", card2.Serialize() }
        };
            string payload = Nakama.TinyJson.JsonWriter.ToJson(cardPayload);

            IApiRpc responsePayload = await client.RpcAsync(session, "merge_cards", payload);
            CardOperationResponse response = Nakama.TinyJson.JsonParser.FromJson<CardOperationResponse>(responsePayload.Payload);

            return response;
            */
        }

    }
}
