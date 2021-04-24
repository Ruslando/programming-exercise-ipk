using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorScript : MonoBehaviour
{
    /**
     * Subscribes to OnClicked event of cube click event script
     */
    private void OnEnable()
    {
        CubeClickEventScript.OnClicked += ChangeColorRandomized;
    }

    /**
     * Unsubscribes to OnClicked event of cube click event script
     */
    private void OnDisable()
    {
        CubeClickEventScript.OnClicked += ChangeColorRandomized;
    }

    /**
     * Changes material of attached object when called
     */
    private void ChangeColorRandomized()
    {
        Color color = new Color(Random.value, Random.value, Random.value);
        Renderer renderer = GetComponent<Renderer>();
        if (renderer)
        {
            renderer.material.color = color;
        }
        
    }
}
