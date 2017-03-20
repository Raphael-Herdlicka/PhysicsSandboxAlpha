﻿using UnityEngine;
using System.Collections;
using System;

public abstract class RapidFiringTool : Tool
{
    [SerializeField]
    private bool RapidFire {
        get;
        set;
    }

    protected override void DoUpdate()
    {
        if (Input.GetMouseButtonDown(2))
        {
            RapidFire = !RapidFire;
        }

        if (RapidFire ? Input.GetMouseButtonDown(0) : Input.GetMouseButton(0))
        {
            DoRapidFireUpdate();
        }
    }

    protected abstract void DoRapidFireUpdate();
}
