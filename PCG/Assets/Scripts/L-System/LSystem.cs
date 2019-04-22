using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystem : MonoBehaviour
{
    [Header("L-System Properties")]
    public int generations = 1;                         // Number of L-System generations
    public string axiom = "F";                                 // Initial char to start with
    public string ruleOne = "FFI";
    public string ruleTwo = "[+FFI+FFI--FFI][-FFI-FFI++FFI]";
    string currentSentence;                             // Current sentence
    public Terrain terrain;                             // Terrain to check

    public GameObject[] roadPieces;                                                   // GameObjects to use
    private Stack<SavedTransforms> savedTransforms = new Stack<SavedTransforms>();    // Stored Transforms
    private Dictionary<char, string> rules = new Dictionary<char, string>();          // Axiom Rule set

    private void Start()
    {
        // Set current Sentence
        currentSentence = axiom;

        // Add Rules
        rules.Add('F', ruleOne);                        // Forward roads + Intersection
        rules.Add('I', ruleTwo);                        // Add Intersection + Forward roads

        // Generate Roads
        Generate();
        Build();
    }

    // Generates L-System
    private void Generate()
    {
        // Generation Iterations
        for (int i = 0; i < generations; i++)
        {
            // Get Sentence
            string nextSentence = "";
            char[] lettersToRead = currentSentence.ToCharArray();

            // Apply rules
            for (int j = 0; j < lettersToRead.Length; j++)
            {
                char currentChar = lettersToRead[j];

                if (rules.ContainsKey(currentChar))
                    nextSentence += rules[currentChar];
                else
                    nextSentence += currentChar.ToString();
            }

            // Apply
            currentSentence = nextSentence;
            
            //Debug.Log(nextSentence);
        }

    }

    // Checks Road Piece position relative to Terrain area
    private bool IsWithinTerrain(GameObject roadPiece)
    {
        Vector3 piecePos = roadPiece.transform.position;

        if (piecePos.x > terrain.GetPosition().x + terrain.terrainData.size.x || piecePos.x < terrain.GetPosition().x)
            return false;
        if (piecePos.z > terrain.GetPosition().z + terrain.terrainData.size.z || piecePos.z < terrain.GetPosition().z)
            return false;

            return true;
    }

    // Build the generated L-System
    private void Build()
    {
        char[] sentence = currentSentence.ToCharArray();

        foreach (char item in sentence)
        {
            // Per iteration variables
            float boundSize = 0;
            GameObject road = null;

            // Apply actions based on current string
            switch (item)
            {
                case 'F':

                    boundSize = roadPieces[0].GetComponent<MeshRenderer>().bounds.size.z;
                    this.transform.Translate(Vector3.forward * boundSize);

                    road = roadPieces[0];

                    break;
                case 'I':
                    boundSize = roadPieces[1].GetComponent<MeshRenderer>().bounds.size.x;
                    this.transform.Translate(Vector3.forward * boundSize);

                    road = roadPieces[1];

                    break;
                case '+':
                    this.transform.Rotate(Vector3.up * 90.0f);

                    break;
                case '-':
                    this.transform.Rotate(Vector3.up * -90.0f);

                    break;
                case '[':
                    SavedTransforms currentTransform = new SavedTransforms
                    {
                        position = this.transform.position,
                        rotation = this.transform.rotation
                    };

                    savedTransforms.Push(currentTransform);

                    break;
                case ']':
                    SavedTransforms nextTransform = savedTransforms.Pop();

                    this.transform.position = nextTransform.position;
                    this.transform.rotation = nextTransform.rotation;

                    break;
            }

            // If road exsists...
            if (road)
            {
                road = Instantiate(road, this.transform.position, this.transform.rotation);

                // Destroy road piece if it's outside Terrain
                if (!IsWithinTerrain(road))
                    Destroy(road);
            }
        }
    }
}
