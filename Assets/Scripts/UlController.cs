using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UlController : MonoBehaviour
{
    public static UlController instance;

    public Image heart, heart1, heart2;
    public Sprite heartFull, heartEmpty,heartHalf;
    public Text gemText;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGemCount();
    }
    public void  UpdateHealthDisplay()
    {
        switch (PlayerHealthController.instance.currentHealth)
        {
            case 6:
                heart.sprite = heartFull;
                heart1.sprite = heartFull;
                heart2.sprite = heartFull; //full
                break;

            case 5:
                heart.sprite = heartFull;
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf; // 1 nua
                break;
            case 4:
                heart.sprite = heartFull;
                heart1.sprite = heartFull; //full
                heart2.sprite = heartEmpty; // rong
                break;
            case 3:
                heart.sprite = heartFull;
                heart1.sprite = heartHalf; // 1 nua 
                heart2.sprite = heartEmpty;
                break;
            case 2:
                heart.sprite = heartFull; //full
                heart1.sprite = heartEmpty; // rong
                heart2.sprite = heartEmpty;
                break;
            case 1:
                heart.sprite = heartHalf; // 1 nua
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                break;
            case 0:           
                heart.sprite = heartEmpty; // rong
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                break;
            default:
                heart.sprite = heartEmpty;
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                break;
        }
    }
    public void UpdateGemCount()
    {
        gemText.text = LevelManager.instance.gemsCollected.ToString();
    }
}
