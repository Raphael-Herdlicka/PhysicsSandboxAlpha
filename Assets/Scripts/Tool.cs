using UnityEngine;
public abstract class Tool : MonoBehaviour
{

    public bool Activated {
        get;
        set;
    }

    private void Update()
    {
        if (Activated)
        {
            DoUpdate();
        }
    }

    protected abstract void DoUpdate(); 

}
