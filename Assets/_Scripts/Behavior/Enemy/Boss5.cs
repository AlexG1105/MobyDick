using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5 : MonoBehaviour
{
    public GameObject thrownBomb;
    public GameObject trackingBomb;
    public GameObject snipeBullet;
    public GameObject regularBullet;
    public GameObject boomerangBullet;

    private int attackMethod;
    private float timeElapsed;
    private float attackMethod1Timer;
    private float attackMethod2Timer;
    private float attackMethod3Timer;
    private float attackMethod4Timer;

    private float attackMethod1Between;
    private float attackMethod2Between;
    private float attackMethod3BetweenA;
    private float attackMethod3BetweenB;
    private float attackMethod4Between;
    private float rotationIncrement;

    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        attackMethod = Random.Range(1, 5);
        attackMethod1Timer = 14f;
        attackMethod2Timer = 15f;
        attackMethod3Timer = 15f;
        attackMethod4Timer = 15f;
        attackMethod3BetweenB = 1.7f;
        rotationIncrement = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed <= 2f)
        {
            //wait
        } else
        {
            if (attackMethod == 1 && attackMethod1Timer > 0)
            {
                if (attackMethod1Between <= 0)
                {
                    Instantiate(regularBullet, transform.position, Quaternion.identity);
                    attackMethod1Between = Random.Range(0.15f, 0.25f);
                }

                movement.x = Movement.positionX - transform.position.x;
                movement.y = Movement.positionY - transform.position.y;
                movement.Normalize();
                transform.Translate(movement * 2 * Time.deltaTime);
                attackMethod1Between -= Time.deltaTime;
                attackMethod1Timer -= Time.deltaTime;

            } else if (attackMethod == 1 && attackMethod1Timer <= 0)
            {
                attackMethod1Timer = 14f;
                attackMethod = Random.Range(1, 5);
            }

            if (attackMethod == 2 && attackMethod2Timer > 0)
            {
                if (attackMethod2Between <= 0)
                {
                    Instantiate(snipeBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(-45 + (attackMethod2Timer * 3), 45 - (attackMethod2Timer * 3))));
                    attackMethod2Between = 0.01f + ((15f - attackMethod2Timer) * 0.008f);
                }
                attackMethod2Between -= Time.deltaTime;
                attackMethod2Timer -= Time.deltaTime;
            } else if (attackMethod == 2 && attackMethod2Timer <= 0)
            {
                attackMethod2Timer = 15f;
                attackMethod = Random.Range(1, 5);
            }

            if (attackMethod == 3 && attackMethod3Timer > 0)
            {
                if (attackMethod3BetweenA <= 0)
                {
                    Instantiate(thrownBomb, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    Instantiate(thrownBomb, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    Instantiate(thrownBomb, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    attackMethod3BetweenA = 1.1f;
                }
                if (attackMethod3BetweenB <= 0)
                {
                    Instantiate(trackingBomb, transform.position, Quaternion.identity);
                    attackMethod3BetweenB = 1.7f;
                }
                attackMethod3BetweenA -= Time.deltaTime;
                attackMethod3BetweenB -= Time.deltaTime;
                attackMethod3Timer -= Time.deltaTime;
            } else if (attackMethod == 3 && attackMethod3Timer <= 0)
            {
                attackMethod3Timer = 15f;
                attackMethod = Random.Range(1, 5);
            }

            if (attackMethod == 4 && attackMethod4Timer > 0)
            {
                if (attackMethod4Between <= 0)
                {
                    Instantiate(boomerangBullet, transform.position, Quaternion.Euler(0, 0, rotationIncrement));
                    Instantiate(boomerangBullet, transform.position, Quaternion.Euler(0, 0, rotationIncrement + 180f));
                    rotationIncrement += Random.Range(10f, 60f);
                    attackMethod4Between = 0.17f;
                }

                attackMethod4Between -= Time.deltaTime;
                attackMethod4Timer -= Time.deltaTime;

            } else if (attackMethod == 4 && attackMethod4Timer <= 0)
            {
                attackMethod4Timer = 20f;
                attackMethod = Random.Range(1, 5);
            }
        }
        timeElapsed += Time.deltaTime;
    }
}
