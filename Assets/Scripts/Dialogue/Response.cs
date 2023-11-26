using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Response", menuName = "Dialogue/Response")]
public class Response : ScriptableObject
{
    [NonSerialized] public int buttonID;
    public string statement;
    public LineOfDialogue nextLine;

    //[SerializeField] private string example;
}
