using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginningScript : MonoBehaviour
{
    // Start is called before the
    public Animator anim;
    void Start()
    {
        StartCoroutine (Next ());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Next ()
    {
        yield return new WaitForSeconds (6);
        //anim.SetBool ("out", true);
        //yield return new WaitForSeconds (2.5f);
        SceneManager.LoadScene ("MainMenu");
    }
}
