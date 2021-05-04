using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    CameraHandler camHand;
    void Start()
    {
        camHand = FindObjectOfType<CameraHandler>();
        camHand.MovetoTarget(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
