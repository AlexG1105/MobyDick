using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;

    public void restart()
    {
        Time.timeScale = 1f;
        GameInfo.lastPosition = new Vector3(-39.44f, 27.74f, 10);
        GameInfo.bossesDefeated = 0;
        deathMenuUI.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
