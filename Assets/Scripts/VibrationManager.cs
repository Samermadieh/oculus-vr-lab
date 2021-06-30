using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static VibrationManager singleton;

    // Start is called before the first frame update
    void Start()
    {
        if(singleton && singleton != this)
        {
            Destroy(this);
        }
        else
        {
            singleton = this;
        }
    }

    public void Vibrate(AudioClip audio, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip(audio);

        if(controller == OVRInput.Controller.LTouch)
        {
            //Vibrate Left Controller
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controller == OVRInput.Controller.RTouch)
        {
            //Vibrate Right Controller
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }
}
