using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameGenerator : MonoBehaviour
{
    public List<string> names = new List<string>(); 
    public List<string> gifts = new List<string>(); 
    private int nameChosen;
    private int giftChosen;
    public List<TextMeshProUGUI> nameLines = new List<TextMeshProUGUI>();
    public List<BoxScript> box = new List<BoxScript>();
    private int i;
    //public List<GameObject> box = new List<GameObject>();
    //private BoxScript boxScript;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (TextMeshProUGUI nameLine in nameLines)
        {
            //BoxScript boxScript = box.GetComponent<BoxScript>;
            nameChosen = Random.Range (0, names.Count);
            giftChosen = Random.Range (0, gifts.Count);
            i = Random.Range (0, box.Count);
            box[i].kid = names[nameChosen];
            box[i].giftNeeded = gifts[giftChosen];
            box[i].nameLine = nameLine;
            box.Remove (box[i]);
            nameLine.text = names[nameChosen] + " - " + gifts[giftChosen];
            names.Remove (names[nameChosen]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
