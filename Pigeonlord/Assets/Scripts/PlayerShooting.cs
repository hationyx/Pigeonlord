using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;

    public float BulletSpeed = 300;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject Clone;
        

        Clone = (Instantiate(bulletPrefab, transform.position, transform.rotation)) as GameObject;

        Clone.GetComponent<Rigidbody>().AddForce(BulletSpeed, 0, 0);
    }

    void DespawnBullets()
    {

    }
}
