using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int liveHealth;
    public Slider enemyHealthUI;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag != "smallenemy") {
            enemyHealthUI = GameObject.FindGameObjectWithTag("EnemyHealthUI").GetComponent<Slider>();
            enemyHealthUI.maxValue = liveHealth;
            enemyHealthUI.value = liveHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (liveHealth < 0)
        {
            Destroy(gameObject);

            if (gameObject.tag != "smallenemy")
            {
                GameInfo.bossesDefeated++;
                Destroy(gameObject);

                if (GameInfo.bossesDefeated == 5)
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
            
        }
    }
    public void HurtEnemy(int damage)
    {
        liveHealth -= damage;
        if (gameObject.tag != "smallenemy")
        {
            enemyHealthUI.value = liveHealth;
        }
    }

}
