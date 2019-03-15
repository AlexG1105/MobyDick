using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (GameInfo.bossesDefeated == 0)
        {
            Instantiate(player, transform.position, Quaternion.identity);
        } else
        {
            if (GameInfo.lastPosition != null)
            {
                Debug.Log("gang");
            }
            Instantiate(player, GameInfo.lastPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
