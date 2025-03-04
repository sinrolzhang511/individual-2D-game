using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject coinPrefab;  // 金币预制体
    public AudioClip coinSound;    // 播放的音效
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Block potentialBlock = collision.gameObject.GetComponent<Block>();
        
        if (potentialBlock != null)
         {
            // 获取碰撞点的位置
            ContactPoint2D contact = collision.contacts[0];

            // 确保是从底部撞击
            if (transform.position.y < potentialBlock.transform.position.y - .25f) 
            {
                // 计算金币生成位置（coinBlock的上方）
                Vector3 spawnPosition = potentialBlock.transform.position + new Vector3(0, 1, 0);
                
                // 生成金币
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

                // 播放金币音效
                if (coinSound != null)
                {
                    AudioSource.PlayClipAtPoint(coinSound, transform.position);
                }

                // 销毁金块
                Destroy(potentialBlock.gameObject);
            }
        }
    }
}

