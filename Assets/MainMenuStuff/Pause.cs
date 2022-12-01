using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool gamePaused;
    public GameObject pauseMenu;

    private void Start() {
        pauseMenu.SetActive(false);
        gamePaused = false;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            pauseGame();
        }    
    }

    public void pauseGame() {
        gamePaused = !gamePaused;
        if(gamePaused) {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        } else {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }

    }

    public void quitBackToMain() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
