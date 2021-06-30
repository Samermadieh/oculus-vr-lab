using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootButton;
    private AudioSource gunShotAudio;

    // Start is called before the first frame update
    void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        gunShotAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootButton, ovrGrabbable.grabbedBy.GetController()))
        {
            //Keep Vibration off for now to save battery:
            //VibrationManager.singleton.Vibrate(gunShotAudio.clip, ovrGrabbable.grabbedBy.GetController());
            simpleShoot.TriggerShoot();
            simpleShoot.Shoot();
            simpleShoot.CasingRelease();
            gunShotAudio.Play();
        }
    }
}
