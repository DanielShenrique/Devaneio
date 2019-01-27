using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Alerta : MonoBehaviour {

    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters;
    public float CharacterRateMultiplier;

    public KeyCode DialogueInput = KeyCode.Z;

    public bool Foi;

    public GameObject Texto;

    private bool _isDialoguePlaying = false;

    //public GameObject proximoPainel;
    // Use this for initialization
    void Start()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";
        Foi = false;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Foi == true)
        {
            if (!_isDialoguePlaying)
            {
                _isDialoguePlaying = true;
                StartCoroutine(StartDialogue());
            }
        }
    }
    private IEnumerator StartDialogue()
    {
        int dialogueLength = DialogueStrings.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength)
        {
            yield return StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex]));
            currentDialogueIndex++;
        }
        _isDialoguePlaying = false;
    }
    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;
            if (currentCharacterIndex < stringLength)
            {
				///yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultiplier);
				
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultiplier);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
            else
            {
                break;
            }
        }
        while (true)
        {
             if (Input.GetKeyDown(DialogueInput))
            {
                Texto.SetActive(false);
            }    
            yield return 0;
        }
        _textComponent.text = "";
    }
}
