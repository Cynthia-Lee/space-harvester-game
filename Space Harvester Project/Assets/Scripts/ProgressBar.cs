using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

    // Use this for initialization
    //void Start () {
    //	
    //}

    // Update is called once per frame
    //void Update () {
    //	
    //}

    public Image currentProgress;
    public Text barText;

    private float start = 0;
    private float max = 100; 

    private void Start()
    {
        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        double val = new OreClick().getProgress();
        float ratio = (float)(val / max);
        //need to make sure it doesn't go over 100...
        currentProgress.rectTransform.localScale = new Vector3(ratio, 1, 1);
        barText.text = val.ToString() + '%';
    }

    private void increaseProgress()
    {
        double val = new OreClick().getProgress();
        if(val > 100)
        {
            val = max;
        }
        UpdateProgressBar();
    }
}
