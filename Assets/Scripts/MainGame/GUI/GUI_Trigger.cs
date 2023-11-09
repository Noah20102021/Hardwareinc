using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Trigger : MonoBehaviour
{
    public GameObject ESCMenue;
    public bool ESCMenueOpen;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
