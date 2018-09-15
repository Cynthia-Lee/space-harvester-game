using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreClick : MonoBehaviour {

    public float force = 25;

	private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.collider.gameObject.tag == "ore")
                    {
                        //Rigidbody rb = GetComponent<Rigidbody>();
                        if (hit.transform.GetComponent<Rigidbody>())
                        {
                            GameObject clickedOre = hit.transform.gameObject;
                            PrintName(clickedOre);
                            MineOre(clickedOre);
                        }
                    }

                }

            }

        }

    }

    private void PrintName(GameObject ob)
    {
        print(ob.name); 
    }

    private void MineOre(GameObject ore)
    {
        new WaitForSeconds(2);
        ore.SetActive(false);
        print("This is a dank ore we found. Let's mine it!");
        
    }
}