using UnityEngine;
using System.Collections;

public class DespawnStuff : MonoBehaviour {


	void Start () {
	
	}
	
	//despawns everything on screen when the game goes to the playing state, this stops enemies/pickups from the previous game being there at the start
	//since they stay there during the game over screen
	void Update () {
		Despawn ();
	}
	private void Despawn() {
		if (Mangement.despawnStuff == true) {
			Destroy (gameObject);
		}
	}
}
