using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers m_instance; // static���� ���� ���ϼ� ����
    public static Managers Instance { get { return m_instance; }  } // �ܺο��� ������ �Ŵ����� �������� ����
   
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
