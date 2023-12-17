using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rigidbody2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractable = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController mapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] CropManager cropsManager;
    [SerializeField] TileData plowableTiles;
    [SerializeField] int treeNumberInput = 4;
    [SerializeField] int plowableNumberInput = 4;
    [SerializeField] GameObject CanvasWin;


    Vector3Int selectedTilePosition;
    bool selectable;
    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectedCheck();
        Marker();
        if(Input.GetMouseButtonDown(0))
        {
           if (UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }
    public void HandleWin(int cut)
    {
        Debug.Log("Cut" + cut);
        if(cut >= treeNumberInput )
        {
            CanvasWin.SetActive(true);
        }
       
    }


    private void SelectTile()
    {
        selectedTilePosition = mapReadController.GetGridPosition(Input.mousePosition, true);
        //Vector3Int gridPosition = mapReadController.GetGridPosition(Input.mousePosition, true);
    }

    public  void CanSelectedCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }


    private void Marker()
    {
        markerManager.markedCellPosition =  selectedTilePosition;
    }


    private bool UseToolWorld()
    {
        Vector2 position = rigidbody2d.position +  character.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractable);
        foreach(Collider2D c in  colliders)
        {
            ToolKit hit = c.GetComponent<ToolKit>();
            if(hit != null)
            {
                hit.Hit();
                return true;
            }
        }
        return false;
    
    }

    private void UseToolGrid()
    {
        if(selectable == true)
        {
            TileBase tileBase = mapReadController.GetTileBase(selectedTilePosition);
            TileData tileData = mapReadController.GetTileData(tileBase);
            if(tileData != plowableTiles)
            {
                return; 
            }

            if (cropsManager.Check(selectedTilePosition))
            {
                cropsManager.Seed(selectedTilePosition);
            }
            else
            {
                cropsManager.Plow(selectedTilePosition);
            }
        }
    }
}
