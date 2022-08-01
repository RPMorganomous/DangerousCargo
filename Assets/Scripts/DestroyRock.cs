using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    private AudioSource _explosionClip;
    private SphereCollider _sphereCollider;
    private ParticleSystem _particleSystem;
    private MeshRenderer _meshRenderer;

    public bool _rockIsDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _explosionClip = GetComponent<AudioSource>();
        _sphereCollider = GetComponent<SphereCollider>();
        _particleSystem = GetComponent<ParticleSystem>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rockIsDead == true)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            //Debug.Log("Laser hit asteroid.");
            
            _sphereCollider.enabled = false;
            
            Destroy(other.gameObject);
            
            _particleSystem.Play();
            
            _explosionClip.Play();
            
            _meshRenderer.enabled = false;
        }
        
    }
    
}
