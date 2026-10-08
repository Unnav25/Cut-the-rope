using UnityEngine;
public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.WinGame();
        }
    }
}