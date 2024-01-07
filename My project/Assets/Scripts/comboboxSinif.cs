//Create a new Dropdown GameObject by going to the Hierarchy and clicking Create>UI>Dropdown. Attach this script to the Dropdown GameObject.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Example2 : MonoBehaviour
{
    //Create a List of new Dropdown options
    List<string> s_DropOptions = new List<string> { };
    //This is the Dropdown
    Dropdown s_Dropdown;

    void Start()
    {
        //Fetch the Dropdown GameObject the script is attached to
        s_Dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        s_Dropdown.ClearOptions();
        //Add the options created in the List above
        StartCoroutine(SinifListeCombo("http://localhost:8080/unity-database/SinifListe.php"));
        s_Dropdown.AddOptions(s_DropOptions);



    }


    IEnumerator SinifListeCombo(string uri)
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
                        s_DropOptions.Add(siniflar[i]);


                    }
                    s_Dropdown.AddOptions(s_DropOptions);
                    break;
            }
        }
    }
}