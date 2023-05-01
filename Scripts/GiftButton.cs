using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GiftButton : MonoBehaviour
{
    public string giftName;
    public GameObject gift;
    private GameObject creation;

    public Transform tube;

    public AudioSource tub;
    public AudioSource but;

    public List<string> tags = new List<string>(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown ()
    {
        creation = Instantiate (gift, tube.position, tube.rotation);
        creation.transform.parent = null; 
        if (tub != null) tub.Play ();
        if (but != null) but.Play ();
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        foreach (string tagName in tags)
        if (col.gameObject.tag == tagName)
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<Collider2D>());
        }
    }
}
