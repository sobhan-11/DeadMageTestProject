using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuCard : MonoBehaviour
{
    public GameObject selectedImage;
    public Button button;
    public TMP_Text titleText;

    public Color selectColor;

    public void OnSelect()
    {
        selectedImage.SetActive(true);
        titleText.color = selectColor;
    }   
    
    public void OnDeSelect()
    {
        selectedImage.SetActive(false);
        titleText.color = Color.white;
    }
}
