using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : UIBase
{ 
    public override void Init()
    {
        Managers.UIManager.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopupUI()
    {
        Managers.UIManager.ClosePopupUI(this);
    }
}
