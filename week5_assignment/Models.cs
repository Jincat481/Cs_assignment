using System;
using System.Collections.Generic;
using System.Text;

namespace week5_assignment.Models
{
    public interface IModel
    {
        public abstract string GetData();
        public abstract void LoadData();
        public void LoadData(int Count)
        {
            for (int i = 0; i < Count; i++) LoadData();
        }
        public abstract event Action OnDataChanged;
    }
    /// <summary>
    /// 가챠에서 뽑은 아이템을 저장하는 모델
    /// </summary>
    public class ItemModel : IModel
    {
        public ItemModel() { }
        private string itemData = string.Empty;
        private readonly List<string> savedResults = new();  // 결과 저장 리스트
        public event Action? OnDataChanged;
        public string GetData() => itemData;
        public void LoadData()
        {
            itemData = "Item data loaded at " + DateTime.Now.ToString();
            OnDataChanged?.Invoke(); // Model 변경 -> 이벤트 발생
        }

        public void SaveResult(string Result)
        {
            savedResults.Add(Result);

            itemData = $"저장 완료";
            OnDataChanged?.Invoke();
        }

        // 저장된 결과 불러오기
        public void LoadSavedResults()
        {
            itemData = savedResults.Count == 0 ? "저장된 기록이 없습니다." : string.Join("\n", savedResults);
            OnDataChanged?.Invoke();
        }
    }

    /// <summary>
    /// 가챠 모델 기능으로는 1뽑과 10뽑이 있으며, 아이템 종류와 확률은 itemPool에서 관리함.
    /// </summary>
    public class GachaModel : IModel
    {
        private string gachaResult = string.Empty;
        public event Action? OnDataChanged;

        /// <summary>
        /// 아이템 종류를 추가하거나 확률을 바꾸려면 itempool만 수정하면 됨.
        /// </summary>
        private readonly List<(string Name, int Weight)> itemPool = new()
    {
        ("\n★★★★★ 전설 아이템", 5),
        ("\n★★★★  희귀 아이템",  15),
        ("\n★★★   일반 아이템",  80),
    };

        public string GetData() => gachaResult;

        public void LoadData()
        {
            gachaResult = OnePull();
            OnDataChanged?.Invoke();
        }
        public void LoadData(int Count)
        {
            gachaResult = MultiPull(Count);
            OnDataChanged?.Invoke();
        }
        private string OnePull()
        {
            var random = new Random();
            int totalWeight = itemPool.Sum(Item => Item.Weight);
            int roll = random.Next(totalWeight);

            int cumulative = 0;
            foreach (var (name, weight) in itemPool)
            {
                cumulative += weight;
                if (roll < cumulative) return name;
            }
            return itemPool.Last().Name;
        }

        private string MultiPull(int count)
        {
            var results = new List<string>();
            for (int i = 0; i < count; i++)
            {
                results.Add(OnePull());
            }
            return results.Count > 1 ? string.Join(", ", results) : results[0];
        }
    }
}
