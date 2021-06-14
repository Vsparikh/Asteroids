using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Min(0f)]
    public int Damage = 1;
    [Min(0f)]
    public float Speed = 3;
    [Min(0f)]
    public float RotationSpeed = 1;

    public float minXPos;

    [SerializeField, Min(0f)]
    private int ScoreValue;

    public GameObject EnemyFX;
    public GameObject DestroyFx;
    private GameObject particleFX;

   public int GetScoreValue() { return ScoreValue;  }

    private void Start()
    {
        //particleFX = Instantiate(EnemyFX, transform.position, Quaternion.identity);
        //particleFX.transform.position -= Vector3.left * 0.5f;
    }

    private void Update()
    {
        if (transform.position.x < minXPos)
        {
            Destroy(particleFX);
            Destroy(gameObject);
        } else
        {
            transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
           // particleFX.transform.Translate(Vector3.left * Speed * Time.deltaTime);
            transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.SetHealth(Mathf.Max(0, player.GetHealth() - Damage));
           // Destroy(particleFX);
            Instantiate(DestroyFx, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
