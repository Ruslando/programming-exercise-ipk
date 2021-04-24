using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundObjectScript : MonoBehaviour
{
    public Transform target;

    public float rotationSpeed = 30;

    public float distanceToTarget;
    public float distanceChangeSpeed;

    public float actualDistance;

    // Start is called before the first frame update
    void Start()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAroundTarget();
        ChangeDistanceToTarget();
        actualDistance = Vector3.Distance(target.position, transform.position);
    }

    private void OrbitAroundTarget()
    {
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        transform.LookAt(target.position);
    }

    private void ChangeDistanceToTarget()
    {
        // calculates new position when the distance to target (radius) changes and moves towards it.
        Vector3 distanceChangePosition = (transform.position - target.position).normalized * distanceToTarget + target.position;
        transform.position = Vector3.MoveTowards(transform.position, distanceChangePosition, Time.deltaTime * distanceChangeSpeed);
    }
}
    
    
