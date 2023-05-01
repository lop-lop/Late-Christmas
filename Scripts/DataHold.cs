using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DataHold : MonoBehaviour
{
    public bool museActive;
    public bool soundActive;
    public AudioSource muse2;
    public GameObject muse1;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad (this.gameObject);
        StartCoroutine (MuseChange ());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MuseChange ()
    {
        yield return new WaitForSeconds (15.5f);
        Destroy(muse1);
        muse2.Play ();
    }
}
