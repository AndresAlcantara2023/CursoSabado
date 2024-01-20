using App.Server;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Domain.Services;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using System.Net;
using UnityEngine.Assertions;

//nabe space App.Server;
public abstract class CountryGetway : IGateway , IPreloadService
{
    private readonly Dictionary<string, string> _dirtyData = new();
    private readonly IGetCountryData _getCountryData;

    private Dictionary<string, string> _rawData = new();
    private Dictionary<Type, string> _typeToKey = new();
    private Dictionary<Type, IDataTransferObject> _parserData = new();

    private bool _isInitialized = false;
    protected string _ipAdrdress = default;

    public CountryGetway(IGetCountryData getCountryData)
    {
        _getCountryData = getCountryData;
    }

    protected abstract void InitializeType(out Dictionary<Type,string> typeToKey);


    public bool Contains<T>() where T : IDataTransferObject
    {
        throw new System.NotImplementedException();
    }

    public T Get<T>() where T : IDataTransferObject
    {
        Assert.IsTrue(_isInitialized, "The gateway is not initialized");
        var type = typeof(T);
        if (_parserData.TryGetValue(type, out var result)) return (T)result;
    }

    public void Set<T>(T dataTransferObject) where T : IDataTransferObject
    {
        throw new System.NotImplementedException();
    }
    
    public async UniTask Preload()
    {
        InitializeType(out _typeToKey);
        WebClient webClient = new();
        _ipAdrdress = await webClient.DownloadStringTaskAsync("https://api.ipify.org");

        List<string> keys = new();

        foreach (var pair in _typeToKey)
            keys.Add(pair.Value);

        var Data = await _getCountryData.Get(_ipAdrdress, keys);
        Data.IfPresent(result =>
        {
            _rawData = result.data;
            _parserData = new Dictionary<Type, IDataTransferObject>(_rawData.Count);
        }).OrElseThrow(
            new Exception("The data is not present")
        );

        _isInitialized = true;


    }
}
