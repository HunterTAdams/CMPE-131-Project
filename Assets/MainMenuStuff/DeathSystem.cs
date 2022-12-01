using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSystem : MonoBehaviour
{
    public GameObject deathMenu;

    public void death() {
        deathMenu.SetActive(true);
    }

    public void retry() {
        deathMenu.SetActive(false);
    }

    public void quitBackToMain() {
        SceneManager.LoadScene(0);
    }

}
