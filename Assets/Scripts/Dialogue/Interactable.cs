using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject trigger;


    public void TriggerDialogue()
    {
        FindObjectOfType<IsometricPlayerMovementController>().isChatting = 1;
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        trigger.SetActive(true);
        FindObjectOfType<IsometricPlayerMovementController>().interact = this;
        FindObjectOfType<IsometricPlayerMovementController>().readyChat = 1;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger.SetActive(false);
        FindObjectOfType<IsometricPlayerMovementController>().readyChat = 0;
        FindObjectOfType<IsometricPlayerMovementController>().interact = null;

    }


}
