using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization


    private Rigidbody2D rb;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public double speed;

    private float x;
    private float y;

	void Start ()
	{
	    rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(x, y);
        speed = x;

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (!onGround)
        {
            y--;
        }
        else
        {

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Left();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Right();
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (!Input.anyKey)
        {
            if (x > 0 && x != 0)
            {
                x-= (float)0.1;
            }
            else if (x != 0 && x < 0)
            {
                x += (float)0.1;
            }
        }

    }
    void Jump()
    {
        if (onGround)
        {
            float percantage = (rb.velocity.x / 100) * 5;
            rb.velocity = new Vector2(rb.velocity.x - percantage, rb.velocity.y + 50);
        }
    }

    void Move(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    void Left()
    {
        Move(-10,0);
    }

    void Right()
    {
        Move(10, 0);
    }
}
