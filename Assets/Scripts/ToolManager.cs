﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [SerializeField]
    private List<Tool> tools;
    [SerializeField]
    private int currentTool = 0;

    // Use this for initialization
    void Start()
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
                tools[i].setActivated(false);
            }
            else
            {
                tools.RemoveAt(i);
                i -= 1;
            }
        }
        tools[0].setActivated(true);
    }

    // Update is called once per frame
    void Update()
    {
        float scrollWheelValue = Input.GetAxisRaw("Mouse ScrollWheel");
        if (scrollWheelValue != 0)
        {
            tools[currentTool].setActivated(false);
            changeTool(scrollWheelValue > 0);
            tools[currentTool].setActivated(true);
        }
    }

    void changeTool(bool up)
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