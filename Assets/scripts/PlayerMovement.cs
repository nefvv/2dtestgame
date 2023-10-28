using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D player1;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpForce = 8f;

    private float dirX;


    // Start is called before the first frame update
    private void Start()
    {
        player1 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        player1.velocity = new Vector2 (dirX* movespeed, player1.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            player1.velocity = new Vector2(player1.velocity.x, jumpForce);

        }
        UpdateAnimationState();
        


       

    }



    
    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);

        }

    }
}
