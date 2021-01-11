using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeOption : MonoBehaviour
{
    private void Start()
    {
        audioManager.volume = 1;
    }
    public void Volume(float volume)
    {
        audioManager.volume = volume;
    }
}
