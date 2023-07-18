using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int order = 10; // canvas의 sortorder 정보를 저장
    Stack<UIPopup> popupStack = new Stack<UIPopup>();
    UIScene uiScene = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("UIRoot");
            if (root == null)
                root = new GameObject { name = "UIRoot" };
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;
        if (sort)
        {
            canvas.sortingOrder = order;
            order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowSceneUI<T>(string name = null) where T : UIScene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T sceneUI  = Util.GetOrAddComponent<T>(go);
        uiScene = sceneUI;
        go.transform.SetParent(Root.transform);
        return null;
    }

    public T ShowPopupUI<T>(string name = null) where T : UIPopup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        popupStack.Push(popup);
        go.transform.SetParent(Root.transform);
        return null;
    }

    public void ClosePopupUI()
    {
        if (popupStack.Count == 0)
            return;
        UIPopup popup = popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
    }

    public void ClosePopupUI(UIPopup popup)
    {
        if (popupStack.Count == 0)
            return;
        if (popupStack.Peek() != popup)
            return;
        ClosePopupUI();
    }

    public void CloseAllPopupUI()
    {
        while (popupStack.Count > 0)
            ClosePopupUI();
    }
}
