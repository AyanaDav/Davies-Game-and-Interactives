using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Movement related variables
    /// </summary>
    ///privates
    private Rigidbody playerRB;

    private float horizontalInput;
    private float verticalInput;
    private bool inItemContact;
    //publics 
    public float movementSpeed = 3;
    public float rotationSpeed = 3;
    public bool active;
    public GameObject dialogueBox;
    public Button holder;
    


    /// <summary>
    /// Interaction variables
    /// </summary>
    /// privates
    public void PlayerInterrogate()
    {
        //Debug.Log("Player Interrogate working");
        dialogueBox.SetActive(true);
    }
    /*public void PlayerMenu()
    {
        Debug.Log("Player Menu working");
        dialogueBox.SetActive(true);
    }*/
    public void AllowMovement()
    {
        active = false;
        dialogueBox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        active = false;
        inItemContact = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Variable Declarations and assignments

        if (Input.GetAxis("Interrogate") == 1 && inItemContact)
        {
            active = true;
            PlayerInterrogate();

        }
        /*if (Input.GetAxis("Menu") == 1 && !inItemContact)
        {
            active = true;
            PlayerMenu();
        }*/
        /*if (Input.GetAxis("Escape") == 1)
        {
            //Debug.Log("Quitting Game");
            AllowMovement();
           // Application.Quit();
        }*/


        if (!active)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //rotateHorzInput = Input.GetAxis("Rotate");

            //playerRB.MoveRotation(Quaternion.Normalize(Quaternion.identity * new Quaternion(0, finalRotation, 0, 1)));

            // transform.RotateAround(Vector3.zero, Vector3.up * horizontalInput, rotationSpeed);
            transform.RotateAround(playerRB.position, Vector3.up * horizontalInput, 1.0f * rotationSpeed);
            Vector3 playerForeMoveDirection = transform.forward * verticalInput;
            //Vector3 playerHorzMoveDirection = transform.right * horizontalInput;

            //playerRB.velocity = Vector3.Normalize(playerForeMoveDirection + playerHorzMoveDirection) * movementSpeed;
            playerRB.velocity = Vector3.Normalize(playerForeMoveDirection) * movementSpeed;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject suspect = collider.gameObject;
        
        if (collider.gameObject.tag == "PersonOfInterest")
        {
            SuspectInformation info = suspect.GetComponent<SuspectInformation>();
            inItemContact = true;
            //Debug.Log(info.suspectName + "says" + info.suspectDialogue[0]);
            holder.GetComponent<ButtonScript>().UpdateInfo(info.suspectName, info.suspectDialogue, suspect);

        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "PersonOfInterest") inItemContact = false;
    }

}
