using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class IsometricPlayerMovementController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    public int isChatting=0;
    public int readyChat = 0;
    public Interactable interact = null;
    private bool started = false;
    Rigidbody2D rbody;

    public GameObject attack;
    public GameObject attack1;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isChatting == 0)
        {

            Vector2 currentPos = rbody.position;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            Vector2 movement = inputVector * movementSpeed;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Vector2 newPos1 = currentPos + 30 * movement * Time.fixedDeltaTime;
                Instantiate(attack, newPos1, Quaternion.identity);
                return;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
               Vector2 newPos1 = currentPos + 50*movement * Time.fixedDeltaTime;
                isoRenderer.SetDirection(movement);
                rbody.MovePosition(newPos1);
                return;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Vector2 newPos1 = currentPos + 30 * movement * Time.fixedDeltaTime;
                Instantiate(attack1, newPos1, Quaternion.identity);
                return;
            }

            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            isoRenderer.SetDirection(movement);
            rbody.MovePosition(newPos);
                    
        }
    }

    private void Update()
    {
        if (readyChat == 1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {

                readyChat = 0;
                interact.TriggerDialogue();
                interact = null;
            }
        }
        if (isChatting ==1)
        {

            if (Input.GetKeyDown(KeyCode.Z))
            {
                dialogueManager.DisplayNextSentence();
            }
        }
    }




}
