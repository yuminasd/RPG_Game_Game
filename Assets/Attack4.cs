using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack4 : MonoBehaviour
{
    public float timer = 0.3f;
    Rigidbody2D rbody;
    public GameObject player;

    Vector2 inputVector;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
      Vector2  moveDirection = (player.transform.position - transform.position).normalized * 1f;
        rbody.velocity = new Vector2 (moveDirection.x, moveDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //Vector2 currentPos = rbody.position;

        //inputVector = Vector2.ClampMagnitude(inputVector, 1);
        //Vector2 movement = inputVector * 1f;
        //Vector2 newPos1 = currentPos + movement * Time.fixedDeltaTime;
     //   rbody.MovePosition(Vector2.MoveTowards(transform.position,player.transform.position,1*Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("player"))
            {
                collision.GetComponent<IsometricPlayerMovementController>().health--;
                Object.Destroy(this.gameObject);
            }

    }
}
