using UnityEngine;
using Photon.Pun;

public class CustomPrefabPool : MonoBehaviour, IPunPrefabPool
{
    public GameObject Instantiate(string prefabId, Vector3 position, Quaternion rotation)
    {
        // Implement your own logic to instantiate the prefab based on the prefabId
        // You can load the prefab from any location and return the instantiated GameObject
        GameObject prefab = Resources.Load<GameObject>(prefabId);
        if (prefab != null)
        {
            return GameObject.Instantiate(prefab, position, rotation);
        }
        else
        {
            Debug.LogError("Prefab not found: " + prefabId);
            return null;
        }
    }

    public void Destroy(GameObject gameObject)
    {
        // Implement your own logic to destroy the instantiated GameObject
        GameObject.Destroy(gameObject);
    }
}