﻿using System;

namespace WorkingWithNulls
{
    class PlayerCharacter
    {
        readonly SpecialDefence _specialDefence;
        public PlayerCharacter(SpecialDefence specialDefence)
        {
            _specialDefence = specialDefence;
        }

        public string Name { get; set; }
        public int Health { get; set; } = 100;

        public void Hit(int damage)
        {
            //int damageReduction = 0;


            //damageReduction = _specialDefence.CalculateDamageReduction(damage);

            //int totalDamageTaken = damage - damageReduction;
            int totalDamageTaken = damage - _specialDefence.CalculateDamageReduction(damage);

            Health -= totalDamageTaken;

            Console.WriteLine($"{Name}'s health has been reduced by {totalDamageTaken} to {Health}.");

        }
    }
}