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

            if (RapidFire ? Input.GetMouseButton(0) : Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, maxRange))
                {
                    if (hit.distance < minRange) return;
                    DoRapidFireUpdate(hit);
                }
            }
        }

        protected abstract void DoRapidFireUpdate(RaycastHit hit);

    }
}
