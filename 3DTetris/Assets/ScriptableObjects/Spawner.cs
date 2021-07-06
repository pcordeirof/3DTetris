using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.AddressableAssets;

[InlineEditor]
[CreateAssetMenu(fileName = "Spawner", menuName = "Gameplay/Spawner")]
public class Spawner : ScriptableObject
{
    [SerializeField] private AssetReferenceGameObject[] pieces;
    AssetReferenceGameObject LastPiece;

    public void SpawnNewPiece()
    {
        Debug.Log("teste");
        AssetReferenceGameObject newAssetReference = pieces[Random.Range(0, pieces.Length)];
        while (newAssetReference == LastPiece)
        {
            newAssetReference = pieces[Random.Range(0, pieces.Length)];
        }
        LastPiece = newAssetReference;
        //Addressables.InstantiateAsync(newAssetReference);
        Addressables.InstantiateAsync(newAssetReference, null, true).Completed += OnLoadDone;
    }

    private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        GameObject myGameObject = obj.Result;
    }
}
