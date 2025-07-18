using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    private float rotationAngle = 90f;


    void Update() => RotateSpikeBall();

    private void RotateSpikeBall()=> transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);

}
