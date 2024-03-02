using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Anzeigen : MonoBehaviour
{
    public GameObject Kontostand;
    public GameObject open;
    public GameObject close;
    TextMeshProUGUI KontostandTMP;
    public GameObject Time;
    TextMeshProUGUI TimeTMP;
    public GameObject Day;
    TextMeshProUGUI DayTMP;
    // Start is called before the first frame update
    void Start()
    {
        KontostandTMP = Kontostand.GetComponent<TextMeshProUGUI>();
        TimeTMP = Time.GetComponent<TextMeshProUGUI>();
        DayTMP = Day.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string Geld;
        Geld = Speichern.Kontostand.ToString();
        KontostandTMP.text = Geld;

        string Time;
        Time = Speichern.H.ToString();
        Time += ":";
        Time += Speichern.M.ToString();
        Time += " uhr";
        TimeTMP.text = Time;
        string Day;
        Day = "Tag: ";
        Day += Speichern.Day.ToString();
        DayTMP.text = Day;
    }
    public void Up()
    {
        close.SetActive(false);
        open.SetActive(true);
    }
    public void Down()
    {
        open.SetActive(false);
        close.SetActive(true);
    }
}
