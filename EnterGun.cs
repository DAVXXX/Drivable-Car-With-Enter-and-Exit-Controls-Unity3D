using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGun : MonoBehaviour
{

    bool isInTrigger = false;
    private bool InGun = false;
    Gun GunScript;
    // FirstPersonController personController;
    //public GameObject guiObj;
    GameObject player;
    public Camera GunCam;
    GameObject CarParent;
    GameObject gun;

    void Start()
    {
        GunScript = GetComponent<Gun>();
        //personController = GetComponent<FirstPersonController>();
        player = GameObject.FindWithTag("Player");
        // guiObj.SetActive(false);
        CarParent = GameObject.FindWithTag("CarParent");

        gun = GameObject.FindWithTag("Gun");

    }

    // Update is called once per frame

    void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKey(KeyCode.E))
            {
                //guiObj.SetActive(false);


                player.transform.parent = gameObject.transform;
                //This is the most important code for parenting onjects so the player can mount objects 
                GunScript.enabled = true;
                player.SetActive(false);



                GunCam.gameObject.SetActive(true);

            }
            if (InGun == true && Input.GetKey(KeyCode.F))
            {
                GunScript.enabled = false;
              
                player.SetActive(true);
                player.transform.parent = null;
                InGun = false;
                GunCam.gameObject.SetActive(false);
            }
        }
        
       
    }
    void OnTriggerEnter()
    {
        isInTrigger = true;

    }

    void OnTriggerExit(Collider other)
    {
       

        isInTrigger = false;
        //if (other.gameObject.tag == "Player")
        //{
        //guiObj.SetActive(false);
        //}
    }
}