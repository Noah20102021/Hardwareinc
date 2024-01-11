using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
public class BuildingSystem : MonoBehaviour
{
    public Button yourButton;
    public GameObject buildingPrefab;
    private GameObject currentBuilding;
    public float gridSize = 15f;
    public int spielbereichMin=-1500;
    public int spielbereichMax=1500;
    public int gridhöhe=1;
    public bool PlaceOn = false;
    private bool GO = false;

    // Die LineRenderer-Objekte f�r das Gitter
    private List <GameObject> Gitter;

    void Start()
    {
        // Initialisiere die LineRenderer-Objekte
        InitializeGrid();
        
    }
    
    public void Butten()
    {
        if (PlaceOn == true)
        {
            PlaceOn = false;
            GO = false;
            Destroy(currentBuilding);
            currentBuilding = null;
        }
        else
        {
            PlaceOn = true;
            GO = true;
        }
    }

    void Update()
    {
        if (PlaceOn == true)
        {
            TryPlaceBuilding();
        }
    }

    public void InitializeGrid()
    {
        Gitter=new List<GameObject>();
        // Erstelle ein leeres GameObject f�r das Gitter
Debug.Log ("Erstelle Grid");
        for (float x = spielbereichMin; x <= spielbereichMax; x += gridSize)
        {
            DrawLine(new Vector3(x,spielbereichMin, 0), new Vector3(x+1, spielbereichMax, 1),Color.green);
        }
        for (float y = spielbereichMin; y <= spielbereichMax; y += gridSize)
        {
            DrawLine(new Vector3(spielbereichMin,y, 0), new Vector3(spielbereichMax, y+1, 1),Color.green);
        }
        Debug.Log("Fertig");
    }

void DrawLine(Vector3 start, Vector3 end, Color color)
{
    GameObject myLine = new GameObject();
    myLine.transform.position = start;
    myLine.AddComponent<SpriteRenderer>();
    SpriteRenderer lr = myLine.GetComponent<SpriteRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        Debug.Log("1Fertig");
        lr.color=color;
        Debug.Log("2Fertig");
        lr.sprite=Resources.Load<Sprite>("Square");
        Debug.Log("3Fertig");
        lr.transform.position = start;
        Debug.Log("4Fertig");
        lr.transform.localScale = end-start;
        Debug.Log("5Fertig");
        lr.material = Resources.Load<Material>("Grid");
        lr.sortingLayerName = "UI";
        lr.sortingOrder = 15;
        Gitter.Add(myLine);
        Debug.Log("6Fertig");
        //GameObject.Destroy(myLine, 20f);
    }

    void TryPlaceBuilding()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 roundedMousePosition = new Vector3(
            Mathf.Round(mousePosition.x / gridSize) * gridSize,
            Mathf.Round(mousePosition.y / gridSize) * gridSize,
            0f
        );

        if (currentBuilding == null && GO == true)
        {
            currentBuilding = Instantiate(buildingPrefab, roundedMousePosition, Quaternion.identity);
            
        }
        else
        {
            currentBuilding.transform.position = roundedMousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                // Hier k�nntest du weitere Logik hinzuf�gen, z.B. �berpr�fung auf Kollisionen oder Ressourcenverf�gbarkeit
                if (Speichern.Kontostand >= 2 && GO == true)
                {
                    // Geb�ude platzieren
                    //currentBuilding = null;
                    Speichern.Kontostand -= 2;
                    Instantiate(buildingPrefab, roundedMousePosition, Quaternion.identity);
                }
            }
        }

        // Aktualisiere die Positionen der Gitterlinien, sodass sie den ganzen Bildschirm abdecken
       }
}