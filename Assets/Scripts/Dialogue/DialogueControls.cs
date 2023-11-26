using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControls : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0f, 1.8f, 0f), transform.forward, out hit ,3f))
            {
                Dialogue dialogue = hit.collider.GetComponent<Dialogue>(); 
                
                if (dialogue != null)
                {
                      _dialogueManager.LoadDialogue(dialogue);
                }
            }      
        }
    }

    

}
