using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
   private ScoreKeeper scoreKeeper;
    public TMP_Text gameWonOrLost;
    public TMP_Text bodyText;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = ScoreKeeper.Singleton;
        int scoreInText = scoreKeeper.Score;
        Debug.Log("Floors put out: " + scoreInText);
        if (scoreInText == 5)
        {
            gameWonOrLost.text = "THE FLOOR IS NOT LAVA!";
            bodyText.text = "Let's be honest, a bucket of water is not solving a massive lava flood. Let's just say this was divine intervention, get a clean up crew, and call it a day.";
        }
        else
        {
            
            gameWonOrLost.text = "THE FLOOR IS STILL LAVA";
            bodyText.text = "You put out " + scoreInText + " out of 5 lava pools. The house is in shambles, your insurance rate has skyrocketed, and you're definitely not getting the security deposit back.\r\n\r\nYes, security deposit. This was a rental. Affording a house in this economy? Well, not anymore with your insurance. ";
        }
    }
}
