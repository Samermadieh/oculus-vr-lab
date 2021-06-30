using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public void playBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void gunsBtn()
    {
        SceneManager.LoadScene("Guns");
    }

    public void quitBtn()
    {
        Application.Quit();
    }

}
