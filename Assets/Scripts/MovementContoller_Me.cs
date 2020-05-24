using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContoller_Me : MonoBehaviour
{
    public float movementSpeed = 1f;

    Rigidbody2D rbody;
    public Sprite[] spriteList;// "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE"  
    int lastDirection; // current direction is duplicate 
   public  SpriteRenderer currentSprite;


    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //updates the position of the object; 
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;


        //here the  direction will be determined and the image will be set for character
        if (movement.magnitude >= .01f)
        {
            lastDirection = DirectionToIndex(movement, 8);
        }
        currentSprite.sprite = spriteList[lastDirection];
        rbody.MovePosition(newPos);
    }


    //this function converts a Vector2 direction to an index to a slice around a circle
    //this goes in a counter-clockwise direction.
    public static int DirectionToIndex(Vector2 dir, int sliceCount)
    {
        //get the normalized direction
        Vector2 normDir = dir.normalized;
        //calculate how many degrees one slice is
        float step = 360f / sliceCount;
        //calculate how many degress half a slice is.
        //we need this to offset the pie, so that the North (UP) slice is aligned in the center
        float halfstep = step / 2;
        //get the angle from -180 to 180 of the direction vector relative to the Up vector.
        //this will return the angle between dir and North.
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        //add the halfslice offset
        angle += halfstep;
        //if angle is negative, then let's make it positive by adding 360 to wrap it around.
        if (angle < 0)
        {
            angle += 360;
        }
        //calculate the amount of steps required to reach this angle
        float stepCount = angle / step;
        //round it, and we have the answer!
        return Mathf.FloorToInt(stepCount);
    }
}
