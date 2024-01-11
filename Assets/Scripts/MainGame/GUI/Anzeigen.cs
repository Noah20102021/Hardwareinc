using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Anzeigen : MonoBehaviour
{
    public GameObject Kontostand;
    TextMeshProUGUI KontostandTMP;
    // Start is called before the first frame update
    void Start()
    {
        KontostandTMP = Kontostand.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string Test;
        Test = Speichern.Kontostand.ToString();
        KontostandTMP.text = Test;
    }
}
