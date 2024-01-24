using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour


{
    public Dropdown drpHoca;
    public Dropdown drpDers;
    public Dropdown drpSinif;
    public Dropdown drpGun;
    public Dropdown drpSaat;
    

    public Button EklemeButton;
    // Start is called before the first frame update
    void Start()
    {
         EklemeButton.onClick.AddListener(() =>
        {
            StartCoroutine(ProgramEkle(drpHoca.captionText.text, drpDers.captionText.text, drpSinif.captionText.text, drpGun.captionText.text, drpSaat.captionText.text));

        });
    }

    IEnumerator ProgramEkle(string Hoca, string Ders, string Sinif, string Gun, string Saat)
    {
        WWWForm form = new WWWForm();
        form.AddField("Hocaa", Hoca);
        form.AddField("Derss", Ders);
        form.AddField("Siniff", Sinif);
        form.AddField("Gunn", Gun);
        form.AddField("Saatt", Saat);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/unity-database/ProgramEkle.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                YaziGorunum yazigorunum = GetComponent<YaziGorunum>();
                Text uyari = yazigorunum.uyari;
                uyari.text = www.downloadHandler.text;
            }
        }
    }
}
