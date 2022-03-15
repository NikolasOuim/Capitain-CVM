using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NikolasEnnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _pv = 10;
    //[SerializeField]
    //private float _toleranceAngle = 1.5f;
    public const float DelaisInvulnerabilite = 1.5f;
    private bool _invulnerable = false;
    private Animator _animator;
    private float _tempsDebutInvulnerabilite;
    [SerializeField]
    private int _pointDestruction = 5;
    private bool _destructionEnCours = false;
    GameObject player;
    public bool _playerEnTerritoire;

    public bool PlayerEnTerritoire { get { return this._playerEnTerritoire; } }

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.gameObject.GetComponent<Animator>();
        _playerEnTerritoire = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this._pv <= 0 && !this._destructionEnCours)
        {
            _animator.SetTrigger("Destruction");
            GameManager.Instance.PlayerData.IncrScore(this._pointDestruction);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<EnnemyPatrol>().enabled = false;
            GameObject.Destroy(this.transform.parent.gameObject, 0.5f);
            this._destructionEnCours = true;
        }

        if (Time.fixedTime > _tempsDebutInvulnerabilite + DelaisInvulnerabilite)
            _invulnerable = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !_invulnerable)
        {
            PlayerBehaviour pb = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (pb != null)
                pb.CallEnnemyCollision();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (collision.gameObject == player)
            {
                _playerEnTerritoire = true;
            }
            if (!_invulnerable)
            {
                this._pv--;
                _animator.SetTrigger("DegatActif");
                _tempsDebutInvulnerabilite = Time.fixedTime;
                _invulnerable = true;
            }
        }
    }
    void OnTriggerExit(UnityEngine.Collider collision)
    {
        if (collision.gameObject == player)
        {
            _playerEnTerritoire = false;
        }
    }
}

//Source :
// https://answers.unity.com/questions/938221/basic-enemy-ai-in-c.html
