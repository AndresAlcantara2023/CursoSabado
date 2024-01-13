using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Domain.Services;
using Cysharp.Threading.Tasks;
using Shared;
using System.Threading.Tasks;

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
            //await Task.Delay(1500);
            //await _senceLoad.LoadScenceAsync(AppDefaults.MainScene);
            var watingTime = Task.Delay(1500);
            var sceneLoad =  _senceLoad.LoadScenceAsync(AppDefaults.MainScene);

            await Task.WhenAll(watingTime, sceneLoad.AsTask());
            _senceLoad.ActivateScene();
        }



    }
}