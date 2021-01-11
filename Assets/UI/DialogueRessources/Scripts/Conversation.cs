using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public Characters character;

    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Conversation", menuName ="Conversation")]
public class Conversation : ScriptableObject
{
    public Characters speakerLeft;
    public Characters speakerRight;
    public Line[] lines;
}
