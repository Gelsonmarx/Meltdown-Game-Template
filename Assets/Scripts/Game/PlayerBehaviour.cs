using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    bool jumping = false, crounched = false, isOnground = true;

    [SerializeField] float jumpForce = 3f, groundDetector = 1.5f, normalScale = 1.35f, crounchedScale = 0.8f;

    Rigidbody rb;

    CapsuleCollider col;

    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive) return;

        if(Input.GetKey(KeyCode.S)) {
            if(!jumping && !crounched) {
                Crounch();
            }
        }

        if(Input.GetKeyUp(KeyCode.S)) {
            if(crounched) StandUp();
        }

        if(Input.GetKeyDown(KeyCode.W)) {
            if(!jumping && !crounched && isOnground) {
                Jump();
            }
        }

    }

    public void PlayerDead() => isAlive = false;

    void Jump() {
        Debug.Log("Jumping!!!");
        rb.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
    }
    void Crounch() {
         Debug.Log("Getting Down!!!");
        crounched = true;
        transform.localScale = new Vector3(transform.localScale.x, crounchedScale, transform.localScale.z);
    }

    void StandUp() {
         Debug.Log("Standing Up!!!");
         crounched = false;
        transform.localScale = new Vector3(transform.localScale.x, normalScale, transform.localScale.z);
    }

    void BackToTheGround(){
        Debug.Log("BackToTheGround");
        jumping = false;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground")) {
            isOnground =true;
            jumping = false;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground")) {
            isOnground =false;
            jumping = true;
        }
    }
}
