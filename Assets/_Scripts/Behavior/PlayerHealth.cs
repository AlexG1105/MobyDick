using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    public GameObject deathMenu;
    public Slider playerHealthUI;

    // Start is called before the first frame update
    void Start()
    {
        health = 75;
        playerHealthUI.maxValue = health;
        playerHealthUI.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Time.timeScale = 0f;
            Destroy(gameObject);
            deathMenu.SetActive(true);
        }
    }

    public void hurtPlayer(int damage)
    {
        health -= damage;
        playerHealthUI.value = health;
    }
}
