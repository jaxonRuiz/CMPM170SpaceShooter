using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage;
    public bool player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Expire());
    }

    IEnumerator Expire()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        UnitController unit = other.GetComponent<UnitController>();
        if (unit != null)
        {
            if (unit.player != player)
               unit.Damage(damage);
            Destroy(gameObject);
        }
    }
}
