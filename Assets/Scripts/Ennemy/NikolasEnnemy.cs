using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class NikolasEnnemy : MonoBehaviour
{
	[SerializeField]
    private float _vitesse = 2f;
	[SerializeField]
    private Transform[] _points;
	private Transform _cible = null;
	private int _indexPoint;
	private float _distanceSeuil = 0.3f;
}