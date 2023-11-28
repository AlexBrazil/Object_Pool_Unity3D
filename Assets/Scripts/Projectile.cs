using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 2f;

    private void OnEnable()
    {
        Invoke("Hide", lifeTime); // Esconde o projétil após um certo tempo
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void Hide()
    {
        ProjectilePool.Instance.ReturnProjectile(gameObject);
    }


    private void OnCollisionEnter(Collision other)
    {
        // Adicione aqui o que acontece quando o projétil colide com algo
        Hide();
    }
}

