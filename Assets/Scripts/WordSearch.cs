using UnityEngine;
using System.Collections;
using System.IO;

public class WordSearch : MonoBehaviour
{

    public string userInput; // The string entered by the user

    void Start()
    {
        // Load the 'words' csv file
        string filePath = Application.dataPath + "/words.csv";
        string[] lines = File.ReadAllLines(filePath);

        // Loop through each line in the csv file
        foreach (string line in lines)
        {
            // Split the line into words using commas as delimiters
            string[] words = line.Split(',');

            // Loop through each word in the line
            foreach (string word in words)
            {
                // Check if the word matches the user input
                if (word == userInput)
                {
                    // If it matches, print a message to the console
                    Debug.Log("Found " + word + " in the 'words' csv file!");
                }
            }
        }
    }
}