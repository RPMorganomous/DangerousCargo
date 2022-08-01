using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private int _speed, _rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(.2f, .2f, .2f));
        
        transform.position += transform.right * -_speed * Time.deltaTime;
        transform.Rotate(Vector3.right * _rotation *Time.deltaTime);
    }
}
