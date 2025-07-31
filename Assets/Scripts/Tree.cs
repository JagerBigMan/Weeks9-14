using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration;
    public List<Transform> appleTransforms;

    private float currentTime = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    //Called from our button click
    //A wrapper method for the Coroutine
    public void StartGrow()
    {
        //Reset the current time 
        currentTime = 0f;

        StartCoroutine(Grow());
    }

    //Adding IEnumerator as the return type
    //Sets the method to be a Coroutine method
    public IEnumerator Grow()
    {
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;

            //We use the time ratio so that it takes the duration to get from the start
            //to the end when we use the animation curve
            //(or something like a Lerp)
            float timeRatio = currentTime / duration;

            transform.localScale = Vector3.one * curve.Evaluate(timeRatio);
            //We need to return something to satisfy IEnumerator as the return value
            //This is the syntax for doing so

            //yield return null will relinquish control to everything else
            //for the rest of this frame so that the Coroutine doesn't hold Unity
            //hostage
            yield return null;
        }

        currentTime = 0f;

        int i = 0;
        while (currentTime < duration && i < appleTransforms.Count)
        {
            currentTime += Time.deltaTime;

            float timeRatio = currentTime / duration;

            appleTransforms[i].localScale = Vector3.one * curve.Evaluate(timeRatio);

            yield return null;

            if (currentTime >= duration)
            {
                i++;
                currentTime = 0;
            }

        }
        Debug.Log("We've reached the end of the coroutine");
        //Coroutines are really really really nice when you want to run things in 
        //a sequence one after the other

    }

}
