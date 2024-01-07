using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecis : MonoBehaviour
{
    public void SahneDegistir(int sahne_ID)
    {
        SceneManager.LoadScene(sahne_ID);
    }

}
