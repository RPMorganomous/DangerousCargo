using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntineRightMovementController : MonoBehaviour
{
    [SerializeField] private int engineRotation;
    private int _x = 0, _y = 0, _z = 0;
   
    void Update()
    {
        // if (Input.GetKey(KeyCode.W)){ _z = engineRotation;}
        // if (Input.GetKeyUp(KeyCode.W)){_z = 0;}
        // if (Input.GetKey(KeyCode.S)){_z = -1*engineRotation;}
        // if (Input.GetKeyUp((KeyCode.S))){_z = 0;}
        // if (Input.GetKey(KeyCode.D)){_y = engineRotation;}
        // if (Input.GetKeyUp(KeyCode.D)){_y = 0;}
        // if (Input.GetKey(KeyCode.A)){_y = -1*engineRotation;}
        // if (Input.GetKeyUp(KeyCode.A)){_y = 0;}
        if (Input.GetKey(KeyCode.D)){_z = -1*engineRotation;}
        if (Input.GetKeyUp(KeyCode.D)){_z = 0;}
        if (Input.GetKey(KeyCode.A)){_z = engineRotation;}
        if (Input.GetKeyUp(KeyCode.A)){_z = 0;}
        
        transform.localEulerAngles = new Vector3(_x,_y,_z);
    }
}
