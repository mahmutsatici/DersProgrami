using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OgretmenEkle : MonoBehaviour
{
    public InputField HocaAdInput;
    public InputField HocaSifreInput;
    public Button KayitButton;

    void Start()
    {
        KayitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.OgretmenEkle(HocaAdInput.text, HocaSifreInput.text));
        });
    }
}
