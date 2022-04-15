using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVehicle : MonoBehaviour
{
    private bool inVehicle = false;
    Drive vehicleScript;
   // FirstPersonController personController;
    //public GameObject guiObj;
    GameObject player;
    public Camera ChaseCam;
    GameObject CarParent;
    public bool inObject;

    void Start()
    {
        vehicleScript = GetComponent<Drive>();
        //personController = GetComponent<FirstPersonController>();
        player = GameObject.FindWithTag("Player");
        // guiObj.SetActive(false);
        CarParent = GameObject.FindWithTag("CarParent");


    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            //guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                //guiObj.SetActive(false);
                player.transform.parent = gameObject.transform;
                //This is the most important code for parenting onjects so the player can mount objects 
                vehicleScript.enabled = true;
                player.SetActive(false);

            
                inVehicle = true;
                ChaseCam.gameObject.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //guiObj.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            vehicleScript.enabled = false;
            //personController.enabled = true;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
            ChaseCam.gameObject.SetActive(false);
        }
    }
}