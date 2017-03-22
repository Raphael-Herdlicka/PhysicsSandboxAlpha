using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyTool : RapidFiringTool
    {
        

        protected override void DoRapidFireUpdate(RaycastHit hit)
        {
            if (BrushSize > 1)
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, BrushSize);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].tag == "CreatedByPlayer")
                    {
                        Destroy(colliders[i].gameObject);
                    }
                }
            }
            else if (hit.transform.tag == "CreatedByPlayer")
            {
                Destroy(hit.transform.gameObject);
            }
        }

    }
}
