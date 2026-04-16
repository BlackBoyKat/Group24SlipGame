using System.Collections; // This is for categorisation of collections or code - which in this case is the dialogue for Slip's girlfriend
using System.Collections.Generic; //Also used for categorisations
using UnityEngine;
using TMPro; // Used for TextMeshPro to code the dialogue

public class Dialogue_Manager : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // The text box
    public string[] lines; // personal note: alt ver (text) - hardcode the script instead of using inspector to input the dialogue (uses more coroutines)
    public float textSpeed; // Creates the typewriter effect
    private Coroutine typingRoutine; // This is used to stop the typewriter effect when the dialogue is finished
    private int index; // Paces/tracks the dialogue
    void Start()
    {
        index = 0;
        textComponent.text = string.Empty; // This makes the text box empty at the start of the scene

    }

    // Update is called once per frame
    void Update()
    {
        StartDialogue();
    }
    void StartDialogue()
    {
       if(typingRoutine == null) // Code is subject to change girl tf is going on with this
                                 // 
        {
            StopCoroutine(typingRoutine);
        }
        Debug.Log(index);
        Debug.Log(lines.Length);
        index ++;
        
        typingRoutine =StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() //this will individually type out each line/character of the dialogue
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            break;
        }
        typingRoutine = null;
    }
}
