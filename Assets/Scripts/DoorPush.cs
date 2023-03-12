using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPush : MonoBehaviour
{
    public float pushForce = 1.0f; // 推动力量
    public float pushDuration = 1.0f; // 推动时间
    public float pushAngle = 90.0f; // 旋转角度
    public float pushSpeed = 50.0f; // 旋转速度

    private bool isPushing = false; // 是否正在推门
    private bool isOpened = false; // 门是否已经完全打开
    private bool isClosed = true; // 门是否已经完全关闭
    private float pushTimer = 0.0f; // 推动计时器
    private Quaternion initialRotation; // 初始旋转
    private Quaternion targetRotation; // 目标旋转
    private Rigidbody doorRigidbody; // 门刚体

    void Start()
    {
        // 获取门刚体
        doorRigidbody = GetComponent<Rigidbody>();
        // 保存初始旋转
        initialRotation = transform.rotation;
        // 计算目标旋转
        targetRotation = Quaternion.Euler(initialRotation.eulerAngles + new Vector3(0, pushAngle, 0));
    }

    void Update()
    {
        // 如果门已经完全打开或关闭，不再监听玩家输入
        if (isOpened || isClosed)
        {
            return;
        }

        // 监听玩家输入
        if (Input.GetButtonDown("Fire1") && !isPushing)
        {
            // 启动推门协程
            StartCoroutine(PushDoor());
        }
    }

    IEnumerator PushDoor()
    {
        isPushing = true;
        pushTimer = 0.0f;

        while (pushTimer <= pushDuration)
        {
            // 计算门的推动方向和旋转角度
            float angle = Mathf.Lerp(0, pushAngle, pushTimer / pushDuration);
            Vector3 force = Quaternion.Euler(0, angle, 0) * transform.forward * pushForce;
            Quaternion rotation = Quaternion.Lerp(initialRotation, targetRotation, pushTimer / pushDuration);

            // 推动门
            doorRigidbody.AddForceAtPosition(force, transform.position, ForceMode.VelocityChange);
            transform.rotation = rotation;

            // 更新计时器
            pushTimer += Time.deltaTime;
            yield return null;
        }

        // 推动结束后检测门的状态并禁用碰撞器组件
        if (Mathf.Abs(transform.rotation.eulerAngles.y - targetRotation.eulerAngles.y) < 1.0f)
        {
            isOpened = true;
            isClosed = false;
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            isPushing = false;
        }
    }
}
