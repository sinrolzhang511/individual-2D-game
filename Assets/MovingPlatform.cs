using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f; // 移动速度
    public float moveDistance = 3f; // 移动的最大距离
    private Vector3 startPos;
    private int direction = 1; // 1 = 右移动, -1 = 左移动

    void Start()
    {
        startPos = transform.position; // 记录起始位置
    }

    void Update()
    {
        // 计算新位置
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // 检查是否超出范围
        if (Vector3.Distance(startPos, transform.position) >= moveDistance)
        {
            direction *= -1; // 改变方向
        }
    }
}

