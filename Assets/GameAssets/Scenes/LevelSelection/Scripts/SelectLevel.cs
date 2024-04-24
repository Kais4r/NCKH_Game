using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    private GameManagerSingleton _gameManagerSingleton;
    private void Awake()
    {
        _gameManagerSingleton = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSingleton>();
    }
    public void SelectCERFLevel(string level)
    {
        _gameManagerSingleton.cefrLevel = level;
    }
}