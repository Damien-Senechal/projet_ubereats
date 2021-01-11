using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject dialog;
    public GameObject father;
    public GameObject player;
    public new GameObject camera;
    public GameObject startPlayer;
    public GameObject startFather;
    public GameObject score;

    public GameObject[] intro;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<audioManager>().Play("Corona");
        WaitStart(20);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void WaitStart(float temps)
    {
        StopAllCoroutines();
        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            intro[0].SetActive(true);
            yield return new WaitForSeconds(4);
            intro[1].SetActive(false);
            intro[2].SetActive(true);
            yield return new WaitForSeconds(4);
            intro[2].SetActive(false);
            intro[3].SetActive(true);
            yield return new WaitForSeconds(3.5f);
            intro[3].SetActive(false);
            intro[2].SetActive(true);
            yield return new WaitForSeconds(5);
            intro[2].SetActive(false);
            intro[4].SetActive(true);
            yield return new WaitForSeconds(6);
            intro[4].SetActive(false);
            intro[0].SetActive(false);
            dialog.gameObject.SetActive(false);
            father.gameObject.SetActive(false);
            player.gameObject.SetActive(false);
            startPlayer.gameObject.SetActive(true);
            startFather.gameObject.SetActive(true);
            camera.gameObject.SetActive(false);
            score.gameObject.SetActive(true);        
        }
    }
}
