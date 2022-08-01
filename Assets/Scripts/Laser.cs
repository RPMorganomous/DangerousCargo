using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private int _laserSpeed;

    [SerializeField] private float _laserLife;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        Destroy(this.GameObject(), _laserLife);

    }

    // Update is called once per frame
    void Update()
    {
    MoveLaser();
    }

    private void MoveLaser()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * _laserSpeed);
    }
    
}
