using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour{

    public bool moveAllowed;
    Collider2D col;
    Rigidbody2D rb;
    bool dragging;

    // Start is called before the first frame update
    void Start(){
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        moveAllowed = false;

    }


    void OnMouseDrag() {
        if (moveAllowed) {
            Vector3 mousePosG = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosG.x, mousePosG.y);
        }
    }

    private void OnMouseUp() {
        moveAllowed = false;
    }


    // Update is called once per frame
    void Update(){
    // Mouse

    // Check if the mouse was clicked
       if (Input.GetMouseButtonDown(0)){
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 mousePosG = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D touchCollider = Physics2D.OverlapPoint(mousePosG);
                if(col == touchCollider){
                    moveAllowed = true;
                }
        }


    //Touch Screen
        if(Input.touchCount > 0){
            Debug.Log("tc: " + Input.touchCount);
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began){
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchCollider){
                    moveAllowed = true;
                }
            }
            if(touch.phase == TouchPhase.Moved){
                if(moveAllowed){
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if(touch.phase == TouchPhase.Ended){
                moveAllowed = false;
            }
        }
    }
}
