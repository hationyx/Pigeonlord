using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    // Bullet prefab to spawn
    public GameObject bulletPrefab;

    // Pre-defined bullet speed, can be edited in the Unity Editor
    public float BulletSpeed = 300;

    // Pre-defined time between shots, the player can roughly shoot 3 bullets per second
    public float TimeBetweenShots = 0.3f;

    private float timeStamp;

    private Vector2 Force = new Vector2(1000, 0);
    

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        SpawnBullets();
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
        Clone = (Instantiate(bulletPrefab, transform.position, transform.rotation)) as GameObject;
        
        // Adds defined force to move the bullet in the correct direction
        Clone.GetComponent<Rigidbody2D>().AddForce(Force,0);


    }

    void Powerups()
    {
        // TODO: Check and use shooting powerups
    }
}
