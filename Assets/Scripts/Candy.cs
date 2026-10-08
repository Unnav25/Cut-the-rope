using UnityEngine; 
public class Candy : MonoBehaviour
{
    private bool countedThisAttempt = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (countedThisAttempt) return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            countedThisAttempt = true;

            GameData.Instance.failCount++;

            if (GameData.Instance.currentLevelScore > 0)
            {
                GameData.Instance.currentLevelScore--;
            }

            if (GameData.Instance.failCount >= 3)
            {
                GameManager.Instance.ShowDefeat();
            }
            else
            {
                GameManager.Instance.ShowGameOver();
            }
        }
    }
}