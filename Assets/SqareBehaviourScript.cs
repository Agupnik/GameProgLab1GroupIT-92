using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqareBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 20f;
    private Rigidbody2D rb;
    public float jumpAmount = 7f;
    public bool IsPlayerOnGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");// -1 to 1

        if(moveX > 0 || moveX < 0)
        {
            rb.velocity = new Vector2(moveX * Speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsPlayerOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }
    }

    private void OnCollisionStay2D(Collision2D Coll)
    {
        if (Coll.gameObject.tag == "Platform")
        {
            IsPlayerOnGround = true;

        }

        if (Coll.gameObject.tag == "Spike")
        {
            IsPlayerOnGround = false;
            rb.velocity = new Vector2(rb.velocity.x, 10);
        }
    }

    private void OnCollisionExit2D(Collision2D Coll)
    {
        if (Coll.gameObject.tag == "Platform")
        {
            IsPlayerOnGround = false;

        }
    }
}
