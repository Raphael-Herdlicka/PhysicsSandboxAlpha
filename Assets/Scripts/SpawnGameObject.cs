using System;
using UnityEngine;

public class SpawnGameObject : RapidFiringTool
{
    [SerializeField]
    private GameObject go;
    [SerializeField]
    private GameObject particleEffect;

    protected override void DoRapidFireUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Instantiate(go, hit.point + Vector3.up, Quaternion.identity);
        }
    }
}
