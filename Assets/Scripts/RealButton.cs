using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RealButton : MonoBehaviour
{
    public UnityEvent onPressed, onReleased;
    public GameObject ball;

    [SerializeField]
    private float threshold = 0.1f, deadZone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if(isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    // Get Value Method to Get Percentage of Button down
    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;
        if(Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }

    // Pressed and Released Methods
    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }

    // Load Scenes
    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Spawn Basketball
    public void spawnBall()
    {
        var rigidbody = ball.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        ball.transform.position = new Vector3(1.138f, 1.007f, 2.716f);
    }
}
