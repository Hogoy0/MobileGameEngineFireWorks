using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    FloatingJoystick _floatingJoystick;

    [SerializeField]
    GameObject _goFootStepFX, _goLandFX, _goGetTargetFX;

    GameManager _gameManager;
    Animator _animator = null;
    Rigidbody _rigidbody = null;

    Vector3 _direction = Vector3.zero;

    float _fRunSpeed = 5.5f;
    bool _isGround, _isBlock;

    private void Awake()
    {
        if ( null == _gameManager ) _gameManager = GameManager.GetInstance;

        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Footstep()
    {
        if (null != _goFootStepFX && _floatingJoystick.Direction.magnitude > 0.5f)
            CreateFX(_goFootStepFX, transform.position, 1.5f);
    }

    public void Land()
    {
        CreateFX(_goLandFX, transform.position, 1.5f);
    }

    void CreateFX(GameObject go, Vector3 position, float dtime)
    { 
        GameObject fx = Instantiate(go, position, transform.rotation);

        ParticleSystem particle = fx.GetComponentInChildren<ParticleSystem>();
        particle?.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        particle?.Play(true);

        StartCoroutine(DestroyFX(fx, dtime));
    }

    IEnumerator DestroyFX(GameObject go, float dtime)
    {
        yield return new WaitForSecondsRealtime(dtime); ;

        Destroy(go);
    }

    void CharacterMove()
    {
        _direction = new Vector3(_floatingJoystick.Direction.x,
                         0,
                         _floatingJoystick.Direction.y);
        _fRunSpeed = Mathf.Lerp(0, 5.5f, _direction.magnitude);

        _rigidbody.MovePosition(_rigidbody.position + _direction.normalized * _fRunSpeed * Time.deltaTime);
        transform.LookAt(transform.position + _direction);
        SetCharacterAnimation();
    }

    void SetCharacterAnimation()
    {
        if ( _isGround )
        {
            _animator.ResetTrigger("Floating");
            _animator.SetTrigger("Landing");

            _animator.SetFloat("Theshold", _floatingJoystick.Direction.magnitude);
            _animator.SetBool("isMove", _floatingJoystick.Direction.magnitude > 0);
        }
        else
        {
            _animator.ResetTrigger("Landing");
            _animator.SetTrigger("Floating");
        }
        
    }

    //private void FixedUpdate()
    private void Update()
    {
        _isGround = Physics.Raycast(transform.position + transform.up * 0.35f,
                                  transform.up * -1,
                                  0.5f,
                                  LayerMask.GetMask("Structure"));

        CharacterMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_gameManager.GetTarget() == other.gameObject )
        {
            CreateFX(_goGetTargetFX, other.transform.position, 2.5f);

            int obtainpoint = other.GetComponent<NPCController>().GetPoint();
            _gameManager.AddScore(obtainpoint);
        }
    }
}
