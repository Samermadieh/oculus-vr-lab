using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject area1;
    public GameObject area2;
    public Text score;
    private AudioSource bouncingSound;
    private bool a1;
    private bool a2;

    private void Start()
    {
        bouncingSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == area1.name)
        {
            a1 = true;
        }
        else if(other.gameObject.name == area2.name)
        {
            if (a1)
            {
                score.text = (int.Parse(score.text) + 1).ToString();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == area2.name)
        {
            a1 = false;
            a2 = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bouncingSound.Play();
    }
}
