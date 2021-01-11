using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public static int point = 0;
    public GameObject player;
    private float max = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        score.text = "Score : " + point;
    }

    // Update is called once per frame
    void Update()
    {
        if (max <= player.transform.rotation.x)
            max = player.transform.rotation.x;
        Debug.Log(max);
        if (player.transform.rotation.x >= 0.9999)
            point += 100;
        if (player.transform.rotation.x <= -0.9999)
            point += 100;
        score.text = "Score : " + point;
    }
}
