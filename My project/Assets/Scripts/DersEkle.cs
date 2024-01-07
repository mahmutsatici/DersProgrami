using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DersEkle : MonoBehaviour
{
    public InputField DersAdInput;
    
    public Button KayitButton;

    void Start()
    {
        KayitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.DersEkle(DersAdInput.text));
        });
    }
}
