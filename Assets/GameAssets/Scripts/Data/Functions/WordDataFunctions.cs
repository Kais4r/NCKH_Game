using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordDataFunctions : MonoBehaviour
{
    List<EnglishWord> englishWords;
    public void ReadJsonData(string filePath)
    {
        string jsonData = File.ReadAllText(filePath);
        englishWords = JsonConvert.DeserializeObject<List<EnglishWord>>(jsonData);
    }

    private void Start()
    {
        Debug.Log(Application.streamingAssetsPath);
        string filePath = Application.streamingAssetsPath + "\\A1.json";
        ReadJsonData(filePath);
        Debug.Log(englishWords[0].WordName);
    }
}