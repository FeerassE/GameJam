using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool grabbed;
    public bool inPlayer = false;
    RaycastHit2D[] hits;
    RaycastHit2D hit;

    public float distance = 2f;
    public Vector2 direction;
    public Vector2 playerDirection;
    public Transform holdPoint;
    public GameObject heldObject;


    private bool hitSuccess = false;

    void Start() {
        heldObject = null;
    }
    void Update()
    {
        if(!heldObject) {
            grabbed = false;
            hitSuccess = false;
        }

        // Sets the direction of the player
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(!direction.Equals(Vector2.zero)) {
            playerDirection.Set(direction.x, direction.y);
        }

        // Grab object on square button on ps4 controller or E
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) {
            if(!grabbed) { // pick up
                Physics2D.queriesStartInColliders = false; 
                hits = Physics2D.RaycastAll(transform.position, playerDirection, distance);
                for(int i = 0; i < hits.Length; i++) {
                    if(hits[i].collider.gameObject.tag == "emotion") {
                        hit = hits[i];
                        hitSuccess = true;
                    }
                }
                if(hitSuccess)
                {
                    Debug.Log("hit collider: grabbed is true");
                    heldObject = hit.collider.gameObject;
                    grabbed = true;
                }
                else if (inPlayer == true) 
                {
                    Debug.Log("inPlayer: grabbed is true");
                    grabbed = true;
                }
                else 
                {
                    Debug.Log("grabbed i false");
                    grabbed = false;
                    hitSuccess = false;
                }

                if(grabbed) {
                    if(heldObject.tag != "emotion") {
                        heldObject = null;
                        grabbed = false;
                        hitSuccess = false;
                    }
                }

            } else { // drops
                heldObject = null;
                grabbed = false;
                hitSuccess = false;
            }
        }

        // Calculates the position of the hold point where the object will intersect
        holdPoint.position = transform.position + new Vector3(playerDirection.x, playerDirection.y, 0) * 1.1f; 
        
        if(grabbed) {
            Debug.Log("changing heldobject position");
            heldObject.transform.position = holdPoint.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Collision occured");
        inPlayer = true;
        if (!grabbed)
        {
            Debug.Log("held object set from collision");
            heldObject = collision.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        inPlayer = false;
    }

    // Tells you which direction raycast is facing and its length for debug purposes
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(playerDirection.x, playerDirection.y, 0)  * distance);   
    }
}