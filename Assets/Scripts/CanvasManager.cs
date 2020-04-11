using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public Button restartButton;
    public Button hamburgerButton;
    public Text hamburgerSize;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hamburgerSize.text = "anvorgesize="+ (GameManager.sharedInstance.tower.Count-1).ToString();
        if (GameManager.sharedInstance.gameOver)
        {
            restartButton.gameObject.SetActive(true);
        } 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void CreateHamburger()
    {
        Debug.Log("hamburgesa");
        GameManager.sharedInstance.PutTapa();


    }

    public void TouchScreen()
    {
        Debug.Log("touchScreen");
        GameManager.sharedInstance.TouchScreen = true;
    }
}
