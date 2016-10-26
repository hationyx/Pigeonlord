using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


    // The forces that control Pigeon X
    // Will go here
    public float PlayerSpeed = 12f;
    

    private Rigidbody2D PlayerRigidbody;

    private float VerticalInputValue;
    private float HorizontalInputValue;

	private void VerticalMovement()
    {
        Vector2 movement = transform.up * VerticalInputValue * PlayerSpeed * Time.deltaTime;
        PlayerRigidbody.MovePosition(PlayerRigidbody.position + movement);
    }

    private void HorizontalMovement()
    {

    }


    void Start ()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        VerticalInputValue = Input.GetAxis("Vertical");
        HorizontalInputValue = Input.GetAxis("Horizontal");

        VerticalMovement();
        HorizontalMovement();
	}
}
