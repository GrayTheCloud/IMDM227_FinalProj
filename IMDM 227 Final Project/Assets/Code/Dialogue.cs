using UnityEngine;

[CreateAssetMenu (fileName = "Scene Diaglogue", menuName = "Dialogue/New Scene")]
public class Dialogue: ScriptableObject
{
    public DialogueNode curr;
    
    public void next(int i)
    {
        curr = curr.choices[i];
    }
}
