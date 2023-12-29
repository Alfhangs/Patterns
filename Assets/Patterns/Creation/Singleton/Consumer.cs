using UnityEngine;

namespace Patterns.Creation.Singleton
{
    public class Consumer : MonoBehaviour
    {
        private void Start()
        {
            var scoreSystem = ScoreSystemMonoBehaviour2.Instance();
            scoreSystem.AddScore(100);
            ScoreSystemMonoBehaviour2.Instance().AddScore(100);
        }
    }
}
