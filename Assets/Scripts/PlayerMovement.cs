using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
    private Rigidbody2D rb;

    private float x;
    private float y;

	void Start ()
	{
	    rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(x,y);

	    if (Input.GetKeyDown(KeyCode.A))
	    {
            Left();
	    } else if (Input.GetKeyDown(KeyCode.D))
	    {
            Right();
	    } else if (Input.GetKeyDown(KeyCode.Space))
	    {
            Jump();
	    } else if (Input.GetKeyUp(KeyCode.Space))
	    {
            Move(0);
	    } else if (Input.GetKeyDown(KeyCode.R))
	    {
            Move(-10);
	    }

	    if (!Input.anyKey)
	    {
            Move(0,0);
	    }
	}

    void Move(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    void Move(float y)
    {
        this.y = y;
    }

    void Left()
    {
        Move(-10,this.rb.velocity.y);
    }

    void Right()
    {
        Move(10, this.rb.velocity.y);
    }

    void Jump()
    {
        Move(this.rb.velocity.x,10);
    }
}
