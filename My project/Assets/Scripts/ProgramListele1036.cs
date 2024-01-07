using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ProgramListele1036 : MonoBehaviour
{
    public GameObject programListelemeAlaný;
    public GameObject programListelemeSablonu;
    public GameObject gunListelemeSablonu;
    int pazartesisayac = 0;
    int salisayac = 0;
    int carsambasayac = 0;
    int persembesayac = 0;
    int cumasayac = 0;
    void Start()
    {
        StartCoroutine(ProgramListe("http://localhost:8080/unity-database/ProgramListele.php"));
    }

    IEnumerator ProgramListe(string uri)
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

                    string[] dersler = safyanit.Split('+');

                    for (int i = 0; i < dersler.Length - 1; i++)
                    {

                        string[] detaylar = dersler[i].Split('|');
                        string[] dersBilgileri = detaylar[0].Split('*');
                        string[] hocaBilgileri = dersBilgileri[1].Split(',');
                        string dersAdi = dersBilgileri[0];
                        string hocaAdi = hocaBilgileri[0];
                        string sinif = hocaBilgileri[1];
                        string gunSaat = detaylar[1];
                        string[] gunSaatBilgileri = gunSaat.Split('/');
                        string gun = gunSaatBilgileri[0];
                        string saat = gunSaatBilgileri[1];

                        if (gun == "Pazartesi" & sinif == "1036")
                        {

                            if (pazartesisayac == 0)
                            {
                                pazartesisayac = 1;

                                GameObject gobj3 = (GameObject)Instantiate(gunListelemeSablonu);
                                gobj3.transform.SetParent(programListelemeAlaný.transform);
                                gobj3.GetComponent<PrefabGun>().GunText.text = gun;
                            }
                            GameObject gobj4 = (GameObject)Instantiate(programListelemeSablonu);

                            gobj4.transform.SetParent(programListelemeAlaný.transform);

                            gobj4.GetComponent<ProgramListeleEk>().Hoca.text = hocaAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Ders.text = dersAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Saat.text = saat;
                            gobj4.GetComponent<ProgramListeleEk>().SilButton.onClick.AddListener(() =>
                            {

                                StartCoroutine(ProgramSil(hocaAdi, dersAdi, sinif, saat, gun));
                                SceneManager.LoadScene(7);

                            });
                        }
                    }

                    for (int i = 0; i < dersler.Length - 1; i++)
                    {

                        string[] detaylar = dersler[i].Split('|');
                        string[] dersBilgileri = detaylar[0].Split('*');
                        string[] hocaBilgileri = dersBilgileri[1].Split(',');
                        string dersAdi = dersBilgileri[0];
                        string hocaAdi = hocaBilgileri[0];
                        string sinif = hocaBilgileri[1];
                        string gunSaat = detaylar[1];
                        string[] gunSaatBilgileri = gunSaat.Split('/');
                        string gun = gunSaatBilgileri[0];
                        string saat = gunSaatBilgileri[1];

                        if (gun == "Salý" & sinif == "1036")
                        {

                            if (salisayac == 0)
                            {
                                salisayac = 1;

                                GameObject gobj3 = (GameObject)Instantiate(gunListelemeSablonu);
                                gobj3.transform.SetParent(programListelemeAlaný.transform);
                                gobj3.GetComponent<PrefabGun>().GunText.text = gun;
                            }
                            GameObject gobj4 = (GameObject)Instantiate(programListelemeSablonu);

                            gobj4.transform.SetParent(programListelemeAlaný.transform);

                            gobj4.GetComponent<ProgramListeleEk>().Hoca.text = hocaAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Ders.text = dersAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Saat.text = saat;
                            gobj4.GetComponent<ProgramListeleEk>().SilButton.onClick.AddListener(() =>
                            {

                                StartCoroutine(ProgramSil(hocaAdi, dersAdi, sinif, saat, gun));
                                SceneManager.LoadScene(7);

                            });
                        }
                    }

                    for (int i = 0; i < dersler.Length - 1; i++)
                    {

                        string[] detaylar = dersler[i].Split('|');
                        string[] dersBilgileri = detaylar[0].Split('*');
                        string[] hocaBilgileri = dersBilgileri[1].Split(',');
                        string dersAdi = dersBilgileri[0];
                        string hocaAdi = hocaBilgileri[0];
                        string sinif = hocaBilgileri[1];
                        string gunSaat = detaylar[1];
                        string[] gunSaatBilgileri = gunSaat.Split('/');
                        string gun = gunSaatBilgileri[0];
                        string saat = gunSaatBilgileri[1];

                        if (gun == "Çarþamba" & sinif == "1036")
                        {

                            if (carsambasayac == 0)
                            {
                                carsambasayac = 1;

                                GameObject gobj3 = (GameObject)Instantiate(gunListelemeSablonu);
                                gobj3.transform.SetParent(programListelemeAlaný.transform);
                                gobj3.GetComponent<PrefabGun>().GunText.text = gun;
                            }
                            GameObject gobj4 = (GameObject)Instantiate(programListelemeSablonu);

                            gobj4.transform.SetParent(programListelemeAlaný.transform);

                            gobj4.GetComponent<ProgramListeleEk>().Hoca.text = hocaAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Ders.text = dersAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Saat.text = saat;
                            gobj4.GetComponent<ProgramListeleEk>().SilButton.onClick.AddListener(() =>
                            {

                                StartCoroutine(ProgramSil(hocaAdi, dersAdi, sinif, saat, gun));
                                SceneManager.LoadScene(7);

                            });
                        }
                    }

                    for (int i = 0; i < dersler.Length - 1; i++)
                    {

                        string[] detaylar = dersler[i].Split('|');
                        string[] dersBilgileri = detaylar[0].Split('*');
                        string[] hocaBilgileri = dersBilgileri[1].Split(',');
                        string dersAdi = dersBilgileri[0];
                        string hocaAdi = hocaBilgileri[0];
                        string sinif = hocaBilgileri[1];
                        string gunSaat = detaylar[1];
                        string[] gunSaatBilgileri = gunSaat.Split('/');
                        string gun = gunSaatBilgileri[0];
                        string saat = gunSaatBilgileri[1];

                        if (gun == "Perþembe" & sinif == "1036")
                        {

                            if (persembesayac == 0)
                            {
                                persembesayac = 1;

                                GameObject gobj3 = (GameObject)Instantiate(gunListelemeSablonu);
                                gobj3.transform.SetParent(programListelemeAlaný.transform);
                                gobj3.GetComponent<PrefabGun>().GunText.text = gun;
                            }
                            GameObject gobj4 = (GameObject)Instantiate(programListelemeSablonu);

                            gobj4.transform.SetParent(programListelemeAlaný.transform);

                            gobj4.GetComponent<ProgramListeleEk>().Hoca.text = hocaAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Ders.text = dersAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Saat.text = saat;
                            gobj4.GetComponent<ProgramListeleEk>().SilButton.onClick.AddListener(() =>
                            {

                                StartCoroutine(ProgramSil(hocaAdi, dersAdi, sinif, saat, gun));
                                SceneManager.LoadScene(7);

                            });
                        }
                    }

                    for (int i = 0; i < dersler.Length - 1; i++)
                    {

                        string[] detaylar = dersler[i].Split('|');
                        string[] dersBilgileri = detaylar[0].Split('*');
                        string[] hocaBilgileri = dersBilgileri[1].Split(',');
                        string dersAdi = dersBilgileri[0];
                        string hocaAdi = hocaBilgileri[0];
                        string sinif = hocaBilgileri[1];
                        string gunSaat = detaylar[1];
                        string[] gunSaatBilgileri = gunSaat.Split('/');
                        string gun = gunSaatBilgileri[0];
                        string saat = gunSaatBilgileri[1];
                       

                        if (gun == "Cuma" & sinif == "1036")
                        {

                            if (cumasayac == 0)
                            {
                                cumasayac = 1;

                                GameObject gobj3 = (GameObject)Instantiate(gunListelemeSablonu);
                                gobj3.transform.SetParent(programListelemeAlaný.transform);
                                gobj3.GetComponent<PrefabGun>().GunText.text = gun;
                            }
                            GameObject gobj4 = (GameObject)Instantiate(programListelemeSablonu);

                            gobj4.transform.SetParent(programListelemeAlaný.transform);

                            gobj4.GetComponent<ProgramListeleEk>().Hoca.text = hocaAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Ders.text = dersAdi;
                            gobj4.GetComponent<ProgramListeleEk>().Saat.text = saat;
                            gobj4.GetComponent<ProgramListeleEk>().SilButton.onClick.AddListener(() =>
                            {
                               
                                StartCoroutine(ProgramSil(hocaAdi,dersAdi,sinif,saat,gun));
                                SceneManager.LoadScene(7);

                            });

                        }

                    }

                    break;
            }
        }
    }
    IEnumerator ProgramSil(string silinecekHocaa, string silinecekDerss, string silinecekSiniff, string silinecekSaatt, string silinecekGunn)
    {
        WWWForm form = new WWWForm();
        form.AddField("silinecekHoca", silinecekHocaa);
        form.AddField("silinecekDers", silinecekDerss);
        form.AddField("silinecekSinif", silinecekSiniff);
        form.AddField("silinecekSaat", silinecekSaatt);
        form.AddField("silinecekGun", silinecekGunn);



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/unity-database/ProgramSilme.php", form))
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
