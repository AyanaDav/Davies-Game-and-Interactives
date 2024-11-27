using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    private float timeleft = 0; 
    public int startingTimeSec = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float holdNum = startingTimeSec - timeleft;
        gameObject.GetComponent<TextMeshProUGUI>().text = ((int)holdNum).ToString();
        timeleft += Time.deltaTime;
        if (timeleft > startingTimeSec) 
        { 
            //Debug.Log("Time is Up!");
            SceneManager.LoadScene("WhoDidIt");
        }
    }


}
