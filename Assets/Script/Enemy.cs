using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float EnemySpeed;

    private Rigidbody2D mybody;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();

        EnemySpeed = 8;
    }
    void FixedUpdate()  
    {
        mybody.velocity = new Vector2(EnemySpeed,mybody.velocity.y);     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
