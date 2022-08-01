using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Explode : MonoBehaviour

{
    //[SerializeField] AudioSource _explosionAudio;
    private AudioSource _explosionClip;
    private ParticleSystem _particleSystem;
    private SphereCollider _sphereCollider;
    private Rigidbody[] _rigidbodies;
    private SphereCollider[] _sphereColliders;
    private bool _hasExploded = false;
    [SerializeField] private float _explosionForceLow = 200f, _explosionForceHigh = 300f;
    
    

        // Start is called before the first frame update
    void Start()
    {
       _explosionClip = GetComponent<AudioSource>();
       _particleSystem = GetComponent<ParticleSystem>();
       _sphereCollider = GetComponent<SphereCollider>();
       _rigidbodies = GetComponentsInChildren<Rigidbody>();
       _sphereColliders = GetComponentsInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hasExploded == false)
        {
            
        
            if (other.tag == "Laser")
            {
                Destroy(other.gameObject);
                _sphereCollider.enabled = false;
                _particleSystem.Play(withChildren:false);
                
                _explosionClip.Play();
                //Debug.Log("Laser hit asteroid.");
                
                //_sphereCollider.enabled = false;
                
                //Destroy(other.gameObject);

                foreach (Rigidbody body in _rigidbodies)
                {
                    body.isKinematic = false;
                    body.AddExplosionForce(Random.Range(_explosionForceLow, _explosionForceHigh), transform.position, Random.Range(8f,10f));
                }
                
                foreach (SphereCollider sphere in _sphereColliders)
                {
                    sphere.enabled = true;
                }

                _hasExploded = true;

                // foreach (Transform child in transform)
                // {
                //     child.GetComponent<Rigidbody>().isKinematic = false;
                //     child.GetComponent<SphereCollider>().enabled = true;
                // }
            }
            
        }
    }
}
