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
    [SerializeField] GameObject blocksHolder;
    [SerializeField] Camera MyCamera;
    [SerializeField] float range;
    private void Start()
    {
        inventoryManager = inventoryManagerOwner.GetComponent<InventoryManager>();
    }
    private void Update()
    {
        if (GetCurrentSlot().item != null)
        {
            
                HighlightTile();
            
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (GetCurrentSlot().item != null)
            {
                if (GetCurrentSlot().item.type == ItemType.Block)
                {

                    Build(GetCurrentSlot(), GetMousePosOnGrid());
                }
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

            if (tile)//************
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
        Ray ray = MyCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        if (hit.collider == null)
        {
            GameObject blockFarFarAway = Instantiate(currentSlot.item.block, new Vector3(9999, 9999, 999), Quaternion.identity, blocksHolder.transform);
            currentSlot.item.tile.Paint(mainTilemap, blockFarFarAway, position);
            currentSlot.DecreaseAmount(1);
        }
    }
    public InventorySlot GetCurrentSlot()
    {
        if (inventoryManager.selectedSlotInt <= 1)
        {
            return fastPanel.transform.GetChild(inventoryManager.selectedSlotInt).GetComponent<InventorySlot>();
        }
        else
        {
            return fastPanel.transform.GetChild(inventoryManager.selectedSlotInt).GetComponent<InventorySlot>();
        }
    }
    
}
