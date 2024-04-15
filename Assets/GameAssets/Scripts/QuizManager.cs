using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI testAnswerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseAnswer(string OptionsLetter)
    {
        testAnswerText.text = "Player choose " + OptionsLetter;
    }
}
