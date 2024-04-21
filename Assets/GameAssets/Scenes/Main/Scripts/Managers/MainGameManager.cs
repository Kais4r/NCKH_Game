using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

enum GameState
{
    Start,
}

public class MainGameManager : MonoBehaviour
{
    // Data related
    [SerializeField] private DataFunctions _dataFunctions;
    private List<EnglishWord> _englishWords;
    private List<EnglishWord> _wordsToGuess;

    // Game management
    private string _CEFRLevel; // this will be taken from singleton
    [SerializeField] private ListRange _levelWordRange;
    private GameState _gameState;

    // UI Related
    [SerializeField] private TextMeshProUGUI testAnswerText;

    private void Awake()
    {
        // Take in level and mode
        _CEFRLevel = "A1";

        // Load data from DataFunctions
        string data = _dataFunctions.ReadJsonData(_CEFRLevel + ".json");
        _englishWords = _dataFunctions.ProcessJsonDataToEnglishWord(data);
        _wordsToGuess = _englishWords.GetRange(_levelWordRange.startIndex,_levelWordRange.count);

        foreach (EnglishWord word in _wordsToGuess)
        {
            Debug.Log(word.WordName);
        }
        //Debug.Log(_englishWords[4].WordName);
    }

    void Start()
    {
        _gameState = GameState.Start;
        // Start generate question according to level and mode

    }

    public void ChooseAnswer(string OptionsLetter)
    {
        testAnswerText.text = "Player choose " + OptionsLetter;
    }
}
