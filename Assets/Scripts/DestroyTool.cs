using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyTool : RapidFiringTool
    {

        protected override void DoRapidFireUpdate(RaycastHit hit)
        {
            if (hit.transform.tag == "CreatedByPlayer")
            {
                Destroy(hit.transform.gameObject);
            }
        }

    }
}
