using Unity.VisualScripting;
using UnityEngine;

public class MyButton : MonoBehaviour, IClickable
{
    public int choiceNum;
    public void Click()
    {
        Debug.Log("I am a button and I've been clicked");
    }

}
