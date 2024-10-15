using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GridData 
{
    Dictionary<Vector3Int, PlacementData> placedObjects = new();

    public void AddObjectAt(Vector3Int gridPosition, Vector2Int objectSize, int ID, int placedObjectIndex, int objectCountOnPos, bool isGround)
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
        PlacementData data = new PlacementData(positionToOccupy, ID, placedObjectIndex, gridPosition, objectSize, objectCountOnPos, isGround);
        foreach (var pos in positionToOccupy)
        {
            if (placedObjects.ContainsKey(pos))
            {                
                placedObjects[pos].PlacedObjectCount = 2;
                //throw new Exception($"Dictionary already contains this cell position {pos}");
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
                /*if (placedObjects[pos].PlacedObjectCount > 1)
                {
                    Debug.Log("Nop");
                    return false;
                }*/
                /*if (placedObjects[pos].ID == 2 || placedObjects[pos].ID == 3 || placedObjects[pos].ID == 4)
                {
                    Debug.Log(placedObjects[pos].PlacedObjectCount);
                    return false;
                }*/
                
                if (placedObjects[pos].ID == 1
                    && gridPosition.y == placedObjects[pos].PlacedObjectPosition.y
                    && placedObjects[pos].PlacedObjectCount == 1)
                {
                    Debug.Log("T_Count " + placedObjects[pos].PlacedObjectCount);
                    Debug.Log("T_ID " + placedObjects[pos].ID);
                    return true;
                }
                Debug.Log("F_Count " + placedObjects[pos].PlacedObjectCount);
                Debug.Log("F_ID " + placedObjects[pos].ID);

            }
        }
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
    public int PlacedObjectCount { get ;  set; }
    public bool PlacedObjectIsGround { get;  set; }

    public PlacementData(List<Vector3Int> occupiedPositions, int iD, int placedObjectIndex, Vector3Int placedObjectPosition, Vector2Int placedObjectSize, int placedObjectCount, bool placedObjectIsGround)
    {
        this.occupiedPositions = occupiedPositions;
        ID = iD;
        PlacedObjectIndex = placedObjectIndex;
        PlacedObjectPosition = placedObjectPosition;
        PlacedObjectSize = placedObjectSize;
        PlacedObjectCount = placedObjectCount;
        PlacedObjectIsGround = placedObjectIsGround;
    }
}
