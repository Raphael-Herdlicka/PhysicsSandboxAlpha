using UnityEngine;

public class DestroyAfterCoordinates : MonoBehaviour {

	[SerializeField]
	float yLimit;
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < yLimit){
			Destroy(gameObject);
		}
	}

}
