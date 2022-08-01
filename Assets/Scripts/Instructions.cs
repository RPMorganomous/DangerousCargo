using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    [SerializeField] private GameObject _instructionPanel;
    [SerializeField] public PlayerShipController _playerShipControllerScript;
    
    private bool menuOn = true;
    public bool isPaused = true;
    

    //private Image image;
    //private Color tempColor;
    
    // Start is called before the first frame update
    void Start()
    {
        //image = GetComponent<Image>();
        //tempColor = image.color;
        _playerShipControllerScript._thrustAudio.volume = 0;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        if (menuOn == true)
        {
            //tempColor.a = 0;
            _instructionPanel.GetComponent<RectTransform>().localScale = new Vector3(0,0);
            //_instructionPanel.SetActive(false);
            menuOn = false;
            _playerShipControllerScript._thrustAudio.volume = .5f;
            Time.timeScale = 1f;
            isPaused = false;
            _playerShipControllerScript._openingSceneComplete = true;
        }
        else
        {
            //tempColor.a = 1;
            _instructionPanel.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
            //_instructionPanel.SetActive(true);
            menuOn = true;
            _playerShipControllerScript._thrustAudio.volume = 0;
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
    
}
