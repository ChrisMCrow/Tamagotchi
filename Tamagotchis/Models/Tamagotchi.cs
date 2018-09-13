using System;
using System.Collections.Generic;

namespace Tamagotchis.Models
{
    public class Tama
    {
        private string _name;
        private int _hunger;
        private int _sleep;
        private int _attention;
        private int _id;
        private int _food;
        private bool _dead;
        private string _img;
        private static List<Tama> _allTama = new List<Tama> {};
        public Random stat = new Random();

        public Tama(string name)
        {
            _name = (name == "") ? "Tamagotchi" : name;
            _hunger = stat.Next(3, 8);
            _sleep = stat.Next(3, 8);
            _attention = stat.Next(3, 8);
            _food = stat.Next(1,4);
            _allTama.Add(this);
            _id = _allTama.Count;
            _img = stat.Next(1,599) + ".png";
            _dead = false;
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
        public int GetFood()
        {
            return _food;
        }
        public bool IsDead()
        {
            return _dead;
        }
        public string GetImg()
        {
            return _img;
        }

        public void Feed()
        {
            _hunger += (_hunger < 10 && _hunger > 0 && _food > 0) ? 1 : 0;
            _food -= (_food > 0) ? 1 : 0;
        }

        public void MakeSleep()
        {
            _sleep += (_sleep < 10 && _hunger > 0) ? 1 : 0;
            _hunger--;
        }

        public void Play()
        {
            _attention += (_attention < 10 && _hunger > 0) ? 2 : 0;
            _hunger--;
            _sleep--;
        }

        public static void CheckForDead()
        {
            foreach (Tama egg in _allTama)
            {
                if (egg._hunger <= 0 || egg._sleep <= 0 || egg._attention <= 0)
                {
                    egg._dead = true;
                }
            }
        }

        public static void Time()
        {
            foreach (Tama egg in _allTama)
            {
                egg._hunger--;
                egg._sleep--;
                egg._attention--;
                egg._food += (egg._food <= 7) ? 2 : 0;
            }
        }

    }
}
