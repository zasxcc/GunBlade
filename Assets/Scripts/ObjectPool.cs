using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField]private GameObject poolingObjectPrefab;
    Queue<PlayerBullet> poolingObjectQueue = new Queue<PlayerBullet>();

  

    private void Initialize(int initNum)
    {
        for(int i = 0; i< initNum; ++i)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private PlayerBullet CreateNewObject()
    {
        var newOjb = Instantiate(poolingObjectPrefab).GetComponent<PlayerBullet>();
        newOjb.gameObject.SetActive(false);
        newOjb.transform.SetParent(transform);
        return newOjb;
    }

    public static PlayerBullet GetObject()
    {
        if(Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }
        else
        {
            //var newObj = Instance.CreateNewObject();
            //newObj.gameObject.SetActive(true);
            //newObj.transform.SetParent(null);

            //return newObj;
            return null;
        }
    }

    public static void ReturnObject(PlayerBullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
    private void Awake()
    {
        Instance = this;

        Initialize(10);
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
