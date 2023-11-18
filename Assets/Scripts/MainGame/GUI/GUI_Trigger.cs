using DevionGames.UIWidgets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GUI_Trigger : MonoBehaviour
{
    public GameObject ESCMenue;
    public bool ESCMenueOpen;
    public GameObject Finanzen;
    // Start is called before the first frame update
    void Start()
    {
        ESCMenue.SetActive(false);
        ESCMenueOpen = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC");
            if (ESCMenueOpen == false)
            {
                ESCMenue.SetActive(true);
                ESCMenueOpen = true;
            }
            else
            {
                ESCMenue.SetActive(false);
                ESCMenueOpen = false;
            }
        }
    }
    public void ESCzu()
    {
        ESCMenue.SetActive(false);
        ESCMenueOpen = false;
    }
    public void Menue()
    {
        SceneManager.LoadScene("Menue");
    }
    public void FinanzenOpen()
    {
        Finanzen.GetComponent<UIWidget>().Show();
    }
}
