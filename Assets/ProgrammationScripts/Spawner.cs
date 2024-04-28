using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    // [SerializeField] private GameObject targetObject;
    [SerializeField] private int quantity;
    

    public void Spawn(GameObject other)
    {
        if (other.gameObject.GetComponent<PickableFunction>() != null) return;
        
        for (var i = 0; i < quantity; i++)
        {
            Instantiate(prefab, null).transform.localPosition = transform.position + Vector3.up;
        }
    }

    /*public void SpawnToTargetCoordinate()
    {
        if(targetObject != null) return;
        var spawnPos = targetObject.transform.position;

        for (var i = 0; i < quantity; i++)
        {
            Instantiate(prefab, null).transform.position = spawnPos;
        }
    }*/
}
