using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnGameObjectTiled : RapidFiringTool
    {
        [Header("Specific Settings")]
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

        protected override void DoRapidFireUpdate(RaycastHit hit)
        {
            if (hit.distance < 3) return;
            Func<float, float> func = f =>
            {
                if (f >= 0)
                {

                    float modulo = f % interval;
                    if (modulo < interval / 2)
                    {
                        return f - modulo;
                    }
                    else
                    {
                        return f + (interval - modulo);
                    }
                }
                else
                {
                    float regularMod = Mathf.Abs(f % interval);
                    float intervalMod = interval - regularMod;
                    if (regularMod < (interval / 2))
                    {
                        return f + regularMod;

                    }
                    else
                    {
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
