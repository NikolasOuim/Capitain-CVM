using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Félicitation, le niveau est terminé.");
            GameManager.Instance.SaveData();
            GameManager.Instance.PlayerData.IncrNiveau();
            

            if (GameManager.Instance.PlayerData.Niveau.Equals(2))
            {
                SceneManager.LoadScene("Level2");
            }
            //else if (GameManager.Instance.PlayerData.Niveau.Equals(3))
            //{
             //   SceneManager.LoadScene("Level3");
            //}
            //
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
            
        }
    }
}
