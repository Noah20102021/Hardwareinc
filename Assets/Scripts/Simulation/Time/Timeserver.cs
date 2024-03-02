using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timeserver : MonoBehaviour
{
    public GameObject Timeset;
    Slider Timeslider;
    private float nextTimex2 = 0.5f;
    private float nextTimex5 = 0.2f;
    private float nextTimex10 = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Timeslider = Timeset.GetComponent<Slider>();
        InvokeRepeating("Timex1", 0, 1);

    }
    public void Slider()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimex2)
        {
            Timex2();
            nextTimex2 += 0.5f;
        }
        if (Time.time >= nextTimex5)
        {
            Timex5();
            nextTimex5 += 0.2f;
        }
        if (Time.time >= nextTimex10)
        {
            Timex10();
            nextTimex10 += 0.1f;
        }
    }

    private void Timex1()
    {
        if (Timeslider.value == 1)
        {
            Timecounter();
        }
        
    }
    private void Timex2()
    {
        if (Timeslider.value == 2)
        {
            Timecounter();
        }

    }
    private void Timex5()
    {
        if (Timeslider.value == 3)
        {
            Timecounter();
        }

    }
    private void Timex10()
    {
        if (Timeslider.value == 4)
        {
            Timecounter();
        }

    }
    public void Timecounter()
    {
        Speichern.M++;
        if (Speichern.M == 60)
        {
            Speichern.M = 00;
            Speichern.H++;
        }
        if (Speichern.H == 24)
        {
            Speichern.H = 00;
            Speichern.Day++;
        }
    }
}
