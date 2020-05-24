using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement2 : MonoBehaviour
{
    public int health=1;
    Rigidbody2D rbody;
    public GameObject player;

    Vector2 inputVector;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {

        rbody.MovePosition(Vector2.MoveTowards(transform.position,player.transform.position,1*Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {

            collision.GetComponent<IsometricPlayerMovementController>().health-=1;
        }
    }
}
