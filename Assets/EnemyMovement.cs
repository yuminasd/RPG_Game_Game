using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public int health = 1;
    private float timer;
    private float attackTimer;

    public float moveTime;
    public float attackTime;
    Rigidbody2D rbody;
    Vector2 inputVector;
    float horizontalInput;
    float verticalInput;
    int counter = 0;

    public GameObject attack;
    private void Awake()
    {

        timer = moveTime;
        attackTimer = attackTime;
        rbody = GetComponent<Rigidbody2D>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = rbody.position;
        timer -= Time.deltaTime;
        attackTimer -= Time.deltaTime;
        if (timer < 0)
        {

            timer = moveTime;
            if (counter == 0)
            {
                Debug.Log("Hi");
                horizontalInput = 1f;
                verticalInput = 1f;
                counter++;
            }
            else if (counter ==1)
            {
                horizontalInput = 1f;
                verticalInput = -1f;
                counter++;
            }
            else if (counter == 2)
            {
                horizontalInput = -1f;
                verticalInput = -1f;
                counter++;
            }
            else if (counter == 3)
            {
                horizontalInput = -1f;
                verticalInput = 1f;
                counter = 0;
            }

            if (attackTimer <0)
            {
                attackTimer = attackTime;
                Instantiate(attack, rbody.position, Quaternion.identity);
            }
        }
        inputVector = new Vector2(horizontalInput, verticalInput);
        if (health==0)
        {
            Destroy(this.gameObject);
        }
        Vector2 movement = inputVector * 1f;
        Vector2 newPos1 = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos1);
    }

}
