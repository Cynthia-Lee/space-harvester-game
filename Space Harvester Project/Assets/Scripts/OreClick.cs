using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreClick : MonoBehaviour {

    private double progress = 0;
    private double rawScoreMultiplier = 1.5;
    
	private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                if (hit.collider.gameObject.tag.Contains("ore"))   //Contains method? Instead of having to write 5 if loops.
                {
                    if (hit.transform.GetComponent<Rigidbody>())
                    {
                        GameObject clickedOre = hit.transform.gameObject;
                        string value = clickedOre.gameObject.tag;
                        switch (value)  //Each ore of varying size will give more or less progress points.
                        {
                            case "ore1":
                                progress += (1 * rawScoreMultiplier);
                                break;
                            case "ore2":
                                progress += (2 * rawScoreMultiplier);
                                break;
                            case "ore3":
                                progress += (3 * rawScoreMultiplier);
                                break;
                            case "ore4":
                                progress += (4 * rawScoreMultiplier);
                                break;
                            case "ore5":
                                progress += (5 * rawScoreMultiplier);
                                break;
                        }
                        PrintName(clickedOre);
                        MineOre(clickedOre);
                        print(progress);
                    }

                }
          
            }

        }

        //if ()   //ESC is pushed or time runs out.
        //{
//<<<<<<< HEAD
        //   MissionScore();
//=======
        //    MissionScore();
//>>>>>>> 8d39e9b7095213c4e6388eee61cd44e10dbf0ad0
        //}
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

    private string MissionScore()
    {
        string score = "";
        if (progress > 91)
        {
            score += "You earned an A! Superb mining!";
        } else if (progress > 80 && progress < 91)
        {
            score += "You earned a B+. You did a great job!";
        }
        else if (progress > 60 && progress < 80)
        {
            score += "You earned a B. ";
        }
        else if (progress > 40 && progress < 60)
        {
            score += "You earned a B-. ";
        }
        else
            score += "You earned a C. Not enough ores were harvested by you.";
        return score;
    }
}