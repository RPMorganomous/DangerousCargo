using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnginesWarmingUp : MonoBehaviour
{
    [SerializeField]
    private float lightStep = 10f;
    private Light thisLight;

    // Start is called before the first frame update
    void Start()
    {
        thisLight = GetComponent<Light>();
        //thisLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        thisLight.intensity += lightStep * Time.deltaTime;
        
    }
}
