using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [SerializeField]
    private List<Tool> tools;
    [SerializeField]
    private int currentTool = 0;

    public int CurrentTool {
        get {
            return currentTool;
        }
        private set {
            currentTool = value;
        }
    }

    public List<Tool> Tools {
        get {
            return tools;
        }
        private set {
            tools = value;
        }
    }

    // Use this for initialization
    void Awake()
    {
        //ADD ALL TOOLS WHICH ARE NOT ALREADY PRESENT
        Component[] components = gameObject.GetComponents<Tool>();
        foreach (Component c in components)
        {
            if (!tools.Contains((Tool)c))
            {
                tools.Add((Tool)c);
            }
        }



        for (int i = 0; i < tools.Count; i++)
        {
            if (tools[i] != null)
            {
                tools[i].Activated = false;
            }
            else
            {
                tools.RemoveAt(i);
                i -= 1;
            }
        }
        tools[currentTool].Activated = true;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollWheelValue = -Input.GetAxisRaw("Mouse ScrollWheel");
        if (scrollWheelValue != 0)
        {
            tools[currentTool].Activated = false;
            ChangeTool(scrollWheelValue > 0);
            tools[currentTool].Activated = true;
        }
    }

    void ChangeTool(bool up)
    {
        if (up)
        {
            if (currentTool == tools.Count - 1)
            {
                currentTool = 0;
            }
            else
            {
                currentTool++;
            }
        }
        else
        {
            if (currentTool == 0)
            {
                currentTool = tools.Count - 1;
            }
            else
            {
                currentTool--;
            }
        }


    }
}
