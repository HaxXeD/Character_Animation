using UnityEngine;

namespace Haxxed{
    public class PlayerController : MonoBehaviour
    {
        Animator _animator;
        float _velocity = 0.0f;
        int _xVelocityHash;
        [SerializeField] float _accelaration = 0.1f;
        [SerializeField] float _deaccelaration = 0.5f;

        private void Awake() => _animator = GetComponent<Animator>();

        private void Start()
        {
            _xVelocityHash = Animator.StringToHash("xVelocity");
        }

        void Update()
        {
            bool walk = Input.GetKey(KeyCode.W);
            bool run = Input.GetKey(KeyCode.LeftShift);

            if (walk&&_velocity<1.0f)
            {
                _velocity += Time.deltaTime * _accelaration;
            }
            if (!walk&&_velocity>0.0f)
            {
                _velocity -= Time.deltaTime * _deaccelaration;
            }if (!walk&&_velocity<0.0f)
            {
                _velocity = 0.0f;
            }
            _animator.SetFloat(_xVelocityHash, _velocity);
        }
    }
}
