using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{

    public WheelCollider[] WCs;

    public GameObject []Wheels;

    public float torque = 200;
    public float MaxSteerAngle = 30;

    EnterVehicle VehicleScript;

   


    protected FirstPersonController Fps;

    // Start is called before the first frame update
    void Start()
    {
     
    }


    void Go(float accel, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * MaxSteerAngle;
        float thrustTorque = accel * torque;

        for(int i =0; i < 4; i++)
        {
            WCs[i].motorTorque = thrustTorque;


            if(i < 2)
                WCs[i].steerAngle = steer;
            
          

            Quaternion quat;
            Vector3 position;
            WCs[i].GetWorldPose(out position, out quat);
            Wheels[i].transform.position = position;
            Wheels[i].transform.rotation = quat;
        }
    }
      
    // Update is called once per frame
    void Update()
    {

        float a = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Horizontal");
        Go(a, s);


        // if (Engaged == true && Input.GetKeyDown(KeyCode.E))
        // {
        // Engaged = false;
        // }


        // if (Engaged == true)
        // {
        //  float a = Input.GetAxis("Vertical");
        // float s = Input.GetAxis("Horizontal");
        //  Go(a, s);

        // gameObject.transform.GetChild(3).gameObject.SetActive(true);

        // Fps.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        // Fps.controller.transform.gameObject.SetActive(false);



        // }




    }
}
