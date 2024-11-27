using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadResetScene : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        { GetComponent<Button>().onClick.AddListener(OnNewClick); }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        { GetComponent<Button>().onClick.AddListener(ResetGame); }
    }
    public void OnNewClick()
    {

       SceneManager.LoadScene(1);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
