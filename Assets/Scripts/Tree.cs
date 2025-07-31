using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration;

    private float currentTime = 0f;
    private bool hasBeenClicked = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Once we've clicked the button, we can start growing and calling this logic
        if (hasBeenClicked == true)
        {
            Grow();
        }
    }

    //Called from our button click
    public void StartGrow()
    {
        //Reset the current time 
        currentTime = 0f;

        //Let this script know that the button has been pressed
        hasBeenClicked = true;
    }

    public void Grow()
    {
        bool isGrowing = currentTime < duration;
        if (isGrowing)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            hasBeenClicked = false;
        }

        //We use the time ratio so that it takes the duration to get from the start
        //to the end when we use the animation curve
        //(or something like a Lerp)
        float timeRatio = currentTime / duration;

        transform.localScale = Vector3.one * curve.Evaluate(timeRatio);
    }

}
