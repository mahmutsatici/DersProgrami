using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinifEkle : MonoBehaviour
{
    public InputField SinifAdInput;

    public Button KayitButton;

    void Start()
    {
        KayitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.SinifEkle(SinifAdInput.text));
        });
    }
}
