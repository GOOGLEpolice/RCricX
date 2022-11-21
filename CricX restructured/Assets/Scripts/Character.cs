using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Quaternion deviceRotation = DeviceRotation.Get();
        
        transform.rotation = deviceRotation;
    }
}
