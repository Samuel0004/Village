using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea(1, 2)]
    public string[] sentences;
    public Sprite[] sprites;
    public Sprite[] dialogueWindows;
 }
