using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene : UIBase
{
    public virtual void Init()
    {
        Managers.UIManager.SetCanvas(gameObject, false);
    }
}

