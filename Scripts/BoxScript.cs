using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class BoxScript : MonoBehaviour
{
    public string kid;
    public string giftNeeded;
    public string gift;
    public string paper;
    public string ribbon;

    public BoxMove boxMove;

    public Animator anim;

    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI nameLine;

    private bool close = false;
    private bool papered = false;
    private bool ribboned = false;

    public Collider2D coll;

    public AudioSource toy;
    public AudioSource box;
    public AudioSource wrap;
    public AudioSource rib;

    // Start is called before the first frame update
    void Start()
    {
        if (nameTag != null)
        nameTag.text = kid;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ball" || col.gameObject.tag == "Robot" || col.gameObject.tag == "Rocket" || col.gameObject.tag == "Teddy")
        {
            if (toy != null) toy.Play ();
            gift = col.gameObject.tag;
            Destroy(col.gameObject);
            anim.SetBool("close", true);
            close = true;
            if (box != null) box.Play ();
        }

        if ((col.gameObject.tag == "Paper") & close)
        {
            if (wrap != null) wrap.Play ();
            if (col.gameObject.name == "Blue Paper") 
            {
                anim.SetInteger("paper", 1);
                paper = "blue";
            }

            else if (col.gameObject.name == "Green Paper") 
            {
                anim.SetInteger("paper", 2);
                paper = "green";
            }

            else if (col.gameObject.name == "Red Paper") 
            {
                anim.SetInteger("paper", 3);
                paper = "red";
            }

            papered = true;
        }

        if ((col.gameObject.tag == "Ribbon") & papered)
        {
            if (rib != null) rib.Play ();
            coll.enabled = false;
            if (col.gameObject.name == "Blue Ribbon") 
            {
                anim.SetInteger("ribbon", 1);
                ribbon = "blue";
            }
            else if (col.gameObject.name == "Green Ribbon") 
            {
                anim.SetInteger("ribbon", 2);
                ribbon = "green";
            }

            else if (col.gameObject.name == "Red Ribbon") 
            {
                anim.SetInteger("ribbon", 3);
                ribbon = "red";
            }

            ribboned = true;
            
            boxMove.giftNeeded = giftNeeded;
            boxMove.gift = gift;
            boxMove.paper = paper;
            boxMove.ribbon = ribbon;
            boxMove.kid = kid;
            nameLine.text = "<s>" + nameLine.text + "</s>";
            boxMove.Check ();
        }
    }
}
