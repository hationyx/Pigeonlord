using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;

    public float BulletSpeed = 300;

    public float TimeBetweenShots = 0.3f;

    private float timeStamp;
    

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        SpawnBullets();
	}

    void SpawnBullets()
    {

        if (Input.GetButton("Jump") && (Time.time > timeStamp))
        {
            FireBullet();
            timeStamp = Time.time + TimeBetweenShots;
        }
    }


    void FireBullet()
    {
        GameObject Clone;    

        // Creates the bullet and spawns it into the world
        Clone = (Instantiate(bulletPrefab, transform.position, transform.rotation)) as GameObject;
        
        // Adds defined force to move the bullet in the correct direction
        Clone.GetComponent<Rigidbody>().AddForce(BulletSpeed, 0, 0);
    }
}
