using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UIButton : UIPopup
{
    int score = 0;
    enum GameObjects
    {
        testButton
    }

    private void Start()
    {
        Init();
    }

    public void OnButtonClicked()
    {
        score++;
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
        Get<Text>((int)Texts.ScoreText).text = "Bind Text";
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, UIEvent.Drag);
    }
}
