using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private TileBase highlightedTile;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private Tilemap tempTilemap;
    private Vector3Int highlightedTilePos;
    private bool isHighlighted;
    private InventoryManager inventoryManager;
    [SerializeField] private GameObject inventoryManagerOwner;
    [SerializeField] private GameObject fastPanel;
    private void Start()
    {
        inventoryManager = inventoryManagerOwner.GetComponent<InventoryManager>();
    }
    private void Update()
    {
        HighlightTile();
        if (Input.GetMouseButtonDown(0))
        {
            if (GetCurrentSlot().item != null)
            {
                
                Build(GetCurrentSlot(), highlightedTilePos);
            }
        }
    }
    private Vector3Int GetMousePosOnGrid()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mouseCellPos = mainTilemap.WorldToCell(mousePos);
        mouseCellPos.z = 0;
        return mouseCellPos;
    }
    private void HighlightTile()
    {
        Vector3Int mouseGridPos = GetMousePosOnGrid();

        if (highlightedTilePos != mouseGridPos) 
        {
            tempTilemap.SetTile(highlightedTilePos, null);

            TileBase tile = mainTilemap.GetTile(mouseGridPos);

            if (true)//************
            {
                tempTilemap.SetTile(mouseGridPos, highlightedTile);

                highlightedTilePos = mouseGridPos;

                isHighlighted = true;
            }
            else
            {
                isHighlighted = false;
            }
        }
    }
    private void Build (InventorySlot currentSlot, Vector3Int position)
    {
        currentSlot.item.tile.Paint(mainTilemap, currentSlot.item.block, position);
        currentSlot.DecreaseAmount(1);
    }
    private InventorySlot GetCurrentSlot()
    {
        return fastPanel.transform.GetChild(inventoryManager.selectedSlotInt).GetComponent<InventorySlot>();
    }
    
}
