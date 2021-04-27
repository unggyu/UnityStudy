using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    private Rigidbody boxRigidbody;
    private float movePower = 5f;
    void Start()
    {
        boxRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Debug.Log(boxRigidbody.velocity);
        if (Input.GetKeyDown(KeyCode.A))
            boxRigidbody.AddForce(transform.right * movePower, ForceMode.Impulse);
        // boxRigidbody.AddForce(transform.right * movePower / Time.fixedDeltaTime, ForceMode.Force);
        // 둘이 똑같음
        else if (Input.GetKey(KeyCode.S))
            boxRigidbody.AddForce(transform.right * movePower, ForceMode.Force);
        else if (Input.GetKeyDown(KeyCode.D))
            boxRigidbody.AddForce(transform.right * movePower, ForceMode.VelocityChange);
        // boxRigidbody.AddForce(transform.right * movePower / Time.fixedDeltaTime, ForceMode.Acceleration);
        // 둘이 똑같음
        else if (Input.GetKey(KeyCode.F))
            boxRigidbody.AddForce(transform.right * movePower, ForceMode.Acceleration);
    }
}
