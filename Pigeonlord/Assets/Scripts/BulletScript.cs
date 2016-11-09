using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 2f);
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

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Enemy", if it is...
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
