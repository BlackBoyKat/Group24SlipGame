using System.Collections; // This is for categorisation of collections or code - which in this case is the dialogue for Slip's girlfriend
using System.Collections.Generic; //Also used for categorisations
using UnityEngine;
using TMPro; // Used for TextMeshPro to code the dialogue

public class Dialogue_Manager : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // The text box
    public string[] lines;
    public float textSpeed; // Creates the typewriter effect

    private int index; // Paces/tracks the dialogue
    void Start()
    {
        textComponent.text = string.Empty; // This makes the text box empty at the start of the scene

    }

    // Update is called once per frame
    void Update()
    {
        StartDialogue();
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() //this will individually type out each line/character of the dialogue
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
