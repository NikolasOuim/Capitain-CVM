using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonUpgrade : MonoBehaviour
{
    [SerializeField]
    private int _moon = 1;
    [SerializeField]
    private AudioClip _clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.AudioManager.PlayClipAtPoint(_clip, this.transform.position);
            GameManager.Instance.PlayerData.AddMoon(this._moon);
            GameObject.Destroy(this.gameObject);
        }
    }
}
