using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Net;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class Web : MonoBehaviour
{
    void Start()
    {

        //StartCoroutine(GetRequest("http://localhost:8080/unity-database/GetUsers.php"));
        //StartCoroutine(Login("ttestuser", "1234"));
         //StartCoroutine(RegisterUser("testuser5", "1234"));
        //StartCoroutine(OgretmenEkle("testuser3", "1234"));
    }

    public IEnumerator Login(string username , string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/unity-database/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "Giriþ Baþarýlý")
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
    IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/unity-database/RegisterUser.php", form))
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

    IEnumerator GetRequest(string uri)
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
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
    public IEnumerator OgretmenEkle(string HocaAdi, string HocaSifre)
    {
        WWWForm form = new WWWForm();
        form.AddField("HocaAdi", HocaAdi);
        form.AddField("HocaSifre", HocaSifre);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/unity-database/OgretmenEkle.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "Yeni öðretmen oluþturuldu")
                {
                    SceneManager.LoadScene(3);

                }
                else if (www.downloadHandler.text == "Bu isimde bir hoca zaten var")
                {
                    
                    YaziGorunum yazigorunum = GetComponent<YaziGorunum>();
                    Text uyari = yazigorunum.uyari;
                    uyari.text = "Bu isimde bir hoca zaten var";
                    uyari.color = Color.red;
                }

            }
        }
    }
    public IEnumerator DersEkle(string DersAdi)
    {
        WWWForm form = new WWWForm();
        form.AddField("DersAdi", DersAdi);
        


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/unity-database/DersEkle.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "Yeni ders oluþturuldu")
                {
                    SceneManager.LoadScene(4);
                }
                else if (www.downloadHandler.text == "Bu isimde bir ders zaten var")
                {

                    YaziGorunum yazigorunum = GetComponent<YaziGorunum>();
                    Text uyari = yazigorunum.uyari;
                    uyari.text = "Bu isimde bir ders zaten var";
                    uyari.color = Color.red;
                }
            }
        }
    }

    public IEnumerator SinifEkle(string SinifAdi)
    {
        WWWForm form = new WWWForm();
        form.AddField("SinifAdi", SinifAdi);



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/unity-database/SinifEkle.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "Yeni sýnýf oluþturuldu")
                {
                    SceneManager.LoadScene(5);
                }
                else if (www.downloadHandler.text == "Bu isimde bir sýnýf zaten var")
                {

                    YaziGorunum yazigorunum = GetComponent<YaziGorunum>();
                    Text uyari = yazigorunum.uyari;
                    uyari.text = "Bu isimde bir sýnýf zaten var";
                    uyari.color = Color.red;
                }
            }
        }
    }
}