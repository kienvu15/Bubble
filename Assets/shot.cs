using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] public float moveSpeed = 7f;
    private float moveY;

    [SerializeField] GameObject Bullet;
    [SerializeField] float arrowSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movemnet();
        Shot();
    }

    public void Movemnet()
    {
        moveY = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3 (0, moveY).normalized;
        rb.velocity = movement * moveSpeed;
    }

    public void Shot()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(CoruntinShot());
        }
    }

    public IEnumerator CoruntinShot()
    {
        GameObject taoDan = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
        Rigidbody2D bullet = taoDan.GetComponent<Rigidbody2D>();
        bullet.velocity = new Vector2(arrowSpeed, 0);
        yield return new WaitForSeconds(2f);
        
    }
}
