using UnityEngine;
using UnityEngine.UI;

public class StoryScene : MonoBehaviour, INode
{
    // next scenes, max of 3
    public StoryScene[] nextScenes = new StoryScene[3];

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
