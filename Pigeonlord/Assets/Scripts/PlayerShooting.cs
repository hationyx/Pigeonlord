using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    // Bullet prefab to spawn
    public GameObject bulletPrefab;

    // Pre-defined bullet speed, can be edited in the Unity Editor
    public float BulletSpeed = 300;
	//times for how long the upgrades are active
	private float elapsedTime = 0f;
	private float elapsedTimePenetrator = 0f;

    // Pre-defined time between shots, the player can roughly shoot 3 bullets per second
    public float TimeBetweenShots = 0.8f;
    private float timeStamp;

	public static bool rapidFireSwitchOff;

    private Vector2 Force = new Vector2(1000, 0);

	public AudioClip penetrate;
	AudioSource audio;

	void Awake ()
	{
		audio = GetComponent<AudioSource>();
	}
	void Start ()
    {
	
	}
	

	void Update ()
	{
		SpawnBullets ();
		//this is two timers for the rapid fire and penetrator pick up
		if (PlayerMovement.rapidFireSwitch == true) {
			
			TimeBetweenShots = 0.15f;
			elapsedTime += Time.deltaTime;
			//Debug.Log (elapsedTime);
			if (elapsedTime >= 3) {
				PlayerMovement.rapidFireSwitch = false;
				elapsedTime = 0f;
				TimeBetweenShots = 0.5f;
			}
		} 
			
		if (PlayerMovement.penetratorSwitch == true) {
			elapsedTimePenetrator += Time.deltaTime;
			//Debug.Log (elapsedTimePenetrator);
			if (elapsedTimePenetrator >= 4) {
				PlayerMovement.penetratorSwitch = false;
				elapsedTimePenetrator = 0f;
			}
		}

	

	}

    // Method to spawn bullets

    void SpawnBullets()
    {
        // Checks if Spacebar is down and enough time has passed 
        // Since the last bullet was fired
        if (Input.GetButton("Jump") && (Time.time > timeStamp))
        {
            FireBullet();
            timeStamp = Time.time + TimeBetweenShots;
        }
    }

    // Method called when player presses the fire button
    // Spawns the bullet and sets its velocity 
    void FireBullet()
    {
        GameObject Clone;

        // Creates the bullet and spawns it into the world

        Vector3 pos = transform.position;
        pos.x += 2f;
        Clone = (Instantiate(bulletPrefab, pos, transform.rotation)) as GameObject;
        
        // Adds defined force to move the bullet in the correct direction
        Clone.GetComponent<Rigidbody2D>().AddForce(Force, 0);

		if (PlayerMovement.penetratorSwitch == true) {
			audio.PlayOneShot (penetrate, 0.7f);
		}
    }


}