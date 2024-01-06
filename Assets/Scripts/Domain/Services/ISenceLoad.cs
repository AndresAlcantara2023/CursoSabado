using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Domain.Services
{
    public interface ISenceLoad
    {

        UniTask LoadScenceAsync(string scenceName);

    }
}