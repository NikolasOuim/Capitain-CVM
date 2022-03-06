using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapeauUpgrade : MonoBehaviour
{
    [SerializeField]
    private int _chapeau = 1;
    [SerializeField]
    private AudioClip _clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.AudioManager.PlayClipAtPoint(_clip, this.transform.position);
            GameManager.Instance.PlayerData.AddChapeau(this._chapeau);
            GameObject.Destroy(this.gameObject);
        }
    }
}
