using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed;
    Vector3 movement;
    SpriteRenderer mySR;
    public static float positionX;
    public static float positionY;
    Vector3 screenPosition;
    public static float mousepositionX;
    public static float mousepositionY;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        mySR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        //movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0); <- old movement

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        movement.x = moveHorizontal;
        movement.y = moveVertical;

        transform.Translate(movement * speed * Time.deltaTime);

        if (movement.x > 0f)
            mySR.flipX = true;
        else if (movement.x < 0f)
            mySR.flipX = false;
      
  
        transform.position += movement * speed * Time.deltaTime;

        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousepositionX = screenPosition.x;
        mousepositionY = screenPosition.y;
        positionX = transform.position.x;
        positionY = transform.position.y;
    }
}
