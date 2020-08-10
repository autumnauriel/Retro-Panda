using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   bool gameHasEnded = false;
   bool nextLevel = false;

   // public float restartDelay = 1f;

   public void EndGame ()
   {

   	if (gameHasEnded == false)
   	{
   		gameHasEnded = true;
   		Debug.Log("GAME OVER");
		   SceneManager.LoadScene("GameOverMenu");

         FindObjectOfType<AudioManager>().Play("GameOver");

         

   		// Invoke("Restart", restartDelay);
   	}

   }

   public void NextLevel ()
   {
      if (nextLevel == false)
      {
         nextLevel = true;
         Debug.Log("NextLevel");
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }

   }

    public void PlayGame()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void RestartGame()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
 
    public void ReturnMenu()
    {
      Debug.Log("QUIT!");
      SceneManager.LoadScene("Menu");
    }

 //   void Restart ()
 //   {

	// SceneManager.LoadScene(SceneManager.GetActiveScene().name);

 //   }
}
