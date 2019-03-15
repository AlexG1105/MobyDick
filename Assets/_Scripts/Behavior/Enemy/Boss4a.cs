using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4a : MonoBehaviour
{
    public GameObject regularBullet;

    private float lifeTime;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 1500;
    }

    void Update()
    {

        if (transform.parent != null)
        {
            pos = transform.parent.position;
        }
        transform.RotateAround(transform.parent.position, Vector3.forward, 1f);
        
        if (lifeTime % 40 == 0)
        {
            Instantiate(regularBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Instantiate(regularBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Instantiate(regularBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Instantiate(regularBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }

        lifeTime--;
        if (lifeTime == 0)
        {
            Destroy(gameObject);
        }
    }
}
