using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;
    public float walkSpeed = 5f;
    //public float runSpeed; //GET TO THIS LATER, if the run key is down then multiply targetMoveAmount = moveDir * runspeed
    //maybe no run because it is in space
    public float jumpForce = 225;
    public LayerMask groundedMask;

    Transform cameraT;
    float verticalLookRotation; // ~60 to 60

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    bool grounded;

	// Use this for initialization
	void Start () {
        cameraT = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
        //need to clamp this, limit top and bottom
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cameraT.localEulerAngles = Vector3.left * verticalLookRotation;

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //a d or left right key
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        if(Input.GetButtonDown("Jump")) //jump button is set to space key
        {
            if(grounded)
            {
                GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
            }
            
        } //only allow player to jump if they are touching the ground
        grounded = false;
        Ray ray = new Ray(transform.position,-transform.up);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
        {
            //the capsule has origin in the middle
            //height of the capsule is 2
            grounded = true;
        }
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
