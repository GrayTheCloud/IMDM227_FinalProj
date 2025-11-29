using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    public StoryScene current;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if there was a click this frame that clicked on a gameobject
        if (Mouse.current.leftButton.wasPressedThisFrame
             && Physics.Raycast(
                    Camera.main.ScreenPointToRay(
                        Mouse.current.position.ReadValue()),
        out RaycastHit hit))
        {
            // try to get a button script from the clicked object
            MyButton button = hit.collider.gameObject.GetComponent<MyButton>();
            // try to get the IClickable Script from the clicked object
            IClickable clicky = hit.collider.gameObject.GetComponent<IClickable>();

            // if there is an IClickable Script run its click function
            clicky?.Click();

            // if there was a button click run the button clicked script
            if (button != null)
            {
                ButtonClicked(button);
            }


        }
    }

    /* 
     * Gets Scene button is attached to. 
     * if the scene has reached the end,
     * advances to the chosen scene, otherwise, 
     * advances to the chosen dialogue 
     */
    void ButtonClicked(MyButton button)
    {
        if (button.choiceNum == 0)
        {
            Debug.Log("choice 1");
            if (current.endReached) 
            {
                if(current.next1 != null)
                {
                    SwitchScene(current.next1);
                }
            } 
            else
            {
                current.advanceDialogue(button.choiceNum);
            }
            
        }
        else
        {
            Debug.Log("choice 2");
            if(current.endReached)
            {
                if(current.next2 != null)
                {
                    SwitchScene(current.next2);
                }
                
            } 
            else
            {
                current.advanceDialogue(button.choiceNum);
            }


        }
    }


    /* 
     * deactivates current scene,
     * moves camera to new scene
     * and activates new scene 
     */
    void SwitchScene(StoryScene scene)
    {
        // turn off current scene
        current.gameObject.SetActive(false);

        // set current scene to given scene
        current = scene;
        current.chosen();

        // set camera x,y to x,y of new scene
        Vector3 nextPos = scene.transform.position;
        Vector3 position = transform.position;
        position.x = nextPos.x;
        position.y = nextPos.y;
        transform.position = position;
    }
}
