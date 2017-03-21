using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnGameObject : RapidFiringTool
    {
        [SerializeField]
        private GameObject go;

        [SerializeField]
        private GameObject particleEffect;

        public SpawnGameObject(GameObject particleEffect, GameObject go)
        {
            this.particleEffect = particleEffect;
            this.go = go;
        }

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
}
