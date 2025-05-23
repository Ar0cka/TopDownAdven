using System;
using DefaultNamespace.Enums;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class ItemData
    {
        public string nameItem;
        public int maxStackInSlot;
        public ItemTypes itemTypes;
        
        public Sprite iconItem;
        public GameObject prefabItem;
    }
}