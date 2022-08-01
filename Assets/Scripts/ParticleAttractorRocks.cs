using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttractorRocks : MonoBehaviour
{
    [SerializeField] private Transform _attractorTransform;
    [SerializeField] private GameObject _attractorLight;

    private ParticleSystem _particleSystem;
    private ParticleSystem.Particle[] _particles = new ParticleSystem.Particle[10];

    public float speed = 10.0f;

    public DestroyRock _destroyRock;

    private Vector3 thePosition;

    [SerializeField] private AudioSource _particleDieSound, _particleDieSound2;
    private AudioSource _particleDieClip, _particleDieClip2;

    private int _oldLength = 0;
    private int _newLength;
    private bool _playedClip = false;

    public void Start ()
    {
        _particleSystem = GetComponent<ParticleSystem> ();
        _particleDieClip = _particleDieSound.GetComponent<AudioSource>();
        _particleDieClip2 = _particleDieSound2.GetComponent<AudioSource>();
    }
 
    public void LateUpdate()
    {
        if (_particleSystem.isPlaying) {
            int length = _particleSystem.GetParticles (_particles);
            Debug.Log("particles emitted: " + length);
            
            _newLength = length;
            if (_newLength < _oldLength)
            {
                _attractorLight.SetActive(true);
                if (_playedClip == false)
                {
                    _particleDieClip.Play();
                    Debug.Log("played particle death clip");
                    _playedClip = true;
                }
                else
                {
                    _particleDieClip2.Play();
                    Debug.Log("played particle death clip");
                    _playedClip = false;
                }
            }

            Vector3 attractorPosition = _attractorTransform.position;

            
            for (int i=0; i < length; i++)
            {
                _particles [i].position = _particles [i].position + (attractorPosition - _particles [i].position) / (_particles [i].remainingLifetime) * Time.deltaTime;

            }
            _particleSystem.SetParticles (_particles, length);

            if (length == 0)
            {
                _destroyRock._rockIsDead = true;
                _attractorLight.SetActive(false);
            }

            _oldLength = length;

        }
 
    }
}
