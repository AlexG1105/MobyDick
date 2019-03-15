using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSwitcher : MonoBehaviour
{
    public Sprite ishmael;
    public Sprite ahab;
    public Sprite random;
    public Image current1;
    public Image current2;

    // Start is called before the first frame update
    void Start()
    {
        if (GameInfo.bossesDefeated == 0)
        {
            current1.sprite = ishmael;
            current2.sprite = null;
        }
        else if (GameInfo.bossesDefeated == 1)
        {
            current1.sprite = ishmael;
            current2.sprite = ahab;
        }
        else if (GameInfo.bossesDefeated == 2)
        {
            current1.sprite = ishmael;
            current2.sprite = ahab;
        }
        else if (GameInfo.bossesDefeated == 3)
        {
            current1.sprite = random;
            current2.sprite = null;
        }
        else if (GameInfo.bossesDefeated == 4)
        {
            current1.sprite = ishmael;
            current2.sprite = ahab;
        }

    }
}
