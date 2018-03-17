using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public bool directionRight { get; set; }

    private float backingSpeed = 0.35F;

	// Use this for initialization
	void Start ()
    {
        directionRight = true;
	}

    // Update is called once per frame

    private void Update()
    {
        Debug.Log(Input.GetKey(KeyCode.Joystick1Button0));
        if (Input.GetButtonDown("Turn"))
        {
            turnAround();
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

        speedDirection = directionRight ? (dir.x < 0 ? backing : speed) : (dir.x > 0 ? backing : speed);

        float currentSpeed = dir.x * speedDirection * Time.deltaTime;
        transform.Translate(Vector3.right * currentSpeed);

        Debug.Log("CurSpeed: " + currentSpeed);
    }


    private void turnAround()
    {
        directionRight = !directionRight;
        // What will this do with animation? 
        Vector3 scale = transform.localScale;
        scale.x = directionRight ? scale.x : scale.x * -1;
        transform.localScale = scale;
    }
}
