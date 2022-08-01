using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBottomMovementController : MonoBehaviour
{
    private int _x = 0, _y = 0, _z = 0;
   
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){ _z = 15;}
        if (Input.GetKeyUp(KeyCode.W)){_z = 0;}
        if (Input.GetKey(KeyCode.S)){_z = -15;}
        if (Input.GetKeyUp((KeyCode.S))){_z = 0;}
        if (Input.GetKey(KeyCode.D)){_y = 15;}
        if (Input.GetKeyUp(KeyCode.D)){_y = 0;}
        if (Input.GetKey(KeyCode.A)){_y = -15;}
        if (Input.GetKeyUp(KeyCode.A)){_y = 0;}

        transform.localEulerAngles = new Vector3(_x,_y,_z);
    }
}
