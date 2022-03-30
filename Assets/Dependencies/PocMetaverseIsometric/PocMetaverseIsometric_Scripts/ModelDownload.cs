using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDownload : MonoBehaviour
{
    [SerializeField] private string modelURL;
    [SerializeField] private Bounds selfBounds;
    private Bounds modelBounds;
    MeshFilter[] modelChildFilters;

    public IEnumerator DownloadModel()
    {
        DownloadAsset da = new DownloadAsset(modelURL);
        yield return da.DownloadAssetBundle(SpawnAndResizeObject);
    }

    private void SpawnAndResizeObject(UnityEngine.Object downloadObject)
    {
        GameObject modelObject = Instantiate(downloadObject) as GameObject;
        modelChildFilters = modelObject.GetComponentsInChildren<MeshFilter>();
        foreach (MeshFilter mf in modelChildFilters)
        {
            modelBounds.Encapsulate(mf.mesh.bounds);
        }
        float x = selfBounds.size.x / modelBounds.size.x;
        float y = selfBounds.size.y / modelBounds.size.y;
        float z = selfBounds.size.z / modelBounds.size.z;
        float minScale = Mathf.Min(x, y, z);
        
        modelObject.transform.position = this.transform.position;
        modelObject.AddComponent<ModelInteraction>();
        BoxCollider collider = modelObject.AddComponent<BoxCollider>();
        float colliderSize = 1.0f / minScale;
        collider.size = selfBounds.size * colliderSize;
        collider.isTrigger = true;
        modelObject.transform.localScale = Vector3.one * minScale;
        Destroy(this.gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(this.transform.position + selfBounds.center, selfBounds.size);
    }
}
