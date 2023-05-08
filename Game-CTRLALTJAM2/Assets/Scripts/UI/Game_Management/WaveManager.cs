using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.GameManagement
{
    public enum WaveState
    {
        WAVE_1 = 1, WAVE_2, WAVE_3, WAVE_4, BOSS
    }

    public class WaveManager : MonoBehaviour
    {
        public WaveState _wave;


        private void Start()
        {
            _wave = WaveState.WAVE_1;
        }


        public void NextWave()
        {
            _wave++;
        }
    }

}

