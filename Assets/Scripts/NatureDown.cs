using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureDown : MonoBehaviour
{
    private const float FATIGUE_DEFAULT_VALUE = 12f;
    private const float SATIFATION_DEFAULT_VALUE = 5f;
    
    private const float FATIGUE_MIN_VALUE = 0.3f;
    private const float SATIFATION_MIN_VALUE = 0.2f;

    private float mSatiation;
    private float mFatigue;

    private Coroutine mActionCoroutine;

    private void OnEnable()
    {
        mSatiation = SATIFATION_DEFAULT_VALUE;
        mFatigue = FATIGUE_DEFAULT_VALUE;
        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        while (true)
        {
            mSatiation = Mathf.Max(0, mSatiation - Time.deltaTime);

            mFatigue = Mathf.Max(0, mFatigue - Time.deltaTime);

            // string mess = string.Format("mSatiation is {0}, mFatigue is {1}", mSatiation, mFatigue);
            // Debug.Log(mess);

            if (mSatiation <= SATIFATION_MIN_VALUE && mActionCoroutine == null)
            {
                mActionCoroutine = StartCoroutine(EatFood());
                Debug.Log("Eat Food");
            }
 
            if (mFatigue <= FATIGUE_MIN_VALUE)
            {
                mActionCoroutine = StartCoroutine(Sleep());
                Debug.Log("Sleeping");
            }
            yield return null;
        }

    }
    
    IEnumerator EatFood()
    {
        yield return new WaitForSeconds(1f);
        mSatiation = SATIFATION_DEFAULT_VALUE;
        mActionCoroutine = null;
        var monoSingleton = MonoSingleton.Instance;
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(2f);
        if (mActionCoroutine != null)
        {
            StopCoroutine(mActionCoroutine);
        }
        mFatigue = FATIGUE_DEFAULT_VALUE;
        mActionCoroutine = null;
    }
    
    void OnGUI()
    {
        GUILayout.Box("Satiation: " + mSatiation);
        GUILayout.Box("Fatigue: " + mFatigue);
    }

}
