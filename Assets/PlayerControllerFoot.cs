using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFoot : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager2>().Play("Theme");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxis("Vertical")>0)
            transform.Translate(Vector3.left*Input.GetAxis("Vertical")*Time.deltaTime);

        //transform.Translate(Vector3.back * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Rotate(0, 1* Input.GetAxis("Horizontal")*2.5f, 0);
        animator.SetFloat("isWalking", Input.GetAxis("Vertical"));
        animator2.SetFloat("isWalking", Input.GetAxis("Vertical"));
        camera.transform.position = new Vector3(transform.position.x, 2.389f, 4.334f);
        camera.transform.rotation = new Quaternion(-1.04396458e-09f, 0.998176694f, -0.0603601597f, -1.72640551e-08f);
    }
}
