using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystem : MonoBehaviour
{
    [Header("L-System Properties")]
    string axiom = "F";                         // Initial char to start with
    string currentSentence;                     // Current sentence

    public GameObject[] roadPieces;             // GameObjects to use
    //Stack<SavedTransforms> savedTransforms;     // Stored Transforms
    Dictionary<char, string> rules;             // Axiom Rule set

    /// Rules for actual Road Pieces
    /// - Connect when close
    /// - Delete if within another's boundaries
    ///  - etc.

    /// String-To-Objects
    /// Switch Statement for each char in string
    /// Replace corresponding with Road Piece
    /// Rotate + Translate accordingly

}
