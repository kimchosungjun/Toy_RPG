using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers m_instance; // static으로 인해 유일성 보장
    public static Managers Instance { get { return m_instance; }  } // 외부에서 유일한 매니저를 가져오기 위함
   
    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    static void Init()
    {
        if (m_instance == null)
        {
            GameObject go = GameObject.Find("Managers");
            if (go == null)
            {
                go = new GameObject { name = "Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            m_instance = go.GetComponent<Managers>();
        }
    }
}
