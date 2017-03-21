using UnityEngine;

namespace Assets.Scripts
{
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
}
