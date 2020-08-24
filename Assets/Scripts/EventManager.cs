using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class EventManager
    {
        private static EventManager mInstance;

        public static EventManager Instance
        {
            get
            {
                return mInstance ?? (mInstance = new EventManager());
            }
        }
        
        Dictionary<string, Action<object[]>> mMessageDict = 
            new Dictionary<string, Action<object[]>>(32);
        
        Dictionary<string, object[]> mDispatchCacheDict = 
            new Dictionary<string, object[]>(16);
        
        private EventManager(){}

        public void Subscribe(string message, Action<object[]> action)
        {
            Action<object[]> value = null;

            if (mMessageDict.TryGetValue(message, out value))
            {
                value += action;
                mMessageDict[message] = value;
            }
            else
            {
                mMessageDict.Add(message, action);
            }
        }
            
    }
}