using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData 
{
    Dictionary<Vector3Int, PlacementData> placedObjects = new();
    bool isConform = true;

    public void AddObjectAt(Vector3Int gridPosition, Vector2Int objectSize, int ID, int placedObjectIndex)
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
        PlacementData data = new PlacementData(positionToOccupy, ID, placedObjectIndex, gridPosition, objectSize);
        foreach (var pos in positionToOccupy)
        {
            if (placedObjects.ContainsKey(pos))
            {
                throw new Exception($"Dictionary already contains this cell position {pos}");
            }
            placedObjects[pos] = data;
        }
    }

    private List<Vector3Int> CalculatePositions(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> returnVal = new();
        for(int x = 0; x < objectSize.x; x++)
        {
            for(int y = 0; y < objectSize.y; y++)
            {
                returnVal.Add(gridPosition + new Vector3Int(x, y, 0));
            }
        }
        return returnVal;
    }

    public bool CanPlaceStructAt(Vector3Int gridPosition, Vector2Int objectSize)
    {
        
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
        foreach (var pos in positionToOccupy)
        {
            if (gridPosition.y == 0)
            {
                return true;
            }
            else if (placedObjects.ContainsKey(pos))
            {                
                if (placedObjects[pos].ID == 2 || placedObjects[pos].ID == 3 || placedObjects[pos].ID == 4)
                {
                    Debug.Log(placedObjects[pos].ID);
                    Debug.Log("YAKARI");
                    return false;
                }
                else if (placedObjects[pos].ID == 1 && gridPosition.y == placedObjects[pos].PlacedObjectPosition.y)
                {
                    Debug.Log(placedObjects[pos].ID);
                    Debug.Log("Petit Tonnerre");
                    return true;
                }
       
            }
                
        }
        //isConform = true;
        return false;
    }

    public bool CanPlaceGroundAt(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
        foreach(var pos in positionToOccupy)
        {
            if (placedObjects.ContainsKey(pos) || gridPosition.y == 0) //position prise
            {
                return false; // ET ICI !!!
            }
        }
        return true;
    }
}

public class PlacementData
{
    public List<Vector3Int> occupiedPositions;
    public int ID { get; private set; }
    public int PlacedObjectIndex { get; private set; }
    public Vector3Int PlacedObjectPosition {  get; private set; }
    public Vector2Int PlacedObjectSize { get; private set; }

    public PlacementData(List<Vector3Int> occupiedPositions, int iD, int placedObjectIndex, Vector3Int placedObjectPosition, Vector2Int placedObjectSize)
    {
        this.occupiedPositions = occupiedPositions;
        ID = iD;
        PlacedObjectIndex = placedObjectIndex;
        PlacedObjectPosition = placedObjectPosition;
        PlacedObjectSize = placedObjectSize;
    }
}
