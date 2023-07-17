using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TempAction : MonoBehaviour
{
    delegate void NumDelegate(int Num);
    NumDelegate numDelegate;
    event Action<int> numAction; // delegate 체인을 만들 땐, event 를 사용하는 것이 좋다.
    Action testAction;

    private void Start()
    {
        numDelegate += PlusOneMore;
        numAction += PlusOneMore;
        // numAction += TestAction;
        testAction += TestAction;
    }

    void PlusOneMore(int num)
    {
        num *= 2;
        Debug.Log(num);
    }

    void TestAction()
    {
        Debug.Log("테스트 중입니다.");
    }

    [ContextMenu("실행")]
    private void Test()
    {
        numAction?.Invoke(10); // null 인 경우에는 실행하지 않도록 해준다.
        numAction(10); // null 인 경우 nullReference 문제가 생긴다.
    }
}
