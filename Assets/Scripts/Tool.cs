using UnityEngine;
public abstract class Tool : MonoBehaviour{
	protected bool activated;
	
	public bool isActivated(){
		return activated;
	}

	public void setActivated(bool activated){
		this.activated = activated;
	}
}
