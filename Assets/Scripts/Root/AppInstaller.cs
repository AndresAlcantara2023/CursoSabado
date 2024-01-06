using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Domain.Services;
using Domain.UseCases;
using App.Services;


public class AppInstaller : MonoBehaviour
{
    private ISenceLoad _senceLoad;

    private void Start()
    {
        _senceLoad = new UnityScenceLoad();
        var app = new AppInitializer(_senceLoad);
        DontDestroyOnLoad(target:this);
    }
}
