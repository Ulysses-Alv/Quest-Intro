using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class CombineMeshes : MonoBehaviour
{
    [SerializeField] private string meshName;


    [ContextMenu("CombinarMesh")]
    public void CombinarMesh()
    {
        if(meshName == null || meshName == "") 
        {
            Debug.LogError("Please pick an name for the new mesh.");
            return;
        }
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }

        Mesh mesh = new Mesh();

        mesh.name = meshName;
        
        mesh.CombineMeshes(combine);

        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        
        gameObject.SetActive(true);
    
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    
    }
}