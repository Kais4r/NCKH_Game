using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;

enum GameState
{
    Start,
    GenerateQuestion,
    PlayerChooseAnswer,
}

public class MainGameManager : MonoBehaviour
{
    // Other Managers
    [SerializeField] private MainUIManager _mainUIManager;

    // Data related
    [SerializeField] private DataFunctions _dataFunctions;
    private List<EnglishWord> _allEnglishWords;
    private List<EnglishWord> _thisLevelEnglishWords;
    private List<EnglishWord> _wordToGuessList;
    private List<EnglishWord> _guessedWords;
    private List<String> _answerButtonContent;

    private EnglishWord _wordToGuess;
    private string correctAnswer;


    // Game management
    private string _CEFRLevel; // this will be taken from singleton
    [SerializeField] private ListRange _levelWordRange;
    [SerializeField] private GameState _gameState;

    // UI Related

    private void Awake()
    {
        // Take in level and mode
        _CEFRLevel = "A1";

        // Load data from DataFunctions
        string data = _dataFunctions.ReadJsonData(_CEFRLevel + ".json");
        _allEnglishWords = _dataFunctions.ProcessJsonDataToEnglishWord(data);
        _thisLevelEnglishWords = _allEnglishWords.GetRange(_levelWordRange.startIndex,_levelWordRange.count);
        _wordToGuessList = _thisLevelEnglishWords.OrderBy(i => Guid.NewGuid()).ToList();
        _guessedWords = new List<EnglishWord>();
        _answerButtonContent = new List<String>();


        /*foreach (EnglishWord word in _thisLevelEnglishWords)
        {
            Debug.Log(word.WordName);
        }*/
        //Debug.Log(_englishWords[4].WordName);
    }

    void Start()
    {
        _gameState = GameState.Start;
        // Start generate question according to level and mode
        GenerateQuestion();
    }

    private void Update()
    {
        if (_gameState == GameState.GenerateQuestion)
        {
            GenerateQuestion();
        }
    }

    public void GenerateQuestion()
    {
        _gameState = GameState.GenerateQuestion;

        // TextOnlyQuiz
        if (_wordToGuessList.Count == 0)
        {
            _mainUIManager.quizContentText.text = "Không còn từ để đoán";
        }
        else
        {
            // Process question data
            _wordToGuess = _wordToGuessList[0];
            correctAnswer = _wordToGuess.VietMeaning;
            _guessedWords.Add(_wordToGuessList[0]);
            _wordToGuessList.RemoveAt(0);

            // Process question ui
            _mainUIManager.quizContentText.text = _wordToGuess.WordName + " là gì";

            // Process answer button data
            _answerButtonContent.Clear();
            _answerButtonContent.Add(_wordToGuess.VietMeaning);

            for (int i = 1; i < 4; i++)
            {
                int number = Random.Range(0, _thisLevelEnglishWords.Count);
                while (_answerButtonContent.Contains(_thisLevelEnglishWords[number].VietMeaning))
                {
                    number = Random.Range(0, _thisLevelEnglishWords.Count);
                }
                _answerButtonContent.Add(_thisLevelEnglishWords[number].VietMeaning);
            }
            _answerButtonContent = _answerButtonContent.OrderBy(i => Guid.NewGuid()).ToList();

            // Process answer button content ui
            for (int i = 0; i < 4; i++)
            {
                _mainUIManager.answerButtonsContent[i].text = _answerButtonContent[i];
            }

            _gameState = GameState.PlayerChooseAnswer;
        }
    }


    public void ChooseAnswer(string answer)
    {
        if(answer == correctAnswer)
        {
            Debug.Log("Correct");
            _gameState = GameState.GenerateQuestion;
        }
    }
}
