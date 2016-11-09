﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


    // The forces that control Pigeon X
    // Speed determines the speed of our pigeon
    public float PlayerSpeed = 12f;
    



    //We've decided to use a Rigidbody to control our 'characters'
    private Rigidbody2D PlayerRigidbody;




    //setup for our keyboard inputs
    private float VerticalInputValue;
    private float HorizontalInputValue;





    //This function allows the player to move around in game space
    private void PlayerMoveFunction()
    {
        Vector2 movement = transform.up * VerticalInputValue * PlayerSpeed * Time.deltaTime;
        Vector2 movementH = transform.right * HorizontalInputValue * PlayerSpeed * Time.deltaTime;
        PlayerRigidbody.MovePosition(PlayerRigidbody.position + movement + movementH);

      

    }


    private void Boundaries()
    {
        Vector2 Pos = transform.position;
        Pos.x = Mathf.Clamp(Pos.x + HorizontalInputValue, -9.4f, -5.5f);
        Pos.y = Mathf.Clamp(Pos.y + VerticalInputValue, -4.2f, 4.1f);
        transform.position = Pos;
    }




    void Start ()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	





	void Update ()
    {
        VerticalInputValue = Input.GetAxis("Vertical");
        HorizontalInputValue = Input.GetAxis("Horizontal");
        Boundaries();
       
        //HorizontalMovement();
        //VerticalMovement();
    }

    void FixedUpdate()
    {
        PlayerMoveFunction();
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
