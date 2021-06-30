using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{
    public GameObject quitCube;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == quitCube)
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
