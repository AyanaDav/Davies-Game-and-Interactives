using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayerScript : MonoBehaviour
{
    private GameObject playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.Find("Player Character");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = transform.position;
       // Debug.Log("Player location is: " + playerCharacter.transform.position.x);
       float offset = cameraPosition.x - playerCharacter.transform.position.x;
        
        if (Mathf.Abs(offset) > 5f)
        {
            cameraPosition.x = playerCharacter.transform.position.x;
            transform.position = cameraPosition;
        }

    }
}
