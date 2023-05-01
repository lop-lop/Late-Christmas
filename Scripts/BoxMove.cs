using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class BoxMove : MonoBehaviour
{
    public int boxCount;
    
    public float speed;

    public string giftNeeded;
    public string gift;
    public string paper;
    public string ribbon;
    public string kid;

    private bool giftRight;
    private bool paperRight;
    private bool ribbonRight;

    private string ballPaper;
    private string robotPaper;
    private string rocketPaper;
    private string teddyPaper;

    private string ballRibbon;
    private string robotRibbon;
    private string rocketRibbon;
    private string teddyRibbon;
 
    public List <string> checkNames = new List <string> ();

    public List <TextMeshProUGUI> hints = new List <TextMeshProUGUI> ();

    public List <int> firstRandom = new List <int> ();
    public List <int> lastRandom = new List <int> ();

    //public List <int> decorChosen = new List <int> ();

    private int generatedNum;
    private string tempColor;
    private int hint;

    private List <int> conditions = new List <int> ();
    public AudioSource siren;
    public AudioSource good;
    public AudioSource win;

    private string loseTextPrep;
    public GameObject loseScreen;
    public TextMeshProUGUI loseText;

    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        giftRight = true;
        paperRight = true;
        ribbonRight = true;
        Generate ();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (new Vector3 (speed * Time.deltaTime, 0f, 0f));
    }

    public void Generate ()
    {
        for (int i = 0; i < firstRandom.Count; i++)
        {
            //GENERATING CONDITION
            generatedNum = (Random.Range (firstRandom[i], lastRandom[i]));
            Debug.Log (i + " " + generatedNum + " " + checkNames[generatedNum]);

            //SETTING CHECKS
            conditions.Add (generatedNum);

            //CHANGING TEXT
            hint = Random.Range (0, hints.Count);
            hints[hint].text = checkNames[generatedNum];
            hints.Remove (hints[hint]);
            
            //SETTING VARS
            if (generatedNum > 3)
            {
                if (generatedNum % 3 == 1) tempColor = "blue";
                else if (generatedNum % 3 == 2) tempColor = "green";
                else if (generatedNum % 3 == 0) tempColor = "red";

                if (generatedNum < 10) ballPaper = tempColor;
                else if (generatedNum < 16) robotPaper = tempColor;
                else if (generatedNum < 22) rocketPaper = tempColor;
                else if (generatedNum < 28) teddyPaper = tempColor;
                else if (generatedNum < 34) ballRibbon = tempColor;
                else if (generatedNum < 40) robotRibbon = tempColor;
                else if (generatedNum < 46) rocketRibbon = tempColor;
                else teddyRibbon = tempColor;
            }
        }
    }

    public void Check ()
    {
        //GIFT CHECK
        if (gift != giftNeeded) giftRight = false;
        

        //PAPER AND RIBBON CHECK
        for (int i = 0; i < conditions.Count; i++)
        {
            if (conditions[i] < 2)
            {
                if (paper == ribbon) ribbonRight = true;
                else ribbonRight = false;
                if ((conditions[i] % 2) == 1) ribbonRight = !ribbonRight;
            }

            else if (conditions[i] < 4)
            {
                if (paper == ribbon) paperRight = true;
                else paperRight = false;
                if ((conditions[i] % 2) == 1) paperRight = !paperRight;
            }
            
            else if (gift == "Ball" && conditions[i] < 10 && ballPaper != null)
            {
                if (paper != ballPaper) paperRight = false;
                if (conditions[i] > 6) paperRight = !paperRight;
            }

            else if (gift == "Robot" && conditions[i] < 16 && robotPaper != null)
            {
                if (paper != robotPaper) paperRight = false;
                if (conditions[i] > 12) paperRight = !paperRight;
            }

            else if (gift == "Rocket" && conditions[i] < 22 && rocketPaper != null)
            {
                if (paper != rocketPaper) paperRight = false;
                if (conditions[i] > 18) paperRight = !paperRight;
            }

            else if (gift == "Teddy" && conditions[i] < 28 && teddyPaper != null)
            {
                if (paper != teddyPaper) paperRight = false;
                if (conditions[i] > 24) paperRight = !paperRight;
            }

            else if (gift == "Ball" && conditions[i] < 34 && ballRibbon != null)
            {
                if (paper != ballPaper) ribbonRight = false;
                if (conditions[i] > 30) ribbonRight = !ribbonRight;
            }

            else if (gift == "Robot" && conditions[i] < 40 && robotRibbon != null)
            {
                if (paper != robotPaper) ribbonRight = false;
                if (conditions[i] > 36) ribbonRight = !ribbonRight;
            }

            else if (gift == "Rocket" && conditions[i] < 46 && rocketRibbon != null)
            {
                if (paper != rocketPaper) ribbonRight = false;
                if (conditions[i] > 42) ribbonRight = !ribbonRight;
            }

            else if (gift == "Teddy" && conditions[i] < 52 && teddyRibbon != null)
            {
                if (paper != teddyPaper) ribbonRight = false;
                if (conditions[i] > 48) ribbonRight = !ribbonRight;
            }

            Debug.Log (i + " check " + giftRight + " " + gift + " " +  paperRight + " " +  paper + " " +  ribbonRight + " " +  ribbon);
        }

        //RIGHT

        if (giftRight && paperRight && ribbonRight)
        {
            Debug.Log ("YES" + giftRight + gift + paperRight + paper + ribbonRight + ribbon);

            giftRight = true;
            paperRight = true;
            ribbonRight = true;

            ballPaper = null;
            robotPaper = null;
            rocketPaper = null;
            teddyPaper = null;

            ballRibbon = null;
            robotRibbon = null;
            rocketRibbon = null;
            teddyRibbon = null;

            if (good != null) good.Play ();
        }

        //LOSING
        else if (!giftRight || !paperRight || !ribbonRight)
        {
            speed = 0;
            if (siren != null) siren.Play();
            loseTextPrep = kid + " wanted ";
            if (!giftRight) loseTextPrep = loseTextPrep + "a " + giftNeeded;
            if (!giftRight && !paperRight && !ribbonRight) loseTextPrep = loseTextPrep + ", ";
            if (!giftRight && !paperRight && ribbonRight) loseTextPrep = loseTextPrep + " and ";
            if (!paperRight) loseTextPrep = loseTextPrep + "different paper";
            if (!ribbonRight) 
            {
                if (!giftRight || !paperRight) loseTextPrep = loseTextPrep + " and ";
                loseTextPrep = loseTextPrep + "another ribbon";
            }
            loseTextPrep = loseTextPrep + "!";
            loseText.text = loseTextPrep;
            loseScreen.SetActive(true);
        }

        //WINNING

        boxCount--;
        if (boxCount == 0) 
        {
            winScreen.SetActive (true);
            if (win != null) win.Play ();
        }

    }

}
