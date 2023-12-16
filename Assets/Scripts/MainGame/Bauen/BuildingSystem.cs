using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public GameObject buildingPrefab;
    private GameObject currentBuilding;
    public float gridSize = 1f;
    public bool PlaceOn = false;
    private bool GO = false;

    // Die LineRenderer-Objekte für das Gitter
    private List <LineRenderer> Gitter;

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

    void InitializeGrid()
    {
        // Erstelle ein leeres GameObject für das Gitter
        GameObject gridObject = new GameObject("Grid");
        for (float x = -500; x <= 500; x += gridSize)
        {
            for (float y = -500; y <= 500; y += gridSize)
            {

            
                // Füge die LineRenderer-Komponenten hinzu
                LineRenderer TempLine = gridObject.AddComponent<LineRenderer>();
                LineRenderer TempLine2= gridObject.AddComponent<LineRenderer>();

                // Setze die Einstellungen für die LineRenderer
                ConfigureLineRenderer(TempLine);
                ConfigureLineRenderer(TempLine2);
                DrawGridLines(new Vector3(x-gridSize,y, 0f), new Vector3(x, y, 0f), TempLine);
                DrawGridLines(new Vector3(x,y- gridSize, 0f), new Vector3(x, y, 0f), TempLine2);

                Gitter.Add(TempLine);
                Gitter.Add(TempLine2);
            }
        }
    }

    void ConfigureLineRenderer(LineRenderer lineRenderer)
    {
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.05f;
    }

    void DrawGridLines(Vector3 startPoint, Vector3 endPoint, LineRenderer lineRenderer)
    {
        Vector3[] positions = new Vector3[2];

        // Berechne die Positionen für das Gitter
        for (int i = 0; i < positions.Length; i++)
        {
            float t = i / (float)(positions.Length - 1);
            positions[i] = Vector3.Lerp(startPoint, endPoint, t);
        }

        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
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
                // Hier könntest du weitere Logik hinzufügen, z.B. Überprüfung auf Kollisionen oder Ressourcenverfügbarkeit
                if (Speichern.Kontostand >= 2 && GO == true)
                {
                    // Gebäude platzieren
                    //currentBuilding = null;
                    Speichern.Kontostand -= 2;
                    Instantiate(buildingPrefab, roundedMousePosition, Quaternion.identity);
                }
            }
        }

        // Aktualisiere die Positionen der Gitterlinien, sodass sie den ganzen Bildschirm abdecken
       }
}




