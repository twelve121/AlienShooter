using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    public static bulletPool instance;
    public GameObject bulletPf;

    private List<GameObject> pool;

    private void Awake()
    {
        pool = new List<GameObject>();

        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject bullet = Instantiate(bulletPf);
            bullet.SetActive(false);
            pool.Add(bullet);
        }
    }
    public GameObject getBullet()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
            
        }

        return null;
    }

    public void returnBullet(GameObject bl)
    {
        bl.SetActive(false);
    }
}
