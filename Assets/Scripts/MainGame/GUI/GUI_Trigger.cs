using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_Trigger : MonoBehaviour
{
    public GameObject ESCMenue;
    public bool ESCMenueOpen;
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
}
