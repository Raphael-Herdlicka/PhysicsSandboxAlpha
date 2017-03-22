using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyTool : RapidFiringTool
    {
        [Header("Specific Settings")]
        [SerializeField]
        private float brushSize = 1;

        protected override void DoUpdate()
        {
            base.DoUpdate();
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                brushSize++;
            }
            if (Input.GetKeyDown(KeyCode.Minus) && brushSize > 0)
            {
                brushSize--;
            }
        }

        protected override void DoRapidFireUpdate(RaycastHit hit)
        {
            if (brushSize > 1)
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, brushSize);

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
