using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

  //  public Animator transition;
    public int transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    //public void LoadNextLevel()
    //{
    //    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    //}

    //IEnumerator LoadLevel(int index)
    //{
    //    //play
    //    transition.SetTrigger("start");
    //    //wait
    //    yield return new WaitForSeconds(transitionTime);
    //    SceneManager.LoadScene(index);
    //    //load
    //}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
