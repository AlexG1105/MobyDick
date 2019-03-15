using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOnEnemy : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "smallenemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().HurtEnemy(1);
            Destroy(gameObject);
        }
        if (other.tag == "enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().HurtEnemy(1);
            Destroy(gameObject);
        }
        if (other.tag == "EnemyBullet" ||other.tag == "rotate" || other.tag == "NetGunEnemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "boundary")
        {
            Destroy(gameObject);
        }
    }
}
