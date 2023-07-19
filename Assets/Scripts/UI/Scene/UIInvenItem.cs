using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInvenItem : UIBase
{

    enum GameObjects
    {
        ItemIcon,
        ItemNameText,
    }

    string _name;

    private void Start()
    {
        Init();    
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;
        //Get<GameObject>((int)GameObjects.ItemIcon).AddUIEvenet((PointerEventData) => { Debug.Log($"아이템 클릭! {_name}"); });
    }

    public void SetInfo(string _name)
    {
        this._name = _name;
    }
}
