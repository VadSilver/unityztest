using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;

public class CamFixPosition : MonoBehaviour
{
    
    public Transform ThirdPersonPosCam;
    public Transform TopdownPosCam;
    public GameObject PlayerHealth;
    public Transform pRifle;
    public Transform RifleThirdPersonPosCam;
    public Transform RifleTopdownPosCam;

    bool switchCam = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = TopdownPosCam;
        transform.position = TopdownPosCam.position;
        transform.rotation = TopdownPosCam.rotation;
        PlayerHealth.GetComponent<PlayerMovementMobile>().ifTopView = true;
        GetComponent<Camera>().fieldOfView = 30;

        //RIFLE
        pRifle.parent = RifleTopdownPosCam;
        pRifle.position = RifleTopdownPosCam.position;
        pRifle.rotation = RifleTopdownPosCam.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCam()
    {

        if (!switchCam)
        {
            PlayerHealth.GetComponent<PlayerMovementMobile>().ifTopView = false;
            transform.parent = ThirdPersonPosCam;
            transform.position = ThirdPersonPosCam.position;
            transform.rotation = ThirdPersonPosCam.rotation;
            GetComponent<Camera>().fieldOfView = 60;

            print("ThirdPersonPosCam");

            //RIFLE
            pRifle.parent = RifleThirdPersonPosCam;
            pRifle.position = RifleThirdPersonPosCam.position;
            pRifle.rotation = RifleThirdPersonPosCam.rotation;
        }
        else {
            PlayerHealth.GetComponent<PlayerMovementMobile>().ifTopView = true;
            transform.parent = TopdownPosCam;
            transform.position = TopdownPosCam.position;
            transform.rotation = TopdownPosCam.rotation;
            GetComponent<Camera>().fieldOfView = 30;
            print("TopdownPosCam");

            //RIFLE
            pRifle.parent = RifleTopdownPosCam;
            pRifle.position = RifleTopdownPosCam.position;
            pRifle.rotation = RifleTopdownPosCam.rotation;
        }
        switchCam = !switchCam;
        
    }
}
