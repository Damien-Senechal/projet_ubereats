using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriggerCommode : MonoBehaviour
{
    public Animator animator;
    public GameObject pyjama;
    public GameObject habille;

    private bool seChange = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space) && seChange)
        {
            animator.SetBool("seChanger", true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager2>().Play("Cloth");
        yield return new WaitForSeconds(1.6f);
        pyjama.gameObject.SetActive(false);
        habille.gameObject.SetActive(true);
        FindObjectOfType<AudioManager2>().Play("Zip");
        yield return new WaitForSeconds(0.6f);
        seChange = false;
        animator.SetBool("seChanger", false);
    }
}
