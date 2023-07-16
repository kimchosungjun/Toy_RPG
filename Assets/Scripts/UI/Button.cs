using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Button : UIBase
{
    int score = 0;


    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
        Get<Text>((int)Texts.ScoreText).text = "Bind Text";
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddEvent(go, (PointerEventData data) => { go.transform.position=data.position; }, UIEvent.Drag);
    }

    public void OnButtonClicked()
    {
        score++;
    }
}
