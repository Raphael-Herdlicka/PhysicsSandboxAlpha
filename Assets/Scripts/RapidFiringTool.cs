using UnityEngine;
using System.Collections;
using System;

public abstract class RapidFiringTool : Tool
{
    [SerializeField]
    private bool rapidFire;

    private bool RapidFire {
        get {
            return rapidFire;
        }
        set {
            rapidFire = value;
        }
    }

    protected override void DoUpdate()
    {
        if (Input.GetMouseButtonDown(2))
        {
            RapidFire = !RapidFire;
        }

        if (RapidFire ? Input.GetMouseButton(0) : Input.GetMouseButtonDown(0))
        {
            DoRapidFireUpdate();
        }
    }

    protected abstract void DoRapidFireUpdate();
}
