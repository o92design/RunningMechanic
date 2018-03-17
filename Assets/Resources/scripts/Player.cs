using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;

    public bool directionRight;
    public bool sprinting;

    private float backingSpeed = 0.35F;
    private float sprintSpeed = 1.35F;


	// Use this for initialization
	void Start ()
    {
        directionRight = true;
	}

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetButtonDown("Turn"))
        {
            turnAround();
        }

        if(Input.GetButtonDown("Sprint"))
        {
            toggleSprint();
        }
    }

    void FixedUpdate ()
    {
        move();
	}

    private void move()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        float speedDirection = 0;
        float backing = speed * backingSpeed;

        float forwardSpeed = sprinting ? speed * sprintSpeed : speed;

        speedDirection = directionRight ? (dir.x < 0 ? backing : forwardSpeed) : (dir.x > 0 ? backing : forwardSpeed);

        float currentSpeed = dir.x * speedDirection * Time.deltaTime;
        transform.Translate(Vector3.right * currentSpeed);

        Debug.Log("CurSpeed: " + currentSpeed);
    }

    private void toggleSprint()
    {
        sprinting = !sprinting;
    }

    private void turnAround()
    {
        directionRight = !directionRight;
        // What will this do with animation? 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
