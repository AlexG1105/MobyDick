using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    float timeBetweenShots = 0f;
    bool isFiring;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
        {
            isFiring = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }

        if (isFiring)
        {
            if (timeBetweenShots < 0)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, Random.Range(-3f, 3f)));
                timeBetweenShots = 0.3f;
            }
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
