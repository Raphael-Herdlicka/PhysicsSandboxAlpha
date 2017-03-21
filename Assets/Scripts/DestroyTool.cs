using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTool : RapidFiringTool {
    protected override void DoRapidFireUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if(hit.transform.tag == "CreatedByPlayer")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
