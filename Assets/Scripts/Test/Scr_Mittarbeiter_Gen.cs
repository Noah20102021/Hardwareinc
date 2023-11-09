using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scr_Mittarbeiter_Gen : MonoBehaviour
{
    public int Full;
    public int MaxGen;
    public int Score1;
    public int Score2;
    public int Score3;
    public int Score1Wert;
    public int Score2Wert;
    public int Score3Wert;
    public int MaxPreis;
    public int MinPreis;
    public int Preis;
    public Slider Anzeige1;
    public Slider Anzeige2;
    public Slider Anzeige3;
    public GameObject Anzeige1T;
    public GameObject Anzeige2T;
    public GameObject Anzeige3T;
    TextMeshProUGUI Anzeige1TMP;
    TextMeshProUGUI Anzeige2TMP;
    TextMeshProUGUI Anzeige3TMP;
    
    void Start()
    {
        Full = 11;
        MaxGen = 0;
        Anzeige1TMP = Anzeige1T.GetComponent<TextMeshProUGUI>();
        Anzeige2TMP = Anzeige2T.GetComponent<TextMeshProUGUI>();
        Anzeige3TMP = Anzeige3T.GetComponent<TextMeshProUGUI>();
        Debug.Log("Scr_Mittarbeiter_Gen Loadet");
    }
    public void Gen()
    {
        Score1 = Random.Range(1, Full);
        MaxGen = MaxGen - Score1;
        if (MaxGen < 100)
        {
            Full = MaxGen;
        }
        Score2 = Random.Range(1, Full);
        MaxGen = MaxGen - Score2;
        if (MaxGen < 100)
        {
            Full = MaxGen;
        }
        Score3 = Random.Range(1, Full);
        MaxGen = MaxGen - Score3;
        if (MaxGen < 100)
        {
            Full = MaxGen;
        }
        Debug.Log("Kunden Suport " + Score1 + "%");
        Debug.Log("Forschung " + Score2 + "%");
        Debug.Log("Marketing " + Score3 + "%");
        Anzeige1.value = Score1;
        Anzeige2.value = Score2;
        Anzeige3.value = Score3;
        //Score1Wert = Score1 -  3 %;
        MaxPreis = Score1 + Score2 + Score3 + 10;
        MinPreis = MaxPreis - 20;
        Preis = Random.Range(MinPreis, MaxPreis);
        Debug.Log(Preis + "€");
        Anzeige1TMP.text = Score1.ToString() + "%";
        Anzeige2TMP.text = Score2.ToString() + "%";
        Anzeige3TMP.text = Score3.ToString() + "%";

        
    }
    public void B1()
    {
        Debug.Log("LV1Start");
        Full = 50;
        MaxGen = 50;
        Gen();
    }
}
