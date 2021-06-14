using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [Min(0f)]
    public float Speed;
    public float MaxHeight;
    public float MinHeight;
    [Min(0f)]
    public float YIncrement;

    [SerializeField, Min(0f)]
    private int health = 20;

    public GameObject PlayerDestroyFX;

    public Text healthDisplay; 
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "HP: " +  health.ToString();
        if (health <= 0)
        {
            Instantiate(PlayerDestroyFX, transform.position, Quaternion.identity);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Vector3 targetPos = transform.position + Vector3.up * Speed * Input.GetAxis("Vertical");

        if (targetPos.y < MaxHeight && targetPos.y > MinHeight)
        {
            transform.position = targetPos;
        }
    }
    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int newHealth)
    {
        Debug.Assert(newHealth >= 0);
        if (newHealth >= 0)
        {
            health = newHealth;
        }
    }
}
