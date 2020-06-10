using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float damage = 5f;
    [SerializeField] GameObject ExplosionVFX;
    float durationOfExplosion = 0.3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var healthDecrease = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();
        if (healthDecrease && attacker)
        {
            healthDecrease.DealDamage(damage);
            Destroy(gameObject);
            GameObject iceExplosion = Instantiate(
                ExplosionVFX, transform.position, Quaternion.identity);
            Destroy(iceExplosion, durationOfExplosion);
        }  
    }
}
