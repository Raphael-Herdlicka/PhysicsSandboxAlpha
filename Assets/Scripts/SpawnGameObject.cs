using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnGameObject : RapidFiringTool
    {
        [Header("Specific Settings")]
        [SerializeField]
        private GameObject go;

        [SerializeField]
        private GameObject particleEffect;

        public SpawnGameObject(GameObject particleEffect, GameObject go)
        {
            this.particleEffect = particleEffect;
            this.go = go;
        }

        protected override void DoRapidFireUpdate(RaycastHit hit)
        {
            Instantiate(go, hit.point + Vector3.up, Quaternion.identity);
        }
    }
}
