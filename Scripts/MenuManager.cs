using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject main;
    public GameObject lvls;
    public GameObject cred;
    public AudioSource but;

    public GameObject museHolder;
    public DataHold dataHold;
    public AudioSource muse;

    public GameObject soundBox;
    public GameObject dropMenu;

    public bool museActive;
    public bool soundActive;

    // Start is called before the first frame update
    void Start()
    {
        museHolder = GameObject.FindGameObjectWithTag("muse");
        DataHold dataHold = museHolder.GetComponent <DataHold> ();
        AudioSource muse = museHolder.GetComponent <AudioSource> ();

        museActive = dataHold.museActive;
        soundActive = dataHold.soundActive;

        if (!soundActive) soundBox.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Muse ()
    {
        if (but != null) but.Play ();
        if (museActive) muse.Pause ();
        else muse.Play ();
        museActive = !museActive;
        dataHold.museActive = museActive;
    }

    public void Sound ()
    {
        if (but != null) but.Play ();
        if (soundActive) soundBox.SetActive (false);
        else soundBox.SetActive (true);
        soundActive = !soundActive;
        dataHold.soundActive = soundActive;
    }

    public void ToMainMenu ()
    {
        main.SetActive (true);
        lvls.SetActive (false);
        cred.SetActive (false);
        if (but != null) but.Play();
    }

    public void Levels ()
    {
        main.SetActive (false);
        lvls.SetActive (true);
        cred.SetActive (false);
        if (but != null) but.Play();
    }

    public void Credits ()
    {
        main.SetActive (false);
        lvls.SetActive (false);
        cred.SetActive (true);
        if (but != null) but.Play();
    }

    public void Quit ()
    {
        Application.Quit ();
    }

    public void lvl1 ()
    {
        SceneManager.LoadScene("Lvl1");
    }
    public void lvl2 ()
    {
        SceneManager.LoadScene("Lvl2");
    }
    public void lvl3 ()
    {
        SceneManager.LoadScene("Lvl3");
    }
    public void lvl4 ()
    {
        SceneManager.LoadScene("Lvl4");
    }
    public void lvl5 ()
    {
        SceneManager.LoadScene("Lvl5");
    }
    public void lvl6 ()
    {
        SceneManager.LoadScene("Lvl6");
    }
    public void lvl7 ()
    {
        SceneManager.LoadScene("Lvl7");
    }
    public void lvl8 ()
    {
        SceneManager.LoadScene("Lvl8");
    }
    public void lvl9 ()
    {
        SceneManager.LoadScene("Lvl9");
    }
    public void lvl10 ()
    {
        SceneManager.LoadScene("Lvl10");
    }
}
