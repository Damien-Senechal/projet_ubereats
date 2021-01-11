using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public WheelCollider wc;
    public float torque = 200;
    public GameObject wheel;
    //public UnityEngine.Animations.Rigging.TwoBoneIKConstraint up;
    //public UnityEngine.Animations.Rigging.TwoBoneIKConstraint front;

    // Start is called before the first frame update
    void Start()
    {
        wc = GetComponent<WheelCollider>();
    }

    void Go(float accel)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        float thrustTorque = accel * torque;
        wc.motorTorque = thrustTorque;
        Vector3 position;
        Quaternion quat;
        wc.GetWorldPose(out position, out quat);
        //wheel.transform.position = position;
        quat.eulerAngles = new Vector3(quat.eulerAngles.x, quat.eulerAngles.y, quat.eulerAngles.z + 90);
        wheel.transform.rotation = quat;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float a = Input.GetAxis("Vertical");
        /*up.weight = a;
        if (up.weight == 1)
        {
            while(front.weight <= 1)
                front.weight += 0.1f;
        }*/
        Go(a);
    }
}
