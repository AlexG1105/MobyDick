using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFragment : MonoBehaviour
{

    public Vector2 movement;
    private float lifeTime;

    // Use this for initialization
    void Start()
    {
        movement = new Vector2(Random.Range(0.5f, 1.25f),0);
        lifeTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * 10 * Time.deltaTime);
        lifeTime -= Time.deltaTime;
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