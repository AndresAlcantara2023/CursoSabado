using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Domain.Services;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

namespace App.Services
{
    public class UnityScenceLoad : ISenceLoad
    {
        private AsyncOperation _asyncOperation;

        public void ActivateScene()
        {
            _asyncOperation.allowSceneActivation = true;
        }

        public async UniTask LoadScenceAsync(string scenceName)
        {
            _asyncOperation = SceneManager.LoadSceneAsync(scenceName);
            _asyncOperation.allowSceneActivation = false;
            while (_asyncOperation.progress <= 0.89)
            {
                await Task.Yield();
            }

            //_asyncOperation.allowSceneActivation = true;

        }
    }
}