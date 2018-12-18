using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private static object _lock = new object();

    //public class CSPrefabMng : CSSingleton<CSPrefabMng> {   <<  이렇게 상속만 받아주면 됨

    public static T I
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed on application quit." +
                    " Won't create again - returning null.");
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton!" +
                            " Reopenning the scene might fix it.");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        /* GameObject singleton = new GameObject();
                         _instance = singleton.AddComponent<T>();
                         singleton.name = "(singleton) " + typeof(T).ToString();

                         // DontDestroyOnLoad(singleton);

                         Debug.Log("[Singleton] An instance of " + typeof(T) +
                             " is needed in the scene, so '" + singleton +
                             "' was created with DontDestroyOnLoad.");*/
                        return null;
                    }
                    else
                    {
                        //   Debug.Log("[Singleton] Using instance already created: " +
                        //     _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }
    }

    private static bool applicationIsQuitting = false;


    public void OnDestroy()
    {
        _instance = null;
        applicationIsQuitting = false;
    }

    public void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }
}
