using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using week5_assignment.Models;

namespace week5_assignment.Main
{
    /// <summary>
    /// View의 인터페이스 정의
    /// </summary>
    public interface IView
    {
        event Action<string> OnMenuSelected; // view -> presenter 이벤트
        void ShowData(string data);
        void ShowMenu();
    }

    public class View: IView
    {
        public event Action<string>? OnMenuSelected;
        public void ShowMenu()
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. 가챠 1뽑");
            Console.WriteLine("2. 가챠 10뽑");
            Console.WriteLine("3. 뽑기 기록 보기");
            Console.WriteLine("4. 종료");
            Console.Write("메뉴를 선택하세요: ");

            var input = Console.ReadLine() ?? string.Empty;
            OnMenuSelected?.Invoke(input);
        }
        public void ShowData(string data)
        {
            Console.WriteLine($"[결과] {data}");
        }
    }

    public class Presenter
    {
        private readonly ItemModel itemModel;
        private readonly GachaModel gachaModel;
        private readonly IView view;

        /// <summary>
        /// View 이벤트 <-> Model 메서드 바인딩
        /// </summary>
        public void Bind()
        {
            // view 이벤트 -> presenter 처리 메서드
            view.OnMenuSelected += HandleMenuSelected;

            // Model 이벤트 -> view 갱신 메서드
            itemModel.OnDataChanged += () => view.ShowData(itemModel.GetData());
            gachaModel.OnDataChanged += () => view.ShowData(gachaModel.GetData());
        }
        
        public void HandleMenuSelected(string menu)
        {
            switch (menu)
            {
                case "1":
                    gachaModel.LoadData();
                    itemModel.SaveResult(gachaModel.GetData()); // 1뽑 결과 자동 저장
                    break;
                case "2":
                    gachaModel.LoadData(10);
                    itemModel.SaveResult(gachaModel.GetData()); // 10뽑 결과 자동 저장
                    break;
                case "3":
                    itemModel.LoadSavedResults(); // 저장된 결과 불러오기
                    break;
                case "4":
                    Console.WriteLine("프로그램을 종료합니다.\n");
                    Environment.Exit(0);
                    break;
            }
        }
        public Presenter(ItemModel ItemModel, GachaModel GachaModel, IView View)
        {
            itemModel = ItemModel;
            gachaModel = GachaModel;
            view = View;

            Bind(); // 생성 시점에 모든 이벤트 바인딩
        }

        public void Run()
        {
            while(true) view.ShowMenu();
        }
    }
}
