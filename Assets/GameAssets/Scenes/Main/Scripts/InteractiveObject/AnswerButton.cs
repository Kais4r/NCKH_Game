using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private MainGameManager _mainGameManager;
    [SerializeField] private TextMeshProUGUI _buttonAnswerText;
    Vector3 initialPos;
    Rigidbody rb;
    Renderer material;

    public List<Material> danhSachMau;
    private void Start()
    {
        initialPos = transform.position;
        rb = GetComponent<Rigidbody>();
        material = rb.GetComponent<Renderer>();
    }

    


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PlayerHand"))
        {
         

            if (_mainGameManager.gameState == GameState.ProcessAnswer)
            {
                
                    rb.AddForce(transform.forward * -4f);
                    StartCoroutine(enumerator(0.5f));
            }
            else 
            {
                _mainGameManager.ChooseAnswer(_buttonAnswerText.text);
                if (_mainGameManager.answerResult == true)
                {
                    material.material.color = Color.green;
                    StartCoroutine(enumerator(1f));
                }
                else
                {
                    material.material.color = Color.red;
                    StartCoroutine(enumerator(1f));
                }
            }
        }
        // doi mau xanh, do
        // Yield wait return 1f;
        // tra ve mau trang
        IEnumerator enumerator(float t)
        {
            yield return new WaitForSeconds(t);
            rb.velocity = Vector3.zero;
            ResetPos();
            material.material.color = Color.white;
        }
    }
    private void ResetPos()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPos;
    }

}
