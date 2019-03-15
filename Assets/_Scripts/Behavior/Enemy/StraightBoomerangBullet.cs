using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBoomerangBullet : MonoBehaviour
{

    public Vector2 movement;
    private float lifeTime;

    // Use this for initialization
    void Start()
    {
        lifeTime = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 15)
        {
            transform.Translate(new Vector2(1, 0) * 8 * Time.deltaTime);
        }
        else if (lifeTime > 10)
        {

        }
        else
        {
            transform.Translate(new Vector2(-1, 0) * 8 * Time.deltaTime);
        }

        lifeTime -= Time.deltaTime * 5;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //ExitDoor.updatedLevel;

        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().hurtPlayer(2);
            Destroy(gameObject);
        }
        if (other.tag == "boundary")
        {
            Destroy(gameObject);
        }
    }
}