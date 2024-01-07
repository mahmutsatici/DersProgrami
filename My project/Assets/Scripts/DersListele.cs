using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DersListele : MonoBehaviour
{
    public GameObject dersListelemeAlaný;
    public GameObject dersListelemeSablonu;
    void Start()
    {
        StartCoroutine(DersListe("http://localhost:8080/unity-database/DersListe.php"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DersListe(string uri)
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

                    string[] dersler = safyanit.Split("*");

                    for (int i = 0; i < dersler.Length-1; i++)
                    {
                        Debug.Log(dersler[i]);
                        GameObject gobj = (GameObject)Instantiate(dersListelemeSablonu);
                        gobj.transform.SetParent(dersListelemeAlaný.transform);
                        gobj.GetComponent<DersListeleEk>().dersAdi.text = dersler[i];
                        gobj.GetComponent<DersListeleEk>().SilButton.onClick.AddListener(() =>
                        {
                            Debug.Log(gobj.GetComponent<DersListeleEk>().dersAdi.text);
                            StartCoroutine(DersSil(gobj.GetComponent<DersListeleEk>().dersAdi.text));
                            SceneManager.LoadScene(4);

                        });
                    }

                    break;
            }
        }

    }
    IEnumerator DersSil(string silinecekDerss)
    {
        WWWForm form = new WWWForm();
        form.AddField("silinecekDers", silinecekDerss);



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/unity-database/DersSilme.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
