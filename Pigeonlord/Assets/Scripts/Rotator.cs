using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Rotate the transform of the game object this is attached to by 45 degrees, taking into account the time elapsed since last frame
        transform.Rotate(new Vector3(45, 45, 45) * Time.deltaTime *5);
    }
}

