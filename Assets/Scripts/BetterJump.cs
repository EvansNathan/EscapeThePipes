using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float fallMultiplier = 2.0f;
    [SerializeField] private float lowJumpMultiplier = 1.5f;
    public Rigidbody2D rb;

    // Update is called once per frame
     void awake()
    {
        rb = GetComponent<Rigidbody2D> ();
    }
    void Update()
    {
        if(rb.velocity.y < 0 )
        {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
		}
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
    
}

