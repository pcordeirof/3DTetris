using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public GameObject piece;

    public GameConfiguration gameConfiguration;
    public GridSettings gridSettings;

    float timer;

    public bool isMovable = true;
    bool gridPositionIsNotNull = true;

    public Spawner spawner;

    public GameEvent gameOver;

    void Start()
    {
        piece.transform.position = new Vector3(Mathf.FloorToInt(gridSettings.Width.Value / 2), gridSettings.Height.Value, 0f);
    }


    void Update()
    {
        if (isMovable && Manager.isPaused == false)
        {
            timer += 1 * Time.deltaTime;

            if (Input.GetKey(KeyCode.DownArrow) && timer >= gameConfiguration.HighDropFrequency.Value)
            {
                GoDown();
            }
            else if (timer >= gameConfiguration.RegularDropFrequency.Value)
            {
                GoDown();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Movement(KeyCode.LeftArrow);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Movement(KeyCode.RightArrow);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Movement(KeyCode.UpArrow);
            }
        }
    }
    void Movement(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.LeftArrow:
                piece.transform.position -= Vector3.right;
                if (!CheckPositionValidation())
                {
                    piece.transform.position += Vector3.right;
                    break;
                }
                break;
            case KeyCode.RightArrow:
                piece.transform.position += Vector3.right;
                if (!CheckPositionValidation())
                {
                    piece.transform.position -= Vector3.right;
                    break;
                }
                break;
            case KeyCode.UpArrow:
                piece.transform.eulerAngles -= Vector3.forward * 90;
                if (!CheckPositionValidation())
                {
                    int count = 0;
                    if (!gridPositionIsNotNull)
                    {
                        foreach (Transform block in piece.transform)
                        {
                            while(block.transform.position.x >= gridSettings.Width.Value)
                            {
                                piece.transform.position -= Vector3.right;
                                count--;
                            }
                     
                            while(block.transform.position.x < 0)
                            {
                                piece.transform.position += Vector3.right;
                                count++;
                            }
                        }
                        if (!CheckPositionValidation())
                        {
                            piece.transform.position += (-1 * count) * Vector3.right;
                            piece.transform.eulerAngles += Vector3.forward * 90;
                        }
                    }
                    else
                    {
                        piece.transform.eulerAngles += Vector3.forward * 90;
                    }
                    break;
                }
                break;
        }    
    }
    void GoDown()
    {
        piece.transform.position -= Vector3.up;
        timer = 0f;
        if (!CheckPositionValidation())
        {

            isMovable = false;
            piece.transform.position += Vector3.up;
            gridSettings.RegisterBlocks(piece);
            gridSettings.CheckLines();
            spawner.SpawnNewPiece();
        }
    }

    bool CheckPositionValidation()
    {
        foreach (Transform block in piece.transform)
        {
            if(block.transform.position.x >= gridSettings.Width.Value || block.transform.position.x < 0 || block.transform.position.y < 0)
            {
                return false;
            }
            
            if(gridSettings.GridOfBlocks[(int)block.position.x, (int)block.position.y] != null && block.position.y < gridSettings.Height.Value)
            {
                gridPositionIsNotNull = true;
                return false;
            }
            else
            {
                gridPositionIsNotNull = false;
            }
        }
        return true;
    }

    bool CheckHeight()
    {
        foreach(Transform block in piece.transform)
        {
            if(block.transform.position.y >= gridSettings.Height.Value)
            {
                return false;
            }
        }
        return true;
    }
}
