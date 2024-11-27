using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Player needs to be able to 
///     - Jump and climb (space bar/jump axis)
///     - walk forward and backward (horizontal and vertical)
///     - Let go of water  (Fire 1)
/// </summary>

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public float jumpForce = 10;
    public float walkingSpeed = 3;
    private bool touchedGround = true;
    public bool itemHeld = false;
    public int lives = 3;
    public AudioClip[] playerSound;
    private LavaController lavaControl;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); 
    }

    void PlayerMove()
    {
        Vector2 playerVelocity = playerRB.velocity;

        playerVelocity.x = Input.GetAxis("Horizontal") * walkingSpeed ;
        playerRB.velocity = new Vector2(playerVelocity.x, playerVelocity.y);
        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       PlayerMove();
    }

    void PlayerJump()
    {
        
        touchedGround = false;
        Debug.Log("Jump button is clicking as intended");
        Vector2 playerVelocity = playerRB.velocity;
        playerVelocity.y = jumpForce;
        playerRB.velocity = new Vector2(playerVelocity.x, playerVelocity.y);
        GetComponent<AudioSource>().clip = playerSound[1];
        GetComponent<AudioSource>().Play();

    }

    void PlayerLetGo()
    {
        bool itemHeld = false;
        Debug.Log("Bucket Released");
    }
    private void Update()
    {
        bool jump = Input.GetButtonDown("Jump");
        //bool itemLetGo = Input.GetButtonDown("Fire1");

        //Collision2D collision = this.GetComponent;
        if (jump && touchedGround)
        {
            PlayerJump();
        }
        bool itemLetGo = Input.GetButton("Fire2");
        if (itemLetGo)
        {
            Debug.Log("Player is holding pick up button");
            PlayerLetGo();
        }
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Collider2D incomingCollider = collision.collider;
        //Get the incomming collider's parent
        GameObject colliderParent = incomingCollider.gameObject.transform.parent.gameObject;
        
        

        //if colliding with lava
        if (colliderParent.name == "Lava Holder" )
        {
            lavaControl = incomingCollider.GetComponentInParent<LavaController>();
            //if lava on fire -- subtract a life and make the player auto jump
            if (lavaControl.lavaIsOn)
            {                
                lives--;
                //if out of lives, end the game and display the point total.
                if (lives < 0)
                {
                    Debug.Log("End Of Game");
                    SceneManager.LoadScene(2);
                }
                Debug.Log("Is colliding with the lava. Lives now at: " + lives);
                PlayerJump();
                GetComponent<AudioSource>().clip = playerSound[2];
                GetComponent<AudioSource>().Play();
            }
            // if the lava is not on fire, it's safe to touch and the player may rest on it
            else 
            {
                Debug.Log("Is Colliding with off lava. No lives lost");
                touchedGround = true; 
            }
        }
        //else if the player is colliding with a water bucket
        else if (colliderParent.name == "Water Buckets" && !itemHeld)
        {            
            Debug.Log("Must be picked up. Water Bucket will tag along with player until released");
        }
        else if (colliderParent.name != "Invisible Walls")
        {
            touchedGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D incomingCollider = collision.collider;
        //Get the incomming collider's parent
        GameObject colliderParent = incomingCollider.gameObject.transform.parent.gameObject;
        if (colliderParent.name != "Invisible Walls" && Mathf.Abs(playerRB.velocity.x) > 1 && (Time.time % .25 == 0))
        {
            touchedGround = true;
            GetComponent<AudioSource>().clip = playerSound[0];
            GetComponent<AudioSource>().Play();
        }
    }
    


}
