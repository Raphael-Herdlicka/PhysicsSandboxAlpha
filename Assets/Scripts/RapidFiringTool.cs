using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class RapidFiringTool : Tool
    {
        [Header("General Settings")]
        [SerializeField]
        private bool rapidFire;

        [SerializeField]
        private float minRange = 5f;

        [SerializeField]
        private float maxRange = 200f;

        [SerializeField]
        private int brushSize = 1;

        [SerializeField]
        private float rapidFireDelay = 0;
        
        private float rapidFireDelayTime = 0;

        private bool RapidFire {
            get {
                return rapidFire;
            }
            set {
                rapidFire = value;
            }
        }

        private float MinRange {
            get {
                return minRange;
            }
            set {
                minRange = value;
            }
        }

        private float MaxRange {
            get {
                return maxRange;
            }
            set {
                maxRange = value;
            }
        }

        public int BrushSize {
            get {
                return brushSize;
            }
            set {
                if (value > 0)
                    brushSize = value;
            }
        }

        public float RapidFireDelay {
            get {
                return rapidFireDelay;
            }
            set {
                if (value >= 0)
                {
                    rapidFireDelay = value;
                }
            }
        }

        protected override void DoUpdate()
        {
            //Increment/Decrement BrushSize
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                brushSize++;
            }
            if (Input.GetKeyDown(KeyCode.Minus) && brushSize > 0)
            {
                brushSize--;
            }

            if (Input.GetMouseButtonDown(2))
            {
                RapidFire = !RapidFire;
            }

            if (Input.GetMouseButton(0) && RapidFire && (rapidFireDelayTime <= 0 || rapidFireDelay <= 0))
            {
                rapidFireDelayTime = rapidFireDelay;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, maxRange))
                {
                    if (hit.distance < minRange) return;
                    DoRapidFireUpdate(hit);
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, maxRange))
                {
                    if (hit.distance < minRange) return;
                    DoRapidFireUpdate(hit);
                }
            }

            if (rapidFireDelayTime > 0)
            {
                rapidFireDelayTime -= Time.deltaTime;
            }
        }

        protected abstract void DoRapidFireUpdate(RaycastHit hit);

    }
}
