using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    public GameObject Boss1;
    public GameObject Boss2;
    public GameObject Boss3;
    public GameObject Boss4;
    public GameObject Boss5;

    // Start is called before the first frame update
    void Start()
    {
        if (GameInfo.bossesDefeated == 0)
        {
            Instantiate(Boss1, new Vector2(0, 0), Quaternion.identity);
        }
        else if (GameInfo.bossesDefeated == 1)
        {
            Instantiate(Boss2, new Vector2(0, 0), Quaternion.identity);
        }
        else if (GameInfo.bossesDefeated == 2)
        {
            Instantiate(Boss3, new Vector2(0, 0), Quaternion.identity);
        }
        else if (GameInfo.bossesDefeated == 3)
        {
            Instantiate(Boss4, new Vector2(0, 0), Quaternion.identity);
        }
        else if (GameInfo.bossesDefeated == 4)
        {
            Instantiate(Boss5, new Vector2(0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
