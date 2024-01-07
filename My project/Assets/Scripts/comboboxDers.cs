//Create a new Dropdown GameObject by going to the Hierarchy and clicking Create>UI>Dropdown. Attach this script to the Dropdown GameObject.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Example3 : MonoBehaviour
{
    //Create a List of new Dropdown options
    List<string> d_DropOptions = new List<string> { };
    //This is the Dropdown
    Dropdown d_Dropdown;

    void Start()
    {
        //Fetch the Dropdown GameObject the script is attached to
        d_Dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        d_Dropdown.ClearOptions();
        //Add the options created in the List above
        StartCoroutine(DersListeCombo("http://localhost:8080/unity-database/DersListe.php"));
        d_Dropdown.AddOptions(d_DropOptions);



    }


    IEnumerator DersListeCombo(string uri)
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

                    for (int i = 0; i < dersler.Length - 1; i++)
                    {
                        Debug.Log(dersler[i]);
                        d_DropOptions.Add(dersler[i]);


                    }
                    d_Dropdown.AddOptions(d_DropOptions);
                    break;
            }
        }
    }
}