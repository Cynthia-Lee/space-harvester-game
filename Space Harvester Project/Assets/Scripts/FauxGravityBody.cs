using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour {

    public FauxGravityAttractor attractor;
    private Transform myTransform;
	// Use this for initialization
	void Start () {
        //rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        //attractor.Attract(myTransform);
	}
}
