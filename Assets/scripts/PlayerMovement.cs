using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D player1;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;

    private enum MovementState { idle, running , jumping, falling  }

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpForce = 8f;

    private float dirX;


    // Start is called before the first frame update
    private void Start()
    {
        player1 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        player1.velocity = new Vector2 (dirX* movespeed, player1.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGorunded())
        {
            player1.velocity = new Vector2(player1.velocity.x, jumpForce);

        }
        UpdateAnimationState();
        


       

    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;

        }

        if(player1.velocity.y > .1f)
        {
            state = MovementState.jumping;

        }
        else if(player1.velocity.y < -.1f)
        { state = MovementState.falling;
        
        }

        anim.SetInteger("state", (int)state);

    }

    private bool IsGorunded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }
}
