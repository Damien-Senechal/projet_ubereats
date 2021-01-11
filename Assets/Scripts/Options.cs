using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void Sound()
    {
        if (name.Equals("Low"))
            DialogDisplay.dialogSpeed = 0.1f;
        else if (name.Equals("High"))
            DialogDisplay.dialogSpeed = 0.02f;
        else if (name.Equals("Medium"))
            DialogDisplay.dialogSpeed = 0.05f;
    }
}
