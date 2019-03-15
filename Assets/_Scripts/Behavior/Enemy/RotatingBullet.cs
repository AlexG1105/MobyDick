using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBullet : MonoBehaviour
{
    private float lifeTime;
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {
    }

    //FIXED UPDATE FIXES THE PROBLEM!
    void FixedUpdate()
    {

        if (transform.parent != null)
        {
            pos = transform.parent.position;
        }

        transform.RotateAround(pos, Vector3.forward, Random.Range(1f, 1.7f));

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //ExitDoor.updatedLevel;

        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().hurtPlayer(1);
            Destroy(gameObject);
        }
        if (other.tag == "boundary")
        {
            Destroy(gameObject);
        }
    }
}
