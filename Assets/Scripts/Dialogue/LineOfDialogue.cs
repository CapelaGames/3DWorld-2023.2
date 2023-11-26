using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Line", menuName = "Dialogue/Line Of Dialogue")]
public class LineOfDialogue : ScriptableObject
{
    [TextArea(3,10)]
    public string Statement;

    public Response[] Responses;
}
