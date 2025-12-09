using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class StoryScene : MonoBehaviour, INode
{
    // number of scenes this scene leads to
    public int numChoices;
    // next scenes, max of 3
    public StoryScene[] nextScenes = new StoryScene[3];

    // plane that has the speaking character
    public GameObject characterImg;

    // the three buttons and the text for them at the end of the scene
    public MyButton[] buttons  = new MyButton[3];
    public string[] choicesText = new string[3];
    // are we at the end of the scene
    public bool endReached = false;

    //linked list of dialogue for the scene
    public Dialogue exchange = null;

    // speed text should be typed at
    [SerializeField] private int typeSpeed;
    // textbox for displaying main text
    [SerializeField] private TextMeshProUGUI textMeshPro;


    // this method is called when the scene is chosen
    public void chosen()
    {
        gameObject.SetActive(true);
        Debug.Log("I was chosen :)");
        
        // if there is an exchange
        // every scene should have an exchange but good check for debugging
        if(exchange != null)
        {
            // setting the head of the dialogue graph
            exchange.curr = exchange.start;
            Debug.Log(exchange.curr.numChoices);
            // setting the main text to the first main text
            textMeshPro.text = exchange.curr.paragraph;
            // if there is only one node in the graph the end has been reached
            endReached = exchange.curr.numChoices == 0;
        }

        
        if (endReached)
        {
            EndReached();
        }
        
    }



    // advances to the selected node of dialogue in the text
    public void advanceDialogue(int choiceNum)
    {
        // if the button clicked is a valid choice
        if (choiceNum < exchange.curr.numChoices || exchange.curr.numChoices == 0) { 
            // deactivating every button
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].text.text = "";
                buttons[i].gameObject.SetActive(false);
            }
            // advancing to the next node of dialogue
            exchange.next(choiceNum);
            // if the next node isn't null 
            if (exchange.curr != null)
            {
                // set textbox text to paragraph of the current node
                textMeshPro.text = exchange.curr.paragraph;
                // activate one button per dialogue choice and add text to button
                int numChoices = exchange.curr.numChoices;
                for (int i = 0; i < numChoices; i++)
                {
                    buttons[i].gameObject.SetActive(true);
                    buttons[i].text.text = exchange.curr.choicesText[i];
                }

                Debug.Log(exchange.curr.numChoices);
                // if there are no more reachable nodes run the end of the scene has been reached
                if(exchange.curr.numChoices == 0)
                {
                    endReached = true;
                    EndReached();
                }

            }
        }
    }

    public void EndReached()
    {
        Debug.Log("running end reached");
        // set the buttons to go to the end of the scene
        for (int i = 0; i < numChoices; i++)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].text.text = choicesText[i];
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chosen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
