using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundObjectScript : MonoBehaviour
{
    public Transform target;

    public float rotationSpeed = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        transform.LookAt(target.position);
    }


}
