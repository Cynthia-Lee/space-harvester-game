using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreClick : MonoBehaviour {

    private double progress = 0;
    
	private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.gameObject.tag.Contains("ore"))   //Contains method? Instead of having to write 5 if loops.
                {
                    if (hit.transform.GetComponent<Rigidbody>())
                    {
                        GameObject clickedOre = hit.transform.gameObject;
                        string value = clickedOre.gameObject.tag;
                        switch (value)
                        {
                            case "ore1":
                                progress += (1 * 1.5);
                                break;
                            case "ore2":
                                progress += (2 * 1.5);
                                break;
                            case "ore3":
                                progress += (3 * 1.5);
                                break;
                            case "ore4":
                                progress += (4 * 1.5);
                                break;
                            case "ore5":
                                progress += (5 * 1.5);
                                break;
                        }
                        PrintName(clickedOre);
                        MineOre(clickedOre);
                        print(progress);
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