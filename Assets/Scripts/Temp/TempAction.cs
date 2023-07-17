using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TempAction : MonoBehaviour
{
    delegate void NumDelegate(int Num);
    NumDelegate numDelegate;
    event Action<int> numAction; // delegate ü���� ���� ��, event �� ����ϴ� ���� ����.
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
        Debug.Log("�׽�Ʈ ���Դϴ�.");
    }

    [ContextMenu("����")]
    private void Test()
    {
        numAction?.Invoke(10); // null �� ��쿡�� �������� �ʵ��� ���ش�.
        numAction(10); // null �� ��� nullReference ������ �����.
    }
}
