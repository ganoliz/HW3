
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Setting
{
    public static class Volume
    {
        private static int _bgm = 70;
        private static int _effect = 70;

        public static int VOLUME_BGM
        {
            get { return _bgm; }
            set { _bgm = value; }
        }
        public static int VOLUME_EFFECT
        {
            get { return _effect; }
            set { _effect = value; }
        }

        public static void volume_low() {
            _bgm -= 5;
            if (_bgm < 0)
                _bgm = 0;
        }

        public static void volume_high()
        {
            _bgm += 5;
            if (_bgm > 100)
                _bgm = 100;
        }

        public static void effect_low()
        {
            _effect -= 5;
            if (_effect < 0)
                _effect = 0;
        }

        public static void effect_high()
        {
            _effect += 5;
            if (_effect > 100)
                _effect = 100;
        }

        public static void Default()
        {
            _bgm = 70;
            _effect = 70;
        }
    }
}