using UnityEngine;
using System.Collections;

public class OutOfBoundsDelete : MonoBehaviour {




   
   
    void Start ()
    {
	
    


    }
	
	// Update is called once per frame
	void Update () 
    {
	   if (gameObject.transform.position.x< -20)
        {
            Destroy(gameObject);
}
        if (gameObject.transform.position.x > 20)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y< -20)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y > 20)
        {
            Destroy(gameObject);
        }
	}
}
