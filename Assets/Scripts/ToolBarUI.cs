using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Image))]
    // ReSharper disable once InconsistentNaming
    public class ToolBarUI : MonoBehaviour
    {
        [SerializeField]
        private ToolManager toolManager;

        [SerializeField]
        private float size = 20;

        [SerializeField]
        private float padding;

        [SerializeField]
        private float margin;

        private Image image;

        private RectTransform trans;

        [SerializeField]
        private GameObject toolImage;

        private List<GameObject> toolImages;

        private int lastCurrentTool = -1;

        public ToolBarUI(ToolManager toolManager, float padding, float margin, GameObject toolImage)
        {
            this.toolManager = toolManager;
            this.padding = padding;
            this.margin = margin;
            this.toolImage = toolImage;
        }

        void Start()
        {
            image = GetComponent<Image>();
            trans = GetComponent<RectTransform>();
            toolImages = new List<GameObject>();

            int toolCount = toolManager.Tools.Count;
            trans.sizeDelta = new Vector2(((size * toolCount) + (toolCount * padding + padding)) + (margin * 2), size + (padding * 2) + (margin * 2));
            for (int i = 0; i < toolCount; i++)
            {
                GameObject toolInstance = Instantiate(toolImage) as GameObject;
                toolInstance.transform.SetParent(transform);

                toolInstance.GetComponent<RectTransform>().localPosition = new Vector2((-((trans.sizeDelta.x) / 2 - size / 2) + padding + margin) + i * (padding + size), 0);
                toolImages.Add(toolInstance);
            }

            toolImages[toolManager.CurrentTool].GetComponent<Image>().color = Color.red;
        }

        void Update()
        {
            if (lastCurrentTool != -1)
            {
                if (lastCurrentTool != toolManager.CurrentTool)
                {
                    toolImages[lastCurrentTool].GetComponent<Image>().color = Color.white;
                    toolImages[toolManager.CurrentTool].GetComponent<Image>().color = Color.red;
                }
            }
            lastCurrentTool = toolManager.CurrentTool;
        }

    }
}
