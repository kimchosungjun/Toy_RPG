using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action keyAction = null;
    public Action<MouseEvent> mouseAction = null;
    bool pressed = false;

    public void OnUpdate()
    {
        if (Input.anyKey && keyAction != null)
            keyAction.Invoke();
        if (mouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                mouseAction.Invoke(MouseEvent.Press);
                pressed = true;
            }
            else
            {
                if(pressed)
                    mouseAction.Invoke(MouseEvent.Click);
                pressed = false;
            }
        }
    }
}
