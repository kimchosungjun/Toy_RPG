using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputManager
{
    public Action <MouseEvent> mouseAction = null;
    bool pressed = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
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
