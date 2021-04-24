using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundObjectScript : MonoBehaviour
{
    public Transform target;

    public float rotationSpeed = 30;

    public float distanceToTarget;
    public float distanceChangeSensitivity = 0.2f;

    public float mouseScrollSensitivity = 0.1f;
    private float mouseScrollDelta;

    [Space, Header ("Debug Info")]
    [SerializeField] private float actualDistance;

    // Start is called before the first frame update
    void Start()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMouseWheelInput();
        ChangeDistance();
        OrbitAroundTarget();
        MoveDistanceChange();

        actualDistance = Vector3.Distance(target.position, transform.position);
    }

    /**
     * Orbits / rotates around the "target" transform
     */
    private void OrbitAroundTarget()
    {
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        transform.LookAt(target.position);
    }

    /**
     * Calculates and changes the distance / radius to the target gradually
     */
    private void MoveDistanceChange()
    {
        // distance will not changed whenever it gets to zero or below. A little offset prevents this behaviour.
        if(distanceToTarget <= 0) { distanceToTarget = 0.01f; }

        // calculates new position when the distance to target (radius) changes and moves towards it.
        Vector3 distanceChangePosition = (transform.position - target.position).normalized * distanceToTarget + target.position;
        transform.position = Vector3.MoveTowards(transform.position, distanceChangePosition, Time.deltaTime * distanceChangeSensitivity);
    }

    private void CheckForMouseWheelInput()
    {
        mouseScrollDelta =  Input.mouseScrollDelta.y * mouseScrollSensitivity;
    }

    private void ChangeDistance()
    {
        distanceToTarget += mouseScrollDelta;
    }
}
    
    
