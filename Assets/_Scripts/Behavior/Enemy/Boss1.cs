using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{

    public GameObject straightBoomerangBullet;
    public GameObject rotationBullet;

    private float timeBetweenRotShots;
    private float timeBetweenRegularShots;
    float distance;

    public GameObject attachedbullet;
    public float timeElapsed;

    Vector3 instantiatePos;

    // Use this for initialization
    void Start()
    {

        timeBetweenRotShots = 1f;
        timeBetweenRegularShots = 2f;
        distance = 0;

        timeElapsed = 0f;

        instantiatePos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        timeElapsed += Time.deltaTime;

        if (timeElapsed < 1)
        {
        }
        else if (timeElapsed < 6.5f)
        {
            //This sets the bullet as the child of the boss object. We want it to be a child
            //so the child can access its parent's location and rotate in respect to it.
            //Check the rotatingBullet code also if you're curious, it also accesses parent.
            instantiatePos = transform.position + Vector3.right * 15;
            attachedbullet = Instantiate(rotationBullet, instantiatePos, Quaternion.identity);
            attachedbullet.transform.parent = transform;


            if (timeElapsed > 1)
            {
                instantiatePos = transform.position + Vector3.right * Random.Range(16,24);
                attachedbullet = Instantiate(rotationBullet, instantiatePos, Quaternion.identity);
                attachedbullet.transform.parent = transform;

            }

        }

        if (timeElapsed > 3 && timeBetweenRegularShots < 0)
        {
            timeBetweenRegularShots = 1f;
            Instantiate(straightBoomerangBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Instantiate(straightBoomerangBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Instantiate(straightBoomerangBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }

        timeBetweenRegularShots -= (Time.deltaTime * 5);

    }
}