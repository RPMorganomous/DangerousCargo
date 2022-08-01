using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera _followShipCam;
    [SerializeField] private CinemachineVirtualCamera _cockpitCam002;
    [SerializeField] private CinemachineVirtualCamera _laserCam;
    [SerializeField] private CinemachineVirtualCamera _distantCam;
    [SerializeField] private GameObject _spaceFighter;
    [SerializeField] private GameObject _cockpitDash;
    
    private bool cockpitCamActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R pressed");
            SwitchCam();
        }
    }

    private void SwitchCam()
    {
        if (cockpitCamActive == false)
        {
            ActivateCockpitCam();
        }
        else
        {
            ActivateFollowShipCam();
        }
    }

    private void ActivateFollowShipCam()
    {
        _spaceFighter.GetComponent<MeshRenderer>().enabled = true;
        //_spaceFighter.SetActive(true);
        _cockpitDash.SetActive(false);
        _followShipCam.Priority = 15;
        _cockpitCam002.Priority = 10;
        cockpitCamActive = false;
    }

    private void ActivateCockpitCam()
    {
        _cockpitDash.SetActive(true);
        //_spaceFighter.SetActive(false);
        _spaceFighter.GetComponent<MeshRenderer>().enabled = false;
        _cockpitCam002.Priority = 15;
        _followShipCam.Priority = 10;
        cockpitCamActive = true;
    }
    
}
