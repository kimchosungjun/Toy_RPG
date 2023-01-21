using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        //이 방식은 부하를 많이 주므로, Find는 쓰지 말아야 한다.
        //GameObject go = GameObject.Find("Managers");
        //Managers mg = go.GetComponent<Managers>();
        Managers mg = Managers.Instance;
    }

    void Update()
    {
        
    }
}
