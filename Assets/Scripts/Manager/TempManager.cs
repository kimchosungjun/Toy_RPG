using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempManager : MonoBehaviour
{
    static TempManager instance =null;
    
    public static TempManager Instance
    {
        get
        {
            Init();
            return instance;
        }
    }

    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Manager");
            if (go == null)
            {
                go = new GameObject { name = "@Manager" };
                go.AddComponent<TempManager>();
            }
            DontDestroyOnLoad(go);
            instance = go.GetComponent<TempManager>();
        }
    }
}
