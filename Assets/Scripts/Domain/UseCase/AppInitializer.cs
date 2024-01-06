using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Domain.Services;
using Cysharp.Threading.Tasks;

namespace Domain.UseCases
{
    public class AppInitializer
    {
        private readonly ISenceLoad _senceLoad;

        public AppInitializer(ISenceLoad senceLoad)
        {
            _senceLoad = senceLoad;
            Initialize().Forget();
        }

        private async UniTaskVoid Initialize()
        {
            await _senceLoad.LoadScenceAsync("Main");
        }

    }
}