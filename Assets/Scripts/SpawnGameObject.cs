using UnityEngine;

public class SpawnGameObject : Tool
{
	[SerializeField]
	private GameObject go;
	[SerializeField]
    private GameObject particleEffect;

    void Update()
    {
        if (isActivated())
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Instantiate(go,hit.point+Vector3.up,Quaternion.identity);
                }
            }
        }
    }
}
