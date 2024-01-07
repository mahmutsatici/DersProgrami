using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OgretmenListele : MonoBehaviour
{
    public GameObject ogretmenListelemeAlaný;
    public GameObject ogretmenListelemeSablonu;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OgretmenListe("http://localhost:8080/unity-database/OgretmenListe.php"));
        
    }

    IEnumerator OgretmenListe(string uri)
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

                    string[] ogretmenler = safyanit.Split("*");

                    for (int i = 0; i < ogretmenler.Length - 1; i++)
                    {
                        Debug.Log(ogretmenler[i]);
                        GameObject gobj = (GameObject)Instantiate(ogretmenListelemeSablonu);
                        gobj.transform.SetParent(ogretmenListelemeAlaný.transform);
                        gobj.GetComponent<OgretmenListeleEk>().ogretmenAdi.text = ogretmenler[i];
                        gobj.GetComponent<OgretmenListeleEk>().SilButton.onClick.AddListener(() =>
                        {
                            Debug.Log(gobj.GetComponent<OgretmenListeleEk>().ogretmenAdi.text);
                            StartCoroutine(HocaSil(gobj.GetComponent<OgretmenListeleEk>().ogretmenAdi.text));
                            SceneManager.LoadScene(3);

                        });
                    }
                    
                    
                    break;

            }
        }         
    }
    IEnumerator HocaSil(string silinecekHocaa)
    {
        WWWForm form = new WWWForm();
        form.AddField("silinecekHoca", silinecekHocaa);



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/unity-database/OgretmenSilme.php", form))
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
