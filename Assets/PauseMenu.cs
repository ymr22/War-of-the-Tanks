using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false ;

    public GameObject pauseMenuUI ;
    public GameObject messageUI ;

    
    void Update()
    {

        if ( Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused){
                Resume();
            }else{
                Pause();
            }

        }
        
    }

    public void Resume () {
        pauseMenuUI.SetActive(false);
        messageUI.SetActive(true);
        Time.timeScale = 1f ;
        GameIsPaused = false ;
        
    }

    void Pause () {
        pauseMenuUI.SetActive(true);
        messageUI.SetActive(false);
        Time.timeScale = 0f ;
        GameIsPaused = true ;
        
    }


    public void QuitMenu()
    {
        Debug.Log("Quiting game..");
        Application.Quit();
    }
}
