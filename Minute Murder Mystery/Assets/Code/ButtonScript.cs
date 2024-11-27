using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ButtonScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueBox;
    public TextMeshProUGUI nameBox;
    private string charName;
    private string[] dialogueArray;
    private GameObject suspect;
    public int counter;
    public GameObject resultImage;
    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        
    }

    // Update is called once per frame

    public void UpdateInfo(string newCharName, string[] newDialogueArray, GameObject newSuspect)
    {
        suspect = newSuspect;
        charName = newCharName;
        dialogueArray = newDialogueArray;

        nameBox.text = charName;
        dialogueBox.text = dialogueArray[counter];
    }
    public void NextText()
    {
        if (counter >= dialogueArray.Length)
        {
            PlayerController controlling = FindObjectOfType<PlayerController>();
            controlling.AllowMovement();
            counter = 0;
        }
        else
        {
            dialogueBox.text = dialogueArray[counter];
            counter++;
        }
    }

    public void CorrectChoice()
    {
      //  Debug.Log("Load congrats!");
        resultImage.SetActive(true);
        nameBox.text = "Correct! Another one for the books.";
        dialogueBox.text = "No worries, Murdar will be going away for a long, long time, never to weild a knife or overcook another NY skirt steak. Thank you detective for your service. Take it easy.";
    }
    public void WrongChoice()
    {
        //Debug.Log("Congrats, you've wrongfully imprisoned someone.");
        resultImage.SetActive(true);
        restartButton.SetActive(true);
        nameBox.text = "Wrong, but no shame in that.";
        dialogueBox.text = "Don't worry, everyone gets something wrong occasionally. It just means that an innocent person is going to jail, and it's your fault. All you have to do is live with that on your conscience \n \n Wanna try again?";
    }
    public void ChildChoice()
    {
       // Debug.Log("You're getting your license revoked.");
        resultImage.SetActive(true);
        nameBox.text = "Getting your license revoked.";
        dialogueBox.text = "That was actually pitiful. The child? He wasn't even there!!! Turn in your badge and find a new job, jeez. Better yet just stay away from me specifically. I'm getting a restraining order for the precinct on group buy.";
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void ExitGame()
    {
       //Debug.Log("Quit Game");
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
