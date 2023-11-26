using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string nameOfCharacter;

    [SerializeField] private LineOfDialogue _firstLine;

    private LineOfDialogue _currentLine;

    public LineOfDialogue FirstLine()
    {
        return _firstLine;
    }
    
    public void Reset()
    {
        _currentLine = _firstLine;
    }

    public LineOfDialogue CurrentLine()
    {
        if(_currentLine == null) Reset();
        return _currentLine;
    }

    public LineOfDialogue NextLine(int id)
    {
        _currentLine = _currentLine.Responses[id].nextLine;
        return _currentLine;
    }
     
}
