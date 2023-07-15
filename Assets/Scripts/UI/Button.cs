using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Button : UIBase
{
    int score = 0;


    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Get<Text>((int)Texts.ScoreText).text = "Bind Text";
    }

    public void OnButtonClicked()
    {
        score++;
    }
}
