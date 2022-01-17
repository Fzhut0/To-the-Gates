using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        PauseGame();
    }



    public void PauseGame()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        /*   else
           {
               pauseMenu.SetActive(false);
               Time.timeScale = 1f;
           }
        */
    }


    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LostLevelSwitch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}



