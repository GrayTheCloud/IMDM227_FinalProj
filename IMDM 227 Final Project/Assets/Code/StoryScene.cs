using UnityEngine;
using UnityEngine.UI;

public class StoryScene : MonoBehaviour, INode
{
    public StoryScene next1;
    public StoryScene next2;

    public MyButton button1;
    public MyButton button2;

    public bool endReached = false;

    public void chosen()
    {
        gameObject.SetActive(true);
    }


    public void advanceDialogue()
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
