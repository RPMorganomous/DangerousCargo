using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerShipController : MonoBehaviour
{
    //public Instructions _instructionsScript;
    [SerializeField] private Transform _thisShip;

    [SerializeField] private Transform _engineHousingBottomLeft;
    [SerializeField] private Transform _engineHousingBottomRight;
    [SerializeField] private Transform _engineHousingTopLeft;
    [SerializeField] private Transform _engineHousingTopRight;
    
    [SerializeField] private float _turnSpeed;
    //[SerializeField] private float _boostSpeed;
    private float _currentSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _minSpeed;
    [SerializeField] private GameObject _engineFlameLeft;
    [SerializeField] private GameObject _engineFlameRight;
    [SerializeField] private GameObject _engineFlameTopLeft;
    [SerializeField] private GameObject _engineFlameTopRight;
    
    private ParticleSystem.MainModule _leftEnginePS;
    private ParticleSystem.MainModule _rightEnginePS;
    private ParticleSystem.MainModule _leftEngineTopPS;
    private ParticleSystem.MainModule _rightEngineTopPS;
    private ParticleSystem.EmissionModule _leftEngineEmission;
    private ParticleSystem.EmissionModule _rightEngineEmission;
    private ParticleSystem.EmissionModule _leftEngineTopEmission;
    private ParticleSystem.EmissionModule _rightEngineTopEmission;
    private ParticleSystem.ShapeModule _leftEngineShape;
    private ParticleSystem.ShapeModule _rightEngineShape;
    private ParticleSystem.ShapeModule _leftEngineTopShape;
    private ParticleSystem.ShapeModule _rightEngineTopShape;

    private float yaw, pitch, roll;
    private float engineYaw;
    private float enginePitch;
    private float engineRoll;

    [SerializeField] private GameObject _thrustAudioClip;
    public AudioSource _thrustAudio;

    [SerializeField] private GameObject _laser;
    [SerializeField] private GameObject _gun1, _gun2, _gun3, _gun4;
    [SerializeField] private GameObject _laserAudioClip;
    private AudioSource _laserAudio;
    [SerializeField] private float _laserFireRate;
    private float _canFire = -1.0f;
    public bool _openingSceneComplete = false;

    [SerializeField] private int _engineRotation; // degrees of rotation
    private float _x = 0, _yL = 0, _yR = 0, _zL = 0, _zR = 0; // values for engine rotation
    void Start()
    {
        _currentSpeed = 0;
        _leftEnginePS = _engineFlameLeft.GetComponent<ParticleSystem>().main;
        _rightEnginePS = _engineFlameRight.GetComponent<ParticleSystem>().main;
        _leftEngineTopPS = _engineFlameTopLeft.GetComponent<ParticleSystem>().main;
        _rightEngineTopPS = _engineFlameTopRight.GetComponent<ParticleSystem>().main;
        
        _leftEngineEmission = _engineFlameLeft.GetComponent<ParticleSystem>().emission;
        _rightEngineEmission = _engineFlameRight.GetComponent<ParticleSystem>().emission;
        _leftEngineTopEmission = _engineFlameTopLeft.GetComponent<ParticleSystem>().emission;
        _rightEngineTopEmission = _engineFlameTopRight.GetComponent<ParticleSystem>().emission;
        
        _leftEngineShape = _engineFlameLeft.GetComponent<ParticleSystem>().shape;
        _rightEngineShape = _engineFlameRight.GetComponent<ParticleSystem>().shape;
        _leftEngineTopShape = _engineFlameTopLeft.GetComponent<ParticleSystem>().shape;
        _rightEngineTopShape = _engineFlameTopRight.GetComponent<ParticleSystem>().shape;

        _thrustAudio = _thrustAudioClip.GetComponent<AudioSource>();
        _laserAudio = _laserAudioClip.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (_openingSceneComplete == true)
        {
        Turn();
        Thrust();
        if (Input.GetMouseButton(0) && Time.time > _canFire)
        {
            FireLaser();
        }
    }
}
    
    void Update()
    {

    }
    
    private void Turn()
    {
        roll = _turnSpeed * Time.deltaTime * (-1 * Input.GetAxis("Roll"));
        
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            yaw = (mousePosition.x - (Screen.width * .5f)) / (Screen.width * .5f);
            pitch = (mousePosition.y - (Screen.height * .5f)) / (Screen.height * .5f);

            _yL = yaw * _engineRotation;
            _yR = yaw * _engineRotation;
            _zL = pitch * _engineRotation;
            _zR = pitch * _engineRotation;
        }

        if (Input.GetKey(KeyCode.D)) { _zL = _engineRotation; _zR = -1*_engineRotation; }
        if (Input.GetKeyUp(KeyCode.D)){_zL = 0; _zR = 0;}
        if (Input.GetKey(KeyCode.A)){_zL = -1*_engineRotation; _zR = _engineRotation;}
        if (Input.GetKeyUp(KeyCode.A)){_zL = 0; _zR = 0;}
        
        _engineHousingBottomLeft.transform.localEulerAngles = new Vector3(_x,_yL,_zL);
        _engineHousingTopLeft.transform.localEulerAngles = new Vector3(_x, _yL, _zL);
        _engineHousingBottomRight.transform.localEulerAngles = new Vector3(_x,_yR,_zR);
        _engineHousingTopRight.transform.localEulerAngles = new Vector3(_x, _yR, _zR);
        
        _thisShip.Rotate(roll, yaw*2, pitch*2);
    }

    private void FireLaser()
    {
        _canFire = Time.time + _laserFireRate;
        Instantiate(_laser, _gun1.transform);
        Instantiate(_laser, _gun2.transform);
        Instantiate(_laser, _gun3.transform);
        Instantiate(_laser, _gun4.transform);
        _laserAudio.Play();
    }

    private void Thrust()
    {

            _thrustAudio.volume = .5f;

            _leftEnginePS.startSpeed = 5;
            _rightEnginePS.startSpeed = 5;
            _leftEngineTopPS.startSpeed = 5;
            _rightEngineTopPS.startSpeed = 5;

            _leftEngineEmission.rateOverTime = 14;
            _rightEngineEmission.rateOverTime = 14;
            _leftEngineTopEmission.rateOverTime = 14;
            _rightEngineTopEmission.rateOverTime = 14;

            _leftEngineShape.angle = 7;
            _rightEngineShape.angle = 7;
            _leftEngineTopShape.angle = 7;
            _rightEngineTopShape.angle = 7;

            if (Input.GetKey(KeyCode.W))
            {
                _currentSpeed++;
                if (_currentSpeed > _maxSpeed)
                {
                    _currentSpeed = _maxSpeed;
                }

                _leftEnginePS.startSpeed = 10;
                _rightEnginePS.startSpeed = 10;
                _leftEngineTopPS.startSpeed = 10;
                _rightEngineTopPS.startSpeed = 10;

                _leftEngineEmission.rateOverTime = 100;
                _rightEngineEmission.rateOverTime = 100;
                _leftEngineTopEmission.rateOverTime = 100;
                _rightEngineTopEmission.rateOverTime = 100;

                _thrustAudio.volume = 100;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                _thrustAudio.volume = .5f;
            }

            if (Input.GetKey(KeyCode.S))
            {
                _currentSpeed--;
                if (_currentSpeed < _minSpeed)
                {
                    _currentSpeed = _minSpeed;
                }

                _leftEngineShape.angle = 90;
                _rightEngineShape.angle = 90;
                _leftEngineTopShape.angle = 90;
                _rightEngineTopShape.angle = 90;
            }

            _thisShip.position += _thisShip.right * _currentSpeed * Time.deltaTime; // * Input.GetAxis("Thrust")
        }
    
}
