using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public abstract class Poolable : MonoBehaviour
{
    public UnityEvent<Poolable> removeToPoolEvent { get; private set; } = new UnityEvent<Poolable>();

    public void RemoveToPool()
    {
        removeToPoolEvent.Invoke(this);
    }

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

            Poolable poolableComponent = newPooledObject.GetComponent<Poolable>();
            if (poolableComponent != null) poolableComponent.removeToPoolEvent.AddListener(RemoveToPool);

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

			Poolable poolableComponent = pooledObject.GetComponent<Poolable>();
			if (poolableComponent != null) poolableComponent.removeToPoolEvent.AddListener(RemoveToPool);
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

    public void RemoveToPool(Poolable _poolableObject)
    {
        pooledObjects.Push(_poolableObject.gameObject);

		_poolableObject.gameObject.SetActive(false);

        _poolableObject.ResetObject();
	}
}
