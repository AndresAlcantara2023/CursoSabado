using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Server
{
    public interface IGateway
    {
        T Get<T>() where T : IDataTransferObject;
        bool Contains<T>() where T : IDataTransferObject;
        void Set<T>(T dataTransferObject) where T : IDataTransferObject;
    }
}


