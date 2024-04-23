using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private MainGameManager _mainGameManager;
    [SerializeField] private TextMeshProUGUI _buttonAnswerText;
    public List<Material> danhSachMau;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            if (_mainGameManager.gameState == GameState.ProcessAnswer)
            {

            }
            else
            {
                _mainGameManager.ChooseAnswer(_buttonAnswerText.text);
                if (_mainGameManager.answerResult == true)
                {
                    //Doi mau xanh
                    //StartCourutine
                }
                else
                {
                    //Doi mau do
                    //StartCourutine
                }
            }
        }
        // doi mau xanh, do
        // Yield wait return 1f;
        // tra ve mau trang
    }
}
