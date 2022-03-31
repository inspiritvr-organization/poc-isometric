using System.Collections;
using UnityEngine;

public class AssetBundleModelDownload : MonoBehaviour
{
    [SerializeField] private Bounds modelSize;
    private Bounds modelBounds;
    MeshFilter[] modelChildFilters;

    public IEnumerator DownloadModel(string url,string versionString)
    {
        DownloadAssetBundle da = new DownloadAssetBundle();
        yield return da.Download(url,SpawnAndResizeObject, versionString);
    }

    private void SpawnAndResizeObject(UnityEngine.Object downloadObject)
    {
        GameObject modelObject = Instantiate(downloadObject,this.transform.parent) as GameObject;
        modelChildFilters = modelObject.GetComponentsInChildren<MeshFilter>();
        foreach (MeshFilter mf in modelChildFilters)
        {
            modelBounds.Encapsulate(mf.mesh.bounds);
        }
        float x = modelSize.size.x / modelBounds.size.x;
        float y = modelSize.size.y / modelBounds.size.y;
        float z = modelSize.size.z / modelBounds.size.z;
        float minScale = Mathf.Min(x, y, z);
        modelObject.transform.position = this.transform.position;
       
        modelObject.transform.localScale = Vector3.one * minScale;
        this.gameObject.SetActive(false);

        /// these lines are added to adjust the box collider size to match
        //BoxCollider collider = modelObject.AddComponent<BoxCollider>();
        //float colliderSize = 1.0f / minScale;
        //collider.size = modelSize.size * colliderSize;
        //collider.isTrigger = true;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(this.transform.position + modelSize.center, modelSize.size);
    }
}
