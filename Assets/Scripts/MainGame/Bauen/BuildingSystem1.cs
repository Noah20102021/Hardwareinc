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
    public float gridSize;
    public int spielbereichMin;
    public int spielbereichMax;
    public int gridhöhe=1;
    public bool PlaceOn = false;
    private bool GO = false;
    public List<GameObject> Buildinglist = new List<GameObject>();
    public List<GameObject> Walllist = new List<GameObject>();
    public List<GameObject> Furniturelist = new List<GameObject>();
    private Vector3 Startposition;

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
        for (float x = spielbereichMin-(gridSize/2); x <= spielbereichMax; x += gridSize)
        {
            Vector3 mittelpunkt = new Vector3(x,((0-spielbereichMin+spielbereichMax)/2)+spielbereichMin);
            Vector3 scale = new Vector3(0.1f,spielbereichMax-spielbereichMin);
            DrawLine(mittelpunkt, scale);
        }
        for (float y = spielbereichMin-(gridSize/2); y <= spielbereichMax; y += gridSize)
        {
            Vector3 scale = new Vector3(spielbereichMax - spielbereichMin, 0.1f);
            Vector3 mittelpunkt = new Vector3(((0 - spielbereichMin + spielbereichMax) / 2) + spielbereichMin,y);
            DrawLine(mittelpunkt,scale);
        }
        Debug.Log("Fertig");
    }

void DrawLine(Vector3 mittelpunkt, Vector3 scale)
{
    GameObject myLine = new GameObject();
    myLine.transform.position = mittelpunkt;
    myLine.AddComponent<SpriteRenderer>();
    SpriteRenderer lr = myLine.GetComponent<SpriteRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        
        lr.sprite=Resources.Load<Sprite>("Square");
        lr.transform.position = mittelpunkt;
        lr.transform.localScale = scale;
        lr.material = Resources.Load<Material>("Grid");
        lr.sortingLayerName = "UI";
        lr.sortingOrder = 15;
        Gitter.Add(myLine);
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
                Startposition = roundedMousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                float Startx, Starty;
                float Endex, Endey;
                if(Startposition.x <= roundedMousePosition.x) 
                {
                    Startx = Startposition.x;
                    Endex = roundedMousePosition.x;
                }
                else
                {
                    Endex = Startposition.x;
                    Startx = roundedMousePosition.x;
                }
                if (Startposition.y <= roundedMousePosition.y)
                {
                    Starty = Startposition.y;
                    Endey = roundedMousePosition.y;
                }
                else
                {
                    Endey = Startposition.y;
                    Starty = roundedMousePosition.y;
                }
                for (float x = Startx; x <= Endex; x++) 
                {
                    for (float y = Starty; y <= Endey; y++)
                    {
                        Vector3 Zielposition = new Vector3(x,y,roundedMousePosition.z);
                        bool colision = false;
                        for (int i = 0; i < Buildinglist.Count; i++)
                        {
                            if (Buildinglist[i].transform.position == Zielposition) { colision = true; }
                        }
                            // Hier k�nntest du weitere Logik hinzuf�gen, z.B. �berpr�fung auf Kollisionen oder Ressourcenverf�gbarkeit
                        if (Speichern.Kontostand >= 2 && GO == true && colision == false)
                        {
                            // Geb�ude platzieren
                            //currentBuilding = null;
                            Speichern.Kontostand -= 2;
                            Buildinglist.Add(Instantiate(buildingPrefab, Zielposition, Quaternion.identity));
                        }
                    }
                }
                

                
            }
            
        }

        // Aktualisiere die Positionen der Gitterlinien, sodass sie den ganzen Bildschirm abdecken
       }
}