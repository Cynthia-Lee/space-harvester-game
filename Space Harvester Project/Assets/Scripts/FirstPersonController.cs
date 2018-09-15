using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;
    public float walkSpeed = 8f;
    public float runSpeed; //GET TO THIS LATER, if the run key is down then multiply targetMoveAmount = moveDir * runspeed

    Transform cameraT;
    float verticalLookRotation; // ~60 to 60

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

	// Use this for initialization
	void Start () {
        cameraT = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
        //need to clamp this, limit top and bottom
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cameraT.localEulerAngles = Vector3.left * verticalLookRotation;

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Veritcal")).normalized;
        //a d or left right key
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
