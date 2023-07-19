using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInven : UIScene
{
    enum GameObjects
    {
        GridPanel
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);
        // ���� �κ��丮 ������ ����
        for(int i=0; i<8; i++)
        {
            GameObject item = Managers.Resource.Instantiate("SceneUI/UIInvenItem");
            item.transform.SetParent(gridPanel.transform);
            UIInvenItem uiInvenItem = Util.GetOrAddComponent<UIInvenItem>(item);
            uiInvenItem.SetInfo($"�����{i}��");
        }

    }
}
