using UnityEngine;

namespace Assets.Scripts
{
    public class ExplosionClick : RapidFiringTool
    {
        [Header("Specific Settings")]
        [SerializeField]
        private float radius = 3f;

        [SerializeField]
        private float power = 300f;

        [SerializeField]
        private GameObject particleEffect;

        public ExplosionClick(GameObject particleEffect)
        {
            this.particleEffect = particleEffect;
        }

        protected override void DoRapidFireUpdate(RaycastHit hit)
        {
            ExplodeAtPosition(hit.point);
        }

        public void ExplodeAtPosition(Vector3 pos)
        {
            if (particleEffect != null)
            {
                Instantiate(particleEffect, pos, Quaternion.identity);
            }
            Collider[] colliders = Physics.OverlapSphere(pos, radius);
            foreach (Collider c in colliders)
            {
                Rigidbody rb = c.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, pos, radius, 3);
                }

            }
        }


    }
}
