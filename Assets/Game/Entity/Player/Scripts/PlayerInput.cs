using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovements _playerMovements;
    [SerializeField] private PlayerDamager _playerDamager;
    [SerializeField] private PlayerAnimatorController _playerAnimatorController;
    [SerializeField] private Fliper _playerFliper;

    [SerializeField] private float _delayHit;
    [SerializeField] private float _delayKick;

    private bool _isHit;
    private bool _isPlayingKick;
    private bool _isKick = false;
    private float _currentDelayHit;
    private float _currentDelayKick;

    private void FixedUpdate()
    {
        InputWalking();      
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) _playerFliper.SetFlip(false);
        InputHit();
        InputKick();
        InputFireball();
    }

    public void EndKick()
    {
        _isPlayingKick = false;
        _playerDamager.Kick();
    }

    public void StartKick()
    {
        if (!Input.GetMouseButton(0)) return;
        _isKick = true;
    }

    private void InputWalking()
    {
        float input = Input.GetAxis("Horizontal");
        if (_isPlayingKick ) input = 0;
        _playerMovements.Walking(input);
        if (input == 0)
        {
            _playerAnimatorController.OnWalking(false);
        }
        else
        {
            _playerAnimatorController.OnWalking(true);
            if (input < 0) _playerFliper.SetFlip(true);
            else _playerFliper.SetFlip(false);
        }
    }
    private void InputHit()
    {
        if (!_isPlayingKick && _currentDelayHit <= 0)
        {
            _isHit = true;
            _currentDelayHit = _delayHit;
        }
        else if(!_isPlayingKick)
        {
            _currentDelayHit -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && _isHit)
        {
            _playerAnimatorController.OnHit();
            _playerDamager.Hit();
            _isHit = false;
        }
    }

    private void InputKick()
    {
        if(_isKick)
        {
            _playerAnimatorController.OnKick();
            _isKick = false;
            _isPlayingKick = true;
        }

        if (_isPlayingKick && _currentDelayKick <= 0)
        {
            _isPlayingKick = false;
            _currentDelayKick = _delayKick;
        }
        else if (_isPlayingKick)
        {
            _currentDelayKick -= Time.deltaTime;
        }
    }


    private void InputFireball()
    {
        if (_isPlayingKick || !_isHit) return;
        if (Input.GetMouseButtonDown(1)) _playerDamager.Fireball();
    }
}
