using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class TemporaryTimer : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private int _timeToStartAt;

        private Coroutine _currentTimerCoroutine;

        [Header("Components")]

        [SerializeField] private TextMeshProUGUI _timerTMPro;

        [Header("Events")]

        public UnityEvent OnTimerRunOut = new UnityEvent();

        #endregion

        #region Methods

        private IEnumerator StartTimer()
        {
            int time = _timeToStartAt;

            while (!GameManager.instance.GetGameOverValue())
            {
                yield return new WaitForSeconds(1);

                time--;
                _timerTMPro.text = time.ToString();

                if (time < 1)
                {
                    OnTimerRunOut.Invoke();
                }
            }

        }

        private void InitializeTimer()
        {
            _timerTMPro.text = _timeToStartAt.ToString();
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            InitializeTimer();
        }

        void Start()
        {
            if (_currentTimerCoroutine == null)
            {
                _currentTimerCoroutine = StartCoroutine(StartTimer());
            }
        }

        #endregion
    }
}