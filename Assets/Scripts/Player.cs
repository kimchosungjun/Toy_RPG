using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        //�� ����� ���ϸ� ���� �ֹǷ�, Find�� ���� ���ƾ� �Ѵ�.
        //GameObject go = GameObject.Find("Managers");
        //Managers mg = go.GetComponent<Managers>();
        Managers mg = Managers.Instance;
    }

    void Update()
    {
        
    }
}
