using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemyShip : MonoBehaviour
{
    public float forceRate;
    private Vector3 startPos;
    private Vector3 endPos;
    public float step;
    private Transform targetPos;
    public GameObject bombBlast;
    public bool isRed;
    private Color colorDefault;
    private float timer = 10.0f;
    public int counter = 3;


    void Start()
    {
        targetPos = GameObject.Find("Player").GetComponent<Transform>();

        startPos = transform.position;
        endPos = new Vector3(targetPos.transform.position.x, targetPos.transform.position.y, targetPos.transform.position.z);

        colorDefault = gameObject.GetComponent<Renderer>().material.color; // запомним текущий цвет объекта
    }

    void Update()
    {
        MoveProjectileBomb();

        if (step >= 1.0f) // вызываем эффект мерцания
            ColorBlink();

        if (counter == 0)
        {
            Destroy(gameObject);
            Instantiate(bombBlast, transform.position, transform.rotation);
        }

        Debug.Log(timer);
    }

    void MoveProjectileBomb() //задам движение объекта
    {
        if (step < 1.0f)
        {
            transform.position = Vector3.Lerp(startPos, endPos, step);
            step += 0.003f;
        }
    }

    void ColorBlink() //задам мерцание объекту
    {
        if (timer >= 0.0f)
                timer = timer - 0.1f;
            else
            {
                timer = 10.0f;
                counter--;
            }
            
            if (timer >= 5.0f)
                isRed = true;
            else
                isRed = false;

            switch (isRed)
            {
                case true :
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;

                case false :
                    gameObject.GetComponent<Renderer>().material.color = colorDefault;
                break;
            }
    }
}