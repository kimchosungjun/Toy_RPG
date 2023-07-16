using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour, IDragHandler , IPointerClickHandler
{ 
    public Action<PointerEventData> OnClickHandler=null;
    public Action<PointerEventData> OnDragHandler=null;

    public void OnDrag(PointerEventData eventData)
    {
        //position = eventData.position;
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null)
            OnClickHandler.Invoke(eventData);
    }
}
