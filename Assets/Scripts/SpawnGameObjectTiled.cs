using System;
using UnityEngine;

public class SpawnGameObjectTiled : RapidFiringTool
{
    [SerializeField]
    private GameObject go;
    [SerializeField]
    private GameObject particleEffect;
    [SerializeField]
    private float interval = 1;

    protected override void DoRapidFireUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            /*TODO:
             * The current version of this doesnt work in the negative space and does all sorts of weirdness
             * 
             */
            Func<float, float> func = f =>
            {
                if (f % interval < interval / 2)
                {
                    return f - (f % interval);
                }
                else
                {
                    return f + (interval - f % interval);
                }
            };

            Vector3 point = hit.point;
            Vector3 tiledPos = new Vector3(func(point.x), func(point.y), func(point.z));

            Instantiate(go, tiledPos + Vector3.up, Quaternion.identity);
        }
    }
}
