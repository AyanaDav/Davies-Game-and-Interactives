using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBuckeMove : MonoBehaviour
{

    //public GameObject Lava;
    private LavaController lavaControl;
    private PlayerController playerControl;
    private GameObject playerCharObject;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = 1.3f;
        playerCharObject = GameObject.Find("Player Character");
        playerControl = playerCharObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerControl.itemHeld);
        if (Input.GetButton("Fire2"))
        {
            playerControl.itemHeld = false;
        }
        else if (playerControl.itemHeld)
        {
            Vector3 tempVector = transform.position;
            tempVector.x = playerCharObject.transform.position.x - offset;
            tempVector.y = playerCharObject.transform.position.y;
            //transform.position = tempVector;
            this.GetComponent<Rigidbody2D>().MovePosition(tempVector);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D incomingCollider = collision.collider;
        
        //If colliding with lava, chamge the color and turn off the pain of THAT specific lava chunk.
        if (incomingCollider.name == "Player Character")
        {
            //GameObject playerGameObject = incomingCollider.gameObject;
            //playerControl = incomingCollider.GetComponentInParent<PlayerController>();
            bool itemPickUp = Input.GetButton("Fire1");
            if (itemPickUp)
            {
                playerControl.itemHeld = true;
            }

        }
        else
        {
            GameObject parentObject = incomingCollider.transform.parent.gameObject;
            if (parentObject.name == "Lava Holder")
            {
                lavaControl = incomingCollider.GetComponentInParent<LavaController>();
                if (lavaControl.lavaIsOn)
                {
                    ScoreKeeper.ScorePoints(1);
                    GetComponent<AudioSource>().Play();
                    incomingCollider.GetComponentInParent<SpriteRenderer>().color = Color.black;
                    lavaControl.lavaIsOn = false;
                    Debug.Log("Lava has been put out!!! Lava is on: " + lavaControl.lavaIsOn);
                }
            }
        }
    }
}
