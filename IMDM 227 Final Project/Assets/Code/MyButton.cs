using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MyButton : MonoBehaviour, IClickable
{
    public TextMeshProUGUI text;
    public int choiceNum;

    public void Click()
    {
        Debug.Log("I am a button and I've been clicked");

        
    }

}
