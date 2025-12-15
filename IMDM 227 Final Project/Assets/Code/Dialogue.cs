using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName = "Scene Diaglogue", menuName = "Dialogue/New Scene")]
public class Dialogue: ScriptableObject
{
    public DialogueNode start;

    public DialogueNode curr;

    public void next(int i)
    {
        if (curr.numChoices == 0)
        {
            Debug.Log("End of scene reached");
            curr = null;
        }
        else
        {
            Debug.Log("Moving to next node " + i);
            curr = curr.choices[i];
        }
        
    }
}
