using System.Collections.Generic;
using UnityEngine;


public interface IPoolable
{
    public abstract void ResetObject();
}

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int AmountToPool;

    private Stack<GameObject> pooledObjects = new Stack<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    public void AddObjectToPool(GameObject _poolableObject)
    {
        pooledObjects.Push(_poolableObject);

		_poolableObject.SetActive(false);
		IPoolable poolableComponent = _poolableObject.GetComponent<IPoolable>();

        if (poolableComponent == null) poolableComponent.ResetObject();
	}
}
