using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeOptionInGame : MonoBehaviour
{
    public GameObject am;

    public void Volume(float volume)
    {
        am.gameObject.SetActive(false);
        audioManager.volume = volume;
        am.gameObject.SetActive(true);
    }
}
