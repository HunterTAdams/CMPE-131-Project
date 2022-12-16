using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSystem : MonoBehaviour
{
    public GameObject deathMenu;
    public playercontroller player;
    public static bool dead;
    public AudioSource audioSource;

    public void death() {
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
        dead = true;
        audioSource.Play();
    }

    public void retry() {
        dead = false;
        Time.timeScale = 1f;
        //deathMenu.SetActive(false); i left the rest of this enabled cuz it resets some values and otherwise doesn't matter, but i left the deathmenu on so it would hide things being reset before the reload
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
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void quitBackToMain() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
