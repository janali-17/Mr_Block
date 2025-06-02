using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallScaling : MonoBehaviour
{
    private float rotationAngle = 90f;
    private float currentScale;
    private bool isWaiting = false;
    private float timer = 0f;

    public float scalingFactor = 1f;
    public float scalingSpeed = 15f;
    public float minScale = .5f;
    public float maxScale = 1.5f;
    public float scaleDelay = 2f;



    void Update()
    {
        RotateSpikeBall();
        if (isWaiting)
        {
            HandleWaiting();
        }
        else 
        {
        ScaleSpikeBall();
        }

    }

    private void HandleWaiting()
    {
        timer += Time.deltaTime;
        if (timer > scaleDelay)
        {
            isWaiting = false ;
            timer = 0f ;
        }
    }

    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);

    private void ApplyCurrentScale()
    {
        transform.localScale = new Vector3(currentScale, currentScale, 1);
    }

    private void ScaleSpikeBall()
    {
        currentScale += scalingFactor * scalingSpeed * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);

        if(currentScale == minScale ||  currentScale == maxScale )
        {
            scalingFactor = -scalingFactor;
            isWaiting = true ;
        }
        ApplyCurrentScale();
    }

}
