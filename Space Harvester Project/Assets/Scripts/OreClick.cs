using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreClick : MonoBehaviour {
    
	private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.gameObject.tag == "ore")   //Contains method? Instead of having to write 5 if loops.
                {
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

    private void PrintName(GameObject ob)
    {
        print(ob.name); 
    }

    private void MineOre(GameObject ore)
    {

        ore.SetActive(false);
        print("This is a dank ore we found. Let's mine it!");
    }
}