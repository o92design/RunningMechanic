using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public enum DIRECTION
    {
        LEFT,
        RIGHT
    }

    public float speed;
    public DIRECTION direction { get; set; }

    private float backingSpeed = 0.35F;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        move();
	}

    private void move()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        float speedDirection = dir.x < 0 ? speed * backingSpeed : speed;
        float currentSpeed = dir.x * speedDirection * Time.deltaTime;
        transform.Translate(Vector3.right * currentSpeed);

        Debug.Log("CurSpeed: " + currentSpeed);
    }
}
