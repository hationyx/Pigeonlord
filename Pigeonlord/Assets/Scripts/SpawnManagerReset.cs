using UnityEngine;
using System.Collections;

public class SpawnManagerReset : MonoBehaviour {


	void Start () {
	
	}
	
	//trigger to destroy the spawn manager so the game restarts, happens when the games goes back to the "playing" state, so the enemies keep flying across in the game over screen to taunt the player
	void Update () {
		if (Mangement.despawnStuff == true) {
			Destroy (gameObject);
		}
	}
}
