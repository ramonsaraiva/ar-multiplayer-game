using UnityEngine;
using System.Collections;

public class DebugManagerBehaviour : MonoBehaviour
{
    private static DebugUIBehaviour debugUI;
    private static DebugManagerBehaviour instance;

    private void Awake()
    {
        debugUI = GameObject.Find("DebugUI").GetComponent<DebugUIBehaviour>();
        print(debugUI);
    }

    private void Update()
    {
        debugUI.NetworkLatency();
    }

    public static DebugManagerBehaviour Instance
    {
        get
        {
            if (instance == null)
                instance = new DebugManagerBehaviour();

            return instance;
        }
    }

    public static DebugUIBehaviour DebugUI
    {
        get { return debugUI; }
    }
}

