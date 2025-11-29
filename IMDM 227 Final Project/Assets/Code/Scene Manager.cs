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
        if (Mouse.current.leftButton.wasPressedThisFrame
             && Physics.Raycast(
                    Camera.main.ScreenPointToRay(
                        Mouse.current.position.ReadValue()),
        out RaycastHit hit))
        {
            MyButton button = hit.collider.gameObject.GetComponent<MyButton>();

            ButtonClicked(button);
        }
    }

    void ButtonClicked(MyButton button)
    {
        if(current.endReached)
        {
            if(button.choiceNum == 0)
            {
                Debug.Log("choice 1");
                SwitchScene(current.next1);
            } else
            {
                if(current.next2 != null)
                {
                    Debug.Log("choice 2");
                    SwitchScene(current.next2);
                }   
            }
        } 
        else
        {
            current.advanceDialogue();
        }
    }

    void SwitchScene(StoryScene scene)
    {
        // turn off current scene
        current.gameObject.SetActive(false);

        // set current scene to given scene
        current = scene;

        // set camera x,y to x,y of new scene
        Vector3 nextPos = scene.transform.position;
        Vector3 position = transform.position;
        position.x = nextPos.x;
        position.y = nextPos.y;
        transform.position = position;
    }
}
