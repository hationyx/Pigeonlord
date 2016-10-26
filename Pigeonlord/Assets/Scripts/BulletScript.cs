using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 1.6f);
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void Collision()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ok");
        if (collision.collider.tag == "Enemy")
        {
            // TODO: Destroy bullet & enemy
            Debug.Log("Gottem!");
            Destroy(gameObject);
        }
    }
}
