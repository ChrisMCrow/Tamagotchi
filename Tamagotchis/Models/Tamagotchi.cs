using System;
using System.Collections.Generic;

namespace Tamagotchis.Models
{
    public class Tama
    {
        private string _name;
        private int _hunger = 5;
        private int _sleep = 5;
        private int _attention = 5;
        private int _id;
        private static List<Tama> _allTama = new List<Tama> {};

        public Tama(string name)
        {
            _name = name;
            _allTama.Add(this);
            _id = _allTama.Count;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetHunger(int input)
        {
            _hunger = input;
        }
        public int GetHunger()
        {
            return _hunger;
        }
        public void SetSleep(int input)
        {
            _sleep = input;
        }
        public int GetSleep()
        {
            return _sleep;
        }
        public void SetAttention(int input)
        {
            _attention = input;
        }
        public int GetAttention()
        {
            return _attention;
        }
        public int GetId()
        {
            return _id;
        }
        public static Tama Find(int searchId)
        {
            return _allTama[searchId - 1];
        }
        public static List<Tama> GetAll()
        {
            return _allTama;
        }
        public static void ClearAll()
        {
            _allTama.Clear();
        }



        public void Feed()
        {
          // if (_hunger <= 10) {_hunger += 1};
          _hunger += (_hunger < 10 && _hunger > 0) ? 1 : 0;
        }

        public void MakeSleep()
        {
          _sleep += (_sleep < 10 && _hunger > 0) ? 1 : 0;
        }

        public void Play()
        {
          _attention += (_attention < 10 && _hunger > 0) ? 1 : 0;
        }

        public static void ClearDeadTama()
        {
            foreach (Tama egg in _allTama)
            {
                if (egg._hunger <= 0 || egg._sleep <= 0 || egg._attention <= 0)
                {
                    egg._hunger = 0;
                    egg._sleep = 0;
                    egg._attention = 0;
                }
            }
        }


        public static void Time()
        {
            foreach (Tama egg in _allTama)
            {
                egg._hunger -= 1;
                egg._sleep -= 1;
                egg._attention -= 1;
            }
        }

    }
}
