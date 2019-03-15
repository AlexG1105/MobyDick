using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4 : MonoBehaviour
{

    public GameObject trackingBomb;
    public GameObject snipeBullet;
    public GameObject wavyBullet;
    public GameObject regularBullet;
    public GameObject swarmWhale;

    public GameObject attachedWhale;

    private Vector2 movement;
    public int bossPhase;
    public int handicap;

    public float timeElapsed;
    private int timer;
    private int whaleCount;
    private int initHealth;

    Vector3 instantiatePos;
    Vector3 boss2pos;

    // Use this for initialization
    void Start()
    {
        initHealth = gameObject.GetComponent<EnemyHealth>().liveHealth;
        bossPhase = 0;
        movement.y = .5f;
        timeElapsed = 0f;
        timer = 0;
        whaleCount = 0;
        instantiatePos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;

        if (bossPhase == 0) //not attacking
        {
            transform.Translate(movement / handicap);
            if (timeElapsed > 10 || gameObject.GetComponent<EnemyHealth>().liveHealth < initHealth)
            {
                bossPhase = 1;
                generateNewRandomMovement();
                transform.Translate(movement / handicap);
            }
        }
        else if (bossPhase == 1) //whale fighting
        {
            if ((int)timeElapsed % 3 == 0)
            {
                generateNewRandomMovement();
            }
            transform.Translate(movement / handicap);

            timer++;
            if (timer % 10 == 0)
            {
                Instantiate(wavyBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }
            if (timer % 49 == 0)
            {
                Instantiate(regularBullet, transform.position, Quaternion.identity);
            }
            if (timer % 91 == 0)
            {
                Instantiate(snipeBullet, transform.position, Quaternion.identity);
            }
            if (timer == 500)
            {
                Instantiate(trackingBomb, transform.position, Quaternion.identity);
                timer = 0;
            }
            if (gameObject.GetComponent<EnemyHealth>().liveHealth < initHealth / 2)
            {
                bossPhase = 2;
                attachedWhale = Instantiate(swarmWhale, transform.position + new Vector3(10, 0, 0), Quaternion.Euler(0, 0, 1));
                attachedWhale.transform.parent = transform;
                whaleCount++;
                timer = 0;
            }
        }
        else if (bossPhase == 2) //whale storm (291)
        {
            generateNewRandomMovement();
            transform.Translate(movement / handicap);
            timer++;
            if (whaleCount < 9 && timer == 50)
            {
                
                attachedWhale = Instantiate(swarmWhale, transform.position + new Vector3(10,0,0), Quaternion.Euler(0, 0, 1));
                attachedWhale.transform.parent = transform;
                whaleCount++;
                timer = 0;
            }
        }
    }

    void generateNewRandomMovement()
    {
        float leftRight = Random.value - .5f;
        float upDown = Random.value - .5f;
        movement.x = Random.value * leftRight;
        movement.y = Random.value * upDown;
        movement.Normalize();
    }
}
