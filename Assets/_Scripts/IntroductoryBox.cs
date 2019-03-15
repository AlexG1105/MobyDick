using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductoryBox : MonoBehaviour
{
    public GameObject boxUI;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
       if (GameInfo.bossesDefeated == 0)
        {
            text.text = "Welcome! Use WASD to move, and hold down the mouse or spacebar to shoot! You can start by docking at the nearest island (sail to the port).";
        }
       else if (GameInfo.bossesDefeated == 1)
        {
            text.text = "Travel directly south to continue your journey!";
        }
       else if (GameInfo.bossesDefeated == 2)
        {
            text.text = "Travel to the island directly east!";
        }
       else if (GameInfo.bossesDefeated == 3)
        {
            text.text = "Travel to the island north-east! You're almost done!";
        }
       else if (GameInfo.bossesDefeated == 4)
        {
            text.text = "Travel southwest to the middle island. Your journey is about to end!";
        }
    }

    public void close()
    {
        boxUI.SetActive(false);
    }
}
