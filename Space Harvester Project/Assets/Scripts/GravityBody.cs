using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   [RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {

    GravityAttractor planet;

    void Awake(){
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //don't want rigid bodies to do its own rotation

    }

    private void FixedUpdate()
    {
        planet.Attract(transform);
    }

    // Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
    //void Update () {

    //}
}
