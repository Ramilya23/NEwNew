using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f; // ����� ����� ����

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���������� Input.GetMouseButtonDown ��� ������������ ��������
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.forward * bulletSpeed; // ������� ���� ������

        Destroy(bulletInstance, bulletLifetime); // ���������� ���� ����� �������� �����

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.forward);
        if (hit.collider != null)
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetDamage();
            }
        }
    }
}