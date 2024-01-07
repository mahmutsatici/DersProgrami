using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SinifListele : MonoBehaviour
{
    public GameObject sinifListelemeAlaný;
    public GameObject sinifListelemeSablonu;
    void Start()
    {
        StartCoroutine(SinifListe("http://localhost:8080/unity-database/SinifListe.php"));
    }

    IEnumerator SinifListe(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    // Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    string safyanit = webRequest.downloadHandler.text;

                    string[] siniflar = safyanit.Split("*");

                    for (int i = 0; i < siniflar.Length - 1; i++)
                    {
                        Debug.Log(siniflar[i]);
                        GameObject gobj = (GameObject)Instantiate(sinifListelemeSablonu);
                        gobj.transform.SetParent(sinifListelemeAlaný.transform);
                        gobj.GetComponent<SinifListeleEk>().sinifAdi.text = siniflar[i];
                    }

                    break;
            }
        }
    }
}
