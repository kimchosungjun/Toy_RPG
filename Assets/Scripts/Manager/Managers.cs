using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance; 
    static Managers Instance { get { Init(); return instance; } } 

    InputManager input = new InputManager();
    public static InputManager Input { get { return Instance.input; } }

    ResourceManager resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance.resource; } }

    UIManager uiManager = new UIManager();
    public static UIManager UIManager { get { return Instance.uiManager; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        input.OnUpdate();
    }

    static void Init()
    {
        if (instance == null)
        {
			GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {  
                go = new GameObject { name = "@Managers"};
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            instance = go.GetComponent<Managers>();
		}		
	}
}
