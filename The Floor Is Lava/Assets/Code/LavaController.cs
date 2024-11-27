using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    public bool lavaIsOn;
    public GameObject linkedInvisibleWall;
    // Start is called before the first frame update
    void Start()
    {
        lavaIsOn = true;
       

    }

    // Update is called once per frame
   void Update()
    {
        if (!lavaIsOn) 
        { Destroy(linkedInvisibleWall); }
    }
    


}
