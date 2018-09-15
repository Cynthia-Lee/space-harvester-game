using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour {

    public float gravity = -10f;

    //will be called by each gravity body in the scene
    public void Attract(Transform body) {
        Vector3 targetDir = (body.position - transform.position).normalized;
        // normalized to be always the same length, because it is a direction
        Vector3 bodyUp = body.up;

        body.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * body.rotation;
        //supplying the rotation

        //Apply downwards force to the object

        body.GetComponent<Rigidbody>().AddForce(targetDir * gravity);
        //body.rigidbody.AddForce(targetDir * gravity);
        
    } 
        

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
