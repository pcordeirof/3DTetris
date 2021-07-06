using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DissolveBlock : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material dissolveMaterial;
    public GridSettings gridSettings;
    public PieceMovement pieceMovement;

    public void Dissolve()
    {
        if(gridSettings.GridOfBlocks[(int)transform.position.x, (int)transform.position.y] == null && pieceMovement.isMovable == false)
        {
            //meshRenderer.material = dissolveMaterial;
            //meshRenderer.material.DOFloat(1, "_Cutoff", 1f);
            //Destroy(this.gameObject, .01f);
            Destroy(this.gameObject);
        }
    }
}
