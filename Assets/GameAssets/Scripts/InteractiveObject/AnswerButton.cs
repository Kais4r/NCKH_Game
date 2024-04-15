using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private QuizManager _quizManager;
    [SerializeField] private string _answerButtonLetter;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            _quizManager.ChooseAnswer(_answerButtonLetter);
        }

        //Debug.Log("object enter");
    }
}
