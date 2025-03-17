using System;
using BTree;
using UnityEngine;

namespace Project.BTree
{
    public class CharacterThinker : AThinker
    {
        public GameObject bullet;

        private void CallBullet()
        {
            var bulleton = Instantiate(bullet, transform.position, Quaternion.identity);
            
        }
    }
}
