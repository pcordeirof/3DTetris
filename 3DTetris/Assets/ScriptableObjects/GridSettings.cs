using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[InlineEditor]
[CreateAssetMenu(fileName = "GridSettings", menuName = "Configurations/GridSettings")]
public class GridSettings : ScriptableObject
{
    public  FloatVariable Width;
    public  FloatVariable Height;

    public Transform[,] GridOfBlocks;

    public GameEvent CompleteLineEvent;
    public GameEvent GameOverEvent;
    public void InstatiateGrid()
    {
        GridOfBlocks = new Transform[(int)Width.Value, (int)Height.Value];
        
    }

    public void RegisterBlocks(GameObject piece)
    {
        foreach (Transform block in piece.transform)
        {
            if(block.position.y >= Height.Value)
            {
                GameOverEvent.Raise();
                return;
            }
            else
            {
                GridOfBlocks[(int)block.position.x, (int)block.position.y] = block;
            }
        }
    }

    public void CheckLines()
    {
        for (int y = 0; y < Height.Value; y++)
        {
            if (IsComplete(y))
            {
                RemoveLine(y);
                
                y--;
            }
        }
    }

    bool IsComplete(int y)
    {
        for (int x = 0; x < Width.Value; x++)
        {
            if(GridOfBlocks[x,y] == null)
            {
                return false;
            }
        }
        return true;
    }
    
    void RemoveLine(int y)
    {
        for (int x = 0; x < Width.Value; x++)
        {
            GridOfBlocks[x, y] = null;
        }
        CompleteLineEvent.Raise();
        MoveLines(y);
    }

    public void MoveLines(int y)
    {
        for (int i = y; i < Height.Value -1; i++)
        {
            for(int x = 0; x < Width.Value; x++)
            {
                if (GridOfBlocks[x, i + 1] != null)
                {
                    GridOfBlocks[x, i] = GridOfBlocks[x, i + 1];
                    GridOfBlocks[x, i].gameObject.transform.position -= Vector3.up;
                    GridOfBlocks[x, i + 1] = null;
                }
            }
        }
    }

    public void ClearGrid()
    {
        for(int i = 0; i < Width.Value; i++)
        {
            for(int j = 0; j < Height.Value; j++)
            {
                GridOfBlocks[i, j] = null;
            }
        }
    }
}
