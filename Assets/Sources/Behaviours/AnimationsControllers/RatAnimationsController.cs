﻿using UnityEngine;

namespace Sources.Behaviours.AnimationsControllers {
    public class RatAnimationsController : MonoBehaviour {
        [SerializeField] private Transform _lookingAnchor;
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _idleAudioSource;
        
        private bool _isMoving;
        private const float _moveSpeed = 0.004f;

        private void FixedUpdate() {
            _lookingAnchor.position = new Vector3(Camera.main.transform.position.x,
                gameObject.transform.position.y,
                Camera.main.transform.position.z);

            if (!_isMoving) return;
            gameObject.transform.position += (_lookingAnchor.transform.position - gameObject.transform.position).normalized * _moveSpeed;
            gameObject.transform.LookAt(_lookingAnchor);
            gameObject.transform.Rotate(0f, 180f, 0f);
        }

        public void StartMove() {
            _animator.SetBool("Move", true);
            _isMoving = true;
            _idleAudioSource.Stop();
        }

        public void EndMove() {
            _animator.SetBool("Move", false);
            _isMoving = false;
            _idleAudioSource.Play();
        }
    }
}