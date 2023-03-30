using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Class1
    {
        public enum Enemy_Type
        {
            GLOBIN,
            BOSS,
            ORC
        }
        public enum Attack_Type { RANGE, MELEE }
        public interface IEnemy
        {
            long Id { get; set; }
            string Name { get; set; }
            Enemy_Type Type { get; set; }
            Attack_Type Attack { get; set; }
            int Health { get; set; }
            float Damage { get; }
            void ShowInfo();
        }
        public class Enemy : IEnemy
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public Enemy_Type Type { get; set; }
            public int Health { get; set; }
            public Attack_Type Attack { get; set; }
            public float Damage { get; set; }
            public static IEnumerable<Enemy> Values { get; internal set; }

            public Enemy(long id, string name, Enemy_Type type, int health, Attack_Type attack, float damage)
            {
                Id = id;
                Name = name;
                Type = type;
                Health = health;
                Attack = attack;
                Damage = damage;
            }

            public Enemy()
            {
            }

            public void ShowInfo()
            {
                Console.WriteLine("ID: {0}, Name: {1}, Type: {2}, Health: {3}, Attack: {4}, Damage", Id, Name, Type, Health, Attack, Damage);
            }
            List<float> DamageList = new List<float>();
            public float this [int index]
            {
                get { return DamageList[index]; }
                set { DamageList[index] = value; }
            }
            public void CalDamage()
            {
                float dmg = DamageList.Max();
                Damage = dmg;
            }

        }
    }
}
