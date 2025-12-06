using UnityEngine;


[CreateAssetMenu(fileName = "Dialogue Node", menuName = "Dialogue/New Node")]
public class DialogueNode: ScriptableObject, INode
{
    // add num choices
    public Character speaker;
    public DialogueNode[] choices = new DialogueNode[3];
    public string[] choicesText = new string[3];
    [TextArea(5, 10)]
    public string paragraph;
    public void chosen()
    {
        throw new System.NotImplementedException();
    }


}
