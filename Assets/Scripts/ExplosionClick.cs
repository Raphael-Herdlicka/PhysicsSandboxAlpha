using UnityEngine;

public class ExplosionClick : Tool
{
    [SerializeField]
    private float radius = 3f;
    [SerializeField]
    private float power = 300f;
    [SerializeField]
    private GameObject particleEffect;

    void Update()
    {
        if (activated)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    explodeAtPosition(hit.point);
                }
            }
        }
    }

    public void explodeAtPosition(Vector3 pos)
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
