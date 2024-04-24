using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public enum GameState
{
    Start,
    GenerateQuestion,
    PlayerChooseAnswer,
    ProcessAnswer,
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


    // Audio related
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip correctSound;

    [SerializeField]
    private AudioClip incorrectSound;


    // Game management
    private string _CEFRLevel; // this will be taken from singleton
    [SerializeField] private ListRange _levelWordRange;
    public GameState gameState;
    private int _score = 0;
    private int _playerHP = 2;
    public bool answerResult;

    // UI Related
    [SerializeField] private List<GameObject> _quizTypePanels;

    private void Awake()
    {
        // Take in level and mode
        if(GameManagerSingleton.instance != null)
        {
            _CEFRLevel = GameManagerSingleton.instance.cefrLevel;
        }
        else
        {
            // Assign level
            _CEFRLevel = "A1";
        }

        // Load data from DataFunctions
        string data = _dataFunctions.ReadJsonData(_CEFRLevel + ".json");
        _allEnglishWords = _dataFunctions.ProcessJsonDataToEnglishWord(data);
        _thisLevelEnglishWords = _allEnglishWords.GetRange(_levelWordRange.startIndex,_levelWordRange.count);
        _wordToGuessList = _thisLevelEnglishWords.OrderBy(i => Guid.NewGuid()).ToList();
        _guessedWords = new List<EnglishWord>();
        _answerButtonContent = new List<String>();

        // Setting up UI
        _mainUIManager.playerHP.text = _playerHP.ToString();


        /*foreach (EnglishWord word in _thisLevelEnglishWords)
        {
            Debug.Log(word.WordName);
        }*/
        //Debug.Log(_englishWords[4].WordName);
    }

    private void Start()
    {
        gameState = GameState.Start;
        // Start generate question according to level and mode
        GenerateQuestion();
    }

    private void Update()
    {
        if (gameState == GameState.GenerateQuestion)
        {
            GenerateQuestion();
        }
    }

    public void StartingTheGame()
    {
        gameState = GameState.Start;
        // Start generate question according to level and mode
        GenerateQuestion();
    }
    public void GenerateQuestion()
    {
        CreateTextOnlyQuiz();
        gameState = GameState.PlayerChooseAnswer;
    }

    public void CreateTextOnlyQuiz()
    {
        _quizTypePanels[0].SetActive(true);
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
        }
    }

    public void ChooseAnswer(string answer)
    {
        if (answer == correctAnswer && gameState == GameState.PlayerChooseAnswer)
        {
            //play sound correct
            AudioManager.Instance.PlaySound(audioSource, correctSound);
            StartCoroutine(ProcessAnswer(true));
        }
        else if (answer != correctAnswer && gameState == GameState.PlayerChooseAnswer)
        {
            //play sound wrong
            AudioManager.Instance.PlaySound(audioSource, incorrectSound);

            _playerHP--;
            if(_playerHP <= 0)
            {
                SceneManager.LoadScene("LevelSelection");
            }
            _mainUIManager.playerHP.text = _playerHP.ToString();
            StartCoroutine(ProcessAnswer(false));
        }
    }
    IEnumerator ProcessAnswer(bool result)
    {
        gameState = GameState.ProcessAnswer;
        if (result == true)
        {
            _score += 1;
            _mainUIManager.playerScore.text = "Diem so: " + _score.ToString();
            answerResult = true;
            //change color of 2d button to Green

        }
        else
        {
            answerResult = false;
            //change color of 2d button to Red
        }

        yield return new WaitForSeconds(1f);
        gameState = GameState.GenerateQuestion;
    }
}
