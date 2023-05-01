using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class DropMenu : MonoBehaviour
{
    public bool museActive;
    public bool soundActive;
    public bool menuActive;
    
    public AudioSource muse;
    public GameObject soundBox;
    public GameObject dropMenu;

    private Scene scene;

    public AudioSource but;

    public GameObject museHolder;
    public DataHold dataHold;
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

    public void OpenMenu ()
    {
        if (but != null) but.Play ();
        if (menuActive) dropMenu.SetActive (false);
        else dropMenu.SetActive (true);
        menuActive = !menuActive;
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

    public void Restart ()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene (scene.buildIndex);
    }

    public void ToMainMenu ()
    {
        SceneManager.LoadScene ("MainMenu");
    }

    public void Next ()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene (scene.buildIndex + 1);
    }
}
