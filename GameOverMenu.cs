using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    
    public void RestartGame()
    {
    	SceneManager.LoadScene("Game");
    }
 
    public void ReturnMenu()
    {
    	Debug.Log("QUIT!");
    	SceneManager.LoadScene("Menu");
    }
}
