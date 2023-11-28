using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance;

    public GameObject projectilePrefab;
    public int initialPoolSize = 20;

    private Queue<GameObject> availableProjectiles = new Queue<GameObject>();
    private List<GameObject> usedProjectiles = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform);
            projectile.SetActive(false);
            availableProjectiles.Enqueue(projectile);
        }
    }

    public GameObject GetProjectile()
    {
        GameObject projectile;

        if (availableProjectiles.Count > 0)
        {
            projectile = availableProjectiles.Dequeue();
        }
        else
        {
            Debug.Log("Criando novo projétil, pool insuficiente.");
            projectile = Instantiate(projectilePrefab, transform);
        }

        projectile.SetActive(true);
        usedProjectiles.Add(projectile);
        return projectile;
    }

    public void ReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
        usedProjectiles.Remove(projectile);
        availableProjectiles.Enqueue(projectile);
    }
}
