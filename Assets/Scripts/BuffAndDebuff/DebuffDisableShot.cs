using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffDisableShot : Influencer
{
    private Transform targetPlayer;
    private float distance;
    private Quaternion rotDebuff;
    private MainUIController uiController;

    void Start()
    {
        uiController = GameObject.Find("MainUI").GetComponent<MainUIController>();

        GameObject player = GameObject.Find("Player");

        if (player)
        {
            targetPlayer = player.GetComponent<Transform>();
            rotDebuff = transform.rotation;
        }
    }

    void Update()
    {

        if (!targetPlayer)
        {
            return;
        }

        // узнаем дистанцию до игрока и при короткой дистанции заставляем двигаться дебафф на игрока
        distance = Vector3.Distance(transform.position, targetPlayer.transform.position);
        if (distance < 10)
        {
            transform.LookAt(targetPlayer);
            transform.position = transform.position + 1.0f * Time.deltaTime * transform.forward;
        }
        else transform.rotation = rotDebuff; // повернем дебафф в прежнее направление
    }

    protected override void OnTriggerEnter(Collider other)
    {
        // Реализуем базовый метод
        base.OnTriggerEnter(other);

        // индивидуальные действия по игроку
        if (other.gameObject.tag == "Player")
        {
            // вызываем текст на экран по подбору
            uiController.GetCurrentText((int)BonusNumber.DebuffDisableShot);

            if (TimerController.isDisable == false)
            {
                TimerController.isDisable = true;
                PlayerController.isDisableShot = true;
                Destroy(gameObject);
            }
            else
            {
                TimerController.timerStatrForDisableShot = 10.0f;
                Destroy(gameObject);
            }

        }
    }
}
