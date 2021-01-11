using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public Animator forward;
    public Vector3 m_EulerAngleVelocity;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        m_EulerAngleVelocity = new Vector3(velocity, 0, 0);
        rb = this.GetComponent<Rigidbody>();
        forward.speed = 0;
    }

    void Update()
    {
        forward.SetFloat("forward", Input.GetAxis("Horizontal"));
        forward.SetFloat("pedal", Input.GetAxis("Vertical"));
        if (Input.GetAxis("Vertical") > 0 && forward.speed <= 1)
            forward.speed += 0.1f * Time.deltaTime;
        else if(Input.GetAxis("Vertical") == 0)
            forward.speed -= 0.5f * Time.deltaTime;
        Debug.Log(forward.speed);
        if (Input.GetKeyDown(KeyCode.Z))
            FindObjectOfType<audioManager>().Play("pedals");
        if (Input.GetKeyUp(KeyCode.Z))
            FindObjectOfType<audioManager>().Stop("pedals");
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime * Input.GetAxis("Horizontal"));
        rb.MoveRotation(rb.rotation * deltaRotation);
        ResetTensor();
    }

    void ResetTensor()
    {
        GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
    }
}
