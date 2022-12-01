using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSystem : MonoBehaviour
{
    public GameObject deathMenu;
    public playercontroller player;
    public static bool dead;

    public void death() {
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
        dead = true;
    }

    public void retry() {
        dead = false;
        Time.timeScale = 1f;
        deathMenu.SetActive(false);
        player.Awake();
        player.health = 2;
        player.addhealth();
        tileaccess.energy = 0;
        player.energytext.text = tileaccess.energy.ToString();
        tileaccess.currentzone.Awake();
        foreach (var i in tileaccess.currentzone.GetComponentsInChildren<basecontroller>())
        {
            i.Awake();
        }
    }

    public void quitBackToMain() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
