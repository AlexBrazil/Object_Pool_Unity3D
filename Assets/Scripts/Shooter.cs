using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public float moveSpeed = 5f;
    public float minX, maxX; // Limites para movimento da nave

    void Update()
    {
        // Disparo de projéteis
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }

        // Movimento da nave
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Limites da viewport
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, minX, maxX);
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }

    void FireProjectile()
    {
        GameObject projectile = ProjectilePool.Instance.GetProjectile();
        if (projectile != null)
        {
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
        }
    }
}

