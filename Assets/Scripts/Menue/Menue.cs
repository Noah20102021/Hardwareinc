using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Beenden()
    {
        Debug.Log("Beenden");
        Application.Quit();
    }
    public void Neuesspiel()
    {
        SceneManager.LoadScene("MainGame");
    }
}
