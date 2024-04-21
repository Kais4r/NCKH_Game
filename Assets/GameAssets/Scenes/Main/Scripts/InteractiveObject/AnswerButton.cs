using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private MainGameManager MainGameManager;
    [SerializeField] private string _answerButtonLetter;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            MainGameManager.ChooseAnswer(_answerButtonLetter);
        }

        //Debug.Log("object enter");
    }
}
