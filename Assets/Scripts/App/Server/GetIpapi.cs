using Cysharp.Threading.Tasks;
using Magas.SystemUtilities;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace App.Server
{

    public class GetIpapi : IGetCountryData
    {
        public async UniTask<Optional<DataResult>> Get(string ip, List<string> keys)
        {
            string uri = $"https://ipapi.co/{ip}/json/";
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                await webRequest.SendWebRequest();
                var dic = new Dictionary<string, string>();
                for (var i = 0; i < keys.Count; i++)
                {
                    dic.Add(keys[i], webRequest.downloadHandler.text);
                }

                var data = new DataResult(dic);
                return new Optional<DataResult>(data);

            }


        }
    }
}



