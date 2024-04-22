using TMPro;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private MainGameManager _mainGameManager;
    [SerializeField] private TextMeshProUGUI _buttonAnswerText;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            _mainGameManager.ChooseAnswer(_buttonAnswerText.text);
            
        }
    }
}
