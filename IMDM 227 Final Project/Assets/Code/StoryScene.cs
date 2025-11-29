using UnityEngine;
using UnityEngine.UI;

public class StoryScene : MonoBehaviour, INode
{
    // the next two scenes
    public StoryScene next1;
    public StoryScene next2;


    // the two buttons
    public MyButton button1;
    public MyButton button2;

    // are we at the end of the scene
    public bool endReached = false;

    public void chosen()
    {
        gameObject.SetActive(true);
    }


    // this is a placeholder since i havent made the dialogue system yet
    public void advanceDialogue(int choiceNum)
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
