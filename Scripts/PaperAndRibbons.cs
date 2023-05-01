using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperAndRibbons : MonoBehaviour
{
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public Camera cameraMan;
    private Vector2 startPosition;
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown ()
    {
        coll.enabled = false;
        deltaX = cameraMan.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = cameraMan.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag ()
    {
        mousePosition = cameraMan.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, transform.position.y);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }

    private void OnMouseUp ()
    {
        coll.enabled = true;
        StartCoroutine(Back());
    }

    IEnumerator Back ()
    {
        yield return new WaitForSeconds (0.1f);
        transform.position = startPosition;
    }


        
}
