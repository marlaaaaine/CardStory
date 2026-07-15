using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Ties the character's name to their dialogue </summary>
[Serializable]
public struct CharacterDialogue
{
    /// <summary> Create a CharacterDialogue with the given name and dialogue </summary>
    /// <param name="name"> string representing character's name </param>
    /// <param name="dialogue"> string representing character's dialogue </param>
    public CharacterDialogue(string name, string dialogue)
    {
        Name = name;
        Dialogue = dialogue;
    }
    // character name
    public string Name;
    // what this character will say
    [TextArea] public string Dialogue;
}

/// <summary> Object for holding a character's dialogue </summary>
[CreateAssetMenu(fileName = "DialogueObject", menuName = "Scriptable Objects/Create CutsceneScript")]
public class CutsceneScriptObj : ScriptableObject
{

    /// <summary> 
    /// List containing all the character dialogues in this script 
    /// - makes it so that I can enter pairs of CharacterDialogues in editor 
    /// since a queue isn't serializable 
    /// </summary>
    [SerializeField] private List<CharacterDialogue> _dialogueList = new();

    /// <summary>
    /// Holds all the dialogues to make up a cutscene's script
    /// - using a queue so that dialogues go one after the other (FIFO)
    /// </summary>
    public Queue<CharacterDialogue> CutsceneScript;

    /// <summary>
    /// Combines the Names & Dialogues from the _dialogueList
    ///  into a queue of CharacterDialogue objs to create a script 
    /// </summary>
    /// <returns>a queue of type CharacterDialogue making up a script</returns>
    public Queue<CharacterDialogue> TranslateToQueue()
    {
        Queue<CharacterDialogue> result = new();
        foreach (CharacterDialogue characterDialogue in _dialogueList)
        {
            CutsceneScript.Enqueue(characterDialogue);
        }
        return result;
    }
}
