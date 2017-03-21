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

    private GameObject tileContainer;

    private void Start()
    {
        tileContainer = new GameObject(this.GetType().Name + "Container");
    }

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
                if (f >= 0)
                {

                    float modulo = f % interval;
                    print("positive | input: " + f + " | modulo: " + modulo);
                    if (modulo < interval / 2)
                    {
                        print("result 1 : " + (f - modulo));
                        print("--------------------------------------------------------------");
                        return f - modulo;
                    }
                    else
                    {
                        print("result 2 : " + (f + (interval - modulo)));
                        print("--------------------------------------------------------------");
                        return f + (interval - modulo);
                    }
                }
                else
                {
                    float regularMod = Mathf.Abs(f % interval);
                    float intervalMod = interval - regularMod;
                    print("negative | input: " + f + " | regModulo: " + regularMod + " | intModulo: " + intervalMod);
                    if (regularMod < (interval / 2))
                    {
                        print("result 1 : " + (f + regularMod));
                        print("--------------------------------------------------------------");
                        return f + regularMod;

                    }
                    else
                    {
                        print("result 2 : " + (f - intervalMod));
                        print("--------------------------------------------------------------");
                        return f - intervalMod;

                    }
                }

            };

            Vector3 point = hit.point;
            Vector3 tiledPos = new Vector3(func(point.x), func(point.y), func(point.z));

            GameObject tileGo = Instantiate(go, tiledPos, Quaternion.identity) as GameObject;
            tileGo.transform.SetParent(tileContainer.transform);
        }
    }
}
