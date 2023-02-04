using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour  where T : MonoBehaviour
{
    protected static T instance;
    public static bool IsInitialized = false;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance != null) IsInitialized = true;
            }
            if (instance == null)
            {
                instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                IsInitialized = true;
                Debug.Log("No Instance of type " + typeof(T).ToString() + " found. Creating new object.");
            }
            return instance;
        }
        set => instance = value;
    }
    protected void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            IsInitialized = true;
        }            
        else if (instance != this)
            DestroySelf();
    }
    


    private void DestroySelf()
    {
        
        if (Application.isPlaying)
            Destroy(this);
        else
            DestroyImmediate(this);
    }


    private void OnDestroy()
    {
        IsInitialized = false;
    }
}
