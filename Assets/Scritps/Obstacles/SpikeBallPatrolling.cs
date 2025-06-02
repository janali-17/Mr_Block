using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallPatrolling : MonoBehaviour
{
    private float rotationAngle = 90f;
    [SerializeField]private float patrolSpeed = 2f;
    [SerializeField]private Vector3 pointA;
    [SerializeField]private Vector3 pointB;
    [SerializeField]private Vector3 targetPoint;


    private void Start()
    {
        SetPetrolPoints();
    }

    void Update()
    {
        RotateSpikeBall();
        PatrolSpikeBall();
    }

    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime); 

    private void PatrolSpikeBall()
    {
        transform.position = Vector3.MoveTowards(transform.position,targetPoint,patrolSpeed * Time.deltaTime);

        if(transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }
    
    private void SetPetrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
        
    }
}
