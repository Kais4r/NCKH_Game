using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataFunctions : MonoBehaviour
{
    List<EnglishWord> englishWords;
    string filePath = Application.streamingAssetsPath + "\\";

    //==================== data reading functions
    public string ReadJsonData(string fileName)
    {
        string jsonData = File.ReadAllText(filePath + fileName);
        return jsonData;
    }

    //==================== data process or convert functions
    public List<EnglishWord> ProcessJsonDataToEnglishWord(string jsonData)
    {
        List<EnglishWord> englishWords = JsonConvert.DeserializeObject<List<EnglishWord>>(jsonData);
        return englishWords;
    }

    //==================== game data related function
    /*public List<EnglishWord> GenerateEnglishWordsList(List<EnglishWord> wordsList)
    {

    }*/
}