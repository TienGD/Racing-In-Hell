using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float minSize = 0.5f;
    public float maxSize = 2f;
    public float minSpeed = 50f;
    public float maxSpeed = 150f;
    public float maxspin = 10f;
    public GameObject bounceEffectPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
        rb = GetComponent<Rigidbody2D>();
        float randomSpeed = Random.Range(minSpeed, maxSpeed)/randomSize;
        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection * randomSpeed);
        float randomTorque = Random.Range(-maxspin, maxspin);
        rb.AddTorque(randomTorque);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactPoint = collision.GetContact(0).point;
        GameObject bounceEffect = Instantiate(bounceEffectPrefab, contactPoint, Quaternion.identity);

        // Destroy the effect after 1 second
        Destroy(bounceEffect, 1f);
    }
}
