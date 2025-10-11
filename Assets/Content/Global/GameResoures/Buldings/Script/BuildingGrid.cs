using UnityEngine;


public class BuildingGrid : MonoBehaviour
{
    public float gridSize = 1f; 
    public GameObject previewPiece; 

    private Vector3 gridPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && previewPiece != null)
        {
            // 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Snap to grid
                gridPos = new Vector3(
                    Mathf.Round(hit.point.x / gridSize) * gridSize,
                    hit.point.y,
                    Mathf.Round(hit.point.z / gridSize) * gridSize
                );

               
                if (!Physics.CheckBox(gridPos, Vector3.one * 0.5f)) 
                {
                    
                    Instantiate(previewPiece, gridPos, Quaternion.identity);
                }
            }
        }

        
        if (previewPiece != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit2))
            {
                Vector3 previewPos = new Vector3(
                    Mathf.Round(hit2.point.x / gridSize) * gridSize,
                    hit2.point.y,
                    Mathf.Round(hit2.point.z / gridSize) * gridSize
                );
                
            }
        }
    }
}

