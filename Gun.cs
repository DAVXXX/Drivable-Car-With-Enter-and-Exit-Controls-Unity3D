using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate =  15f;
    private float nextTimeToFire =  0f;


    public float impactForce = 30f;
    public float reloadTime = 1f;

    private bool isReloading = false;

    public int maxAmmo = 3;
    private int currentAmmo;


    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Animator anim;

 


    public Camera GunCam;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        currentAmmo = maxAmmo;

       
    }

    private void OnEnable()
    {
        isReloading = false;
        anim.SetBool("Reloading", false);
    }


    // Update is called once per frame
    void Update()
     {

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine (Reload());
            return;
        }


        if 
            (Input.GetButtonDown("Fire1")&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            Shoot();
            
            anim.SetTrigger("Recoil");
        }

     }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        anim.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);

        anim.SetBool("Reloading", false);

        yield return new WaitForSeconds(0.25f);


        currentAmmo = maxAmmo;

        isReloading = false;
    }

    public void Shoot()
    {

        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        //This will detect out hit 

        if (Physics.Raycast(GunCam.transform.position, GunCam.transform.forward, out hit, range))
        // using raycast we can take (Our fpscam take its posistion, 
        // shoot our ray cast forward, give back a hit result, based on our range varible)
        {
            Debug.Log(hit.transform.name);


           // Enemy enemy = hit.transform.GetComponent<Enemy>();
            //BuilingHealth building = hit.transform.GetComponent<BuilingHealth>();
            //ToxicAir air = hit.transform.GetComponent<ToxicAir>();

           /// if (enemy != null )
           // {
               // enemy.TakeDamage(damage);
               
           // }

           // if (hit.rigidbody != null)
            //{
       
               // hit.rigidbody.AddForce(-hit.normal * impactForce);

              // building.TakeDamage(damage);
        //    }


            
        }


        if (impactEffect)
        {
            GameObject impactEffectclone = Instantiate( impactEffect ,hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;

            Destroy(impactEffectclone,1);
        }
       
    }

    
    
}
