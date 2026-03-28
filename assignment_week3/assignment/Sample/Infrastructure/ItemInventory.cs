using assignment.Sample.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace assignment.Sample.Infrastructure
{
    public class ItemInventory : IInventory
    {
        private IPlayer _owner;
        private List<IItem> _items;
        /// <summary>
        /// 인벤토리 인터페이스 구현
        /// </summary>
        public void LoadInventory()
        {
            Console.WriteLine($"DB에서 [{_owner.ID}]의 인벤토리 정보를 불러옵니다. 현재 아이템 개수 : {_items.Count}");
        }
        public ItemInventory()  
        { 
            _items = new List<IItem>();
        }
        public void SetOwner(IPlayer player)
        {
            _owner = player;
        }
    }
}
