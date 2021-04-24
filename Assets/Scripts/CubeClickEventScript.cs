using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClickEventScript : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    /**
     * Collider Event when clicked on attached object
     */
    private void OnMouseDown()
    {
        // checks if anyone is subscribed to the event. won't trigger if no one is subscribed.
        if(OnClicked != null)
        {
            OnClicked(); // sends event broadcast to subscribed methods
        }
    }
}
