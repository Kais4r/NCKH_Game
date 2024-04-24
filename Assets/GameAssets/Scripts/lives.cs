using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class lives : MonoBehaviour
{
    public Sprite[] sprites; 
    private Image image;
    private int currentSpriteIndex = 0;

    void Start()
    {
        image = GetComponent<Image>();
        if (sprites.Length > 0)
        {
            image.sprite = sprites[currentSpriteIndex];
        }

        StartCoroutine(changesprite());
    }

    void Update()
    {
        /*for (int i = 0; i < 100; i++)
        {
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
            changesprite(1f);
            image.sprite = sprites[currentSpriteIndex];
        }*/



    }
    IEnumerator changesprite()
    {
        while(true)
        {
            image.sprite = sprites[0];
            yield return new WaitForSeconds(1f);
            image.sprite = sprites[1];
            yield return new WaitForSeconds(1f);
            image.sprite = sprites[2];
            yield return new WaitForSeconds(1f);
            image.sprite = sprites[3];
            yield return new WaitForSeconds(1f);
            image.sprite = sprites[4];
            yield return new WaitForSeconds(1f);
            image.sprite = sprites[5];
            yield return new WaitForSeconds(1f);
        }    
    }
}
