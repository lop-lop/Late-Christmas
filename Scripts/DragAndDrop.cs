using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public Camera cameraMan;


    public List<string> tags = new List<string>(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown ()
    {
        deltaX = cameraMan.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        //deltaY = cameraMan.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        
    }

    private void OnMouseDrag ()
    {
        mousePosition = cameraMan.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, transform.position.y);
        //transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
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
