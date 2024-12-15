using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public float jumpForce = 10;
    public float walkingSpeed = 3;
    private bool touchedGround = true;
    //public bool itemHeld = false;
    public int lives = 3;
    private bool jump = false;
    

    void PJump()
    {

        touchedGround = false;
        Debug.Log("Jump button is clicking as intended");
        Vector2 playerVelocity = playerRB.velocity;
        playerVelocity.y = jumpForce;
        playerRB.velocity = new Vector2(playerVelocity.x, playerVelocity.y);

    }

    void PMove()
    {
        Vector2 playerVelocity = playerRB.velocity;

        playerVelocity.x = Input.GetAxis("Horizontal") * walkingSpeed;
        playerRB.velocity = new Vector2(playerVelocity.x, playerVelocity.y);


    }

    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = Input.GetButton("Jump");
        
        if (jump && touchedGround)
        {
            PJump();
        }
        

    }

    //Character jump after touching floor
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D incomingCollider = collision.collider;
        GameObject colliderParent = incomingCollider.gameObject;

       //Debug.Log(colliderParent.name);
        if (colliderParent.name == "Floor Tilemap")
        {
            touchedGround = true;
        }
    }

    private void FixedUpdate()
    {
        PMove();
        
    }
}
