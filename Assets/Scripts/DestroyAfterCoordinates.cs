using UnityEngine;

public class DestroyAfterCoordinates : MonoBehaviour {

	[SerializeField]
	float yLimit;
    
	void Update () {
		if(transform.position.y < yLimit){
			Destroy(gameObject);
		}
	}

}
