using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Domain.Services
{ 
    public interface IPreloadService
    {
        UniTask Preload();
    }
}