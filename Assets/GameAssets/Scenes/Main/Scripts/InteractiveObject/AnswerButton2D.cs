using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerButton2D : MonoBehaviour
{
    [SerializeField] private MainGameManager _mainGameManager;
    [SerializeField] private TextMeshProUGUI _buttonAnswerText;

    public void ChooseAnswer2D()
    {
        if (_mainGameManager.gameState == GameState.PlayerChooseAnswer)
        {
            _mainGameManager.ChooseAnswer(_buttonAnswerText.text);
            /*if (_mainGameManager.answerResult == true)
            {
                material.material.color = Color.green;
                StartCoroutine(enumerator(1f));
            }
            else
            {
                material.material.color = Color.red;
                StartCoroutine(enumerator(1f));
            }
*/
        }
    }

    /*IEnumerator enumerator(float t)
    {
        yield return new WaitForSeconds(t);
        rb.velocity = Vector3.zero;
        ResetPos();
        material.material.color = Color.white;
    }*/
}
