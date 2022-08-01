using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Reticule : MonoBehaviour
{

    [SerializeField] private Image reticle;

    private void Start()
    {
        reticle.color = new Color(1, 1, 1, 0.75f);
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Quaternion.AngleAxis(-15, transform.right) * transform.forward, out hit, 300f))
        {
            //Debug.Log("Raycast Hit!");
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                reticle.color = new Color(1, 0, 0, 0.75f);
                
            }
        }
        else
        {
            reticle.color = new Color(1, 1, 1, 0.75f);
        }
        //Debug.DrawRay(transform.position, Quaternion.AngleAxis(-15, transform.right) * transform.forward * 100, Color.green, 1f);
        
        //Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 10f);
        //Debug.Log("it's doing something");
    }
}
