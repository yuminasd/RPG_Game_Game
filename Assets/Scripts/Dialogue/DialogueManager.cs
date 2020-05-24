using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences; 
    public TMP_Text dialogueText;
    public TMP_Text talkerText;
    public GameObject[] images;
    private GameObject talkerImage;

    public GameObject myName;
    public GameObject myImage;
    public GameObject ui;

    public int turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue d)
    {
        
        sentences.Clear();
        talkerText.text = d.name;
        talkerImage = images[d.image];
        foreach (string sentence in d.sentences)
        {
            sentences.Enqueue(sentence);
        }
        ui.SetActive(true);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count==0)
        {
            Debug.Log("IgetHere");
            EndDialogue();
            return;
        }

        if(turn == 0)
        {
            talkerText.gameObject.SetActive(true);
            myName.SetActive(false);
            talkerImage.SetActive(true);
            myImage.SetActive(false);
            turn = 1;
        }
        else
        {
            talkerText.gameObject.SetActive(false);
            myName.SetActive(true);
            talkerImage.SetActive(false);
            myImage.SetActive(true);
            turn = 0;
        }

       string nextSentence= sentences.Dequeue();
        dialogueText.text = nextSentence;
    }

    public void EndDialogue()
    {
        turn = 0;
        talkerImage.SetActive(false);
        talkerImage = null;
        foreach (GameObject i in images)
        {
            i.SetActive(false);
        }
        FindObjectOfType<IsometricPlayerMovementController>().isChatting = 0;
        ui.SetActive(false);
    }
}
