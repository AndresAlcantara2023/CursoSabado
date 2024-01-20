using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Magas.SystemUtilities;

namespace App.Server
{ 
    public interface IGetCountryData
    {
        UniTask<Optional<DataResult>> Get(string ip, List<string> keys);
    }

    public record DataResult(Dictionary<string,string> data);
}