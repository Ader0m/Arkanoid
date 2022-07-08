using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public delegate void OnSwipeInput(Vector2 position);
    public static event OnSwipeInput SwipeEvent;

    private Camera _camera;   
    private Vector2 swapDelta;
    

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {        
        SolveDelta();
    }
    
    void SolveDelta()
    {
        if (Input.touchCount == 1)
        {
            if (SwipeEvent != null)
            {
                swapDelta = Input.GetTouch(0).position - new Vector2(_camera.pixelWidth / 2, 0);               
                SwipeEvent(swapDelta.x > 0 ? Vector2.right : Vector2.left);
            }
        }
    }
}
