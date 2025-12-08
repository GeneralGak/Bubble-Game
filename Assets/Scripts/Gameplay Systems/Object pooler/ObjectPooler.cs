using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public abstract class Poolable : MonoBehaviour
{
    public abstract void ResetObject();
}

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int AmountToPool;

    private Stack<GameObject> pooledObjects = new Stack<GameObject>();


    void Start()
    {
        // Create a group of objects at start
        for (int i = 0; i < AmountToPool; i++)
        {
			GameObject newPooledObject = Instantiate(objectToPool);

			pooledObjects.Push(newPooledObject);

            newPooledObject.SetActive(false);
        }
    }

    public GameObject GetPooledObject(Vector3 _spawnPosition, Quaternion _spawnRotation)
    {
        GameObject pooledObject;

		if (pooledObjects.Count == 0)
        {
            pooledObject = Instantiate(objectToPool, _spawnPosition, _spawnRotation);
        }
        else
        {
			pooledObject = pooledObjects.Pop();

            pooledObject.transform.position = _spawnPosition;
            pooledObject.transform.rotation = _spawnRotation;
			pooledObject.SetActive(true);
		}

		return pooledObject;
    }

    public void RemoveToPool(GameObject _poolableObject)
    {
        pooledObjects.Push(_poolableObject);

		_poolableObject.SetActive(false);

		Poolable[] poolableComponents = _poolableObject.GetComponents<Poolable>();
        for (int i = 0; i < poolableComponents.Length; i++)
        {
            poolableComponents[i].ResetObject();
		}
	}
}
