using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class StoryScene : MonoBehaviour, INode
{
    // add num choices
    // next scenes, max of 3
    public StoryScene[] nextScenes = new StoryScene[3];

    // the three buttons
    public MyButton[] buttons  = new MyButton[3];

    // are we at the end of the scene
    public bool endReached = false;

    public Dialogue exchange;

    [SerializeField] private TextMeshProUGUI textMeshPro;

    public void chosen()
    {
        gameObject.SetActive(true);
    }


    // this is a placeholder since i havent made the dialogue system yet
    public void advanceDialogue(int choiceNum)
    {
        exchange.next(choiceNum);
        if (exchange.curr)
        {
            textMeshPro.text = exchange.curr.paragraph;
            int numChoices = exchange.curr.choices.Length;
            for(int i = 0; i < numChoices; i++)
            {
                buttons[i].gameObject.SetActive(true);
            }
            
        }
        else
        {
            endReached = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshPro.text = exchange.curr.paragraph;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
