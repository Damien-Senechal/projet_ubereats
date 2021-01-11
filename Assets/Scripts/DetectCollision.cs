using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject end;
    public GameObject gameover;
    Vector3 startPos;
    Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition; // or localPosition, depends to the use you make in the scene
        startRot = transform.localRotation;
    }

    // Update is called once per frame
    private void LateUpdate()                       
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("End"))
            end.gameObject.SetActive(true);
        if (other.gameObject.name.Equals("GameOver"))
            gameover.gameObject.SetActive(true);
        if (other.gameObject.name.Equals("MoveRotationC2lamerde"))
        {
            ResetTensor();
        }
        if (other.gameObject.name.Equals("MoveRotationC2lamerde2"))
        {
            ResetTensor();
        }
    }

    void ResetTensor()
    {
        GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
    }
}
