using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton : MonoBehaviour
{ 
    private static bool mIsDestroying;
    
    private static MonoSingleton mInstance;
    public static MonoSingleton Instance
    {
        get
        {
            if(mIsDestroying) return null;
            if(mInstance == null)
            {
               mInstance = new GameObject("[MonoSingleton]")
                   .AddComponent<MonoSingleton>(); 
               DontDestroyOnLoad(mInstance.gameObject);
            }
            return mInstance;
        }
    }
    
    void OnDestroy()
    {
        mIsDestroying = true;
    }

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
