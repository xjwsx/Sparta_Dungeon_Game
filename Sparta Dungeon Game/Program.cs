using System;
using System.Xml.Linq;

namespace Sparta_Dungeon_Game
{
    public class Item
    {
        public bool Eqbool { get; set; }
        public string Name { get; set;}
        public string Characteristic { get; set; }
        public int Def { get; set; }
        public int Atk { get; set; }
        public Item(string name, string characteristic, int def, int atk)
        {
            Name = name;
            Characteristic = characteristic;
            Def = def;
            Atk = atk;
        }
    }
    public class Character
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
    public class Program
    {
        private static Character player;
        private static Item item;
        static List<Item> itemList = new List<Item>();
        

        public static void DisplayGameInfo()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            int input = CheckValidInput(1, 2);
            switch(input)
            {
                case 1:
                    DisplayMyInfo(); 
                    break;
                case 2:
                    DisplayInvantory();
                    break;
            }
        }
        public static void DisplayMyInfo()
        {
            int totalAtk = player.Atk;
            int totalDef = player.Def;
            Console.Clear();
            foreach (Item eqItem in itemList)
            {
                if (eqItem.Eqbool)
                {
                    totalAtk += item.Atk;
                    totalDef += item.Def;
                }
            }
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ({player.Job})");
            Console.WriteLine($"공격력 : {player.Atk} (+{totalAtk - player.Atk})");
            Console.WriteLine($"방어력 : {player.Def} (+{totalDef - player.Def})");
            Console.WriteLine($"체  력 : {player.Hp}");
            Console.WriteLine($"Gold   : {player.Gold}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameInfo();
                    break;
            }
        }
        public static void DisplayInvantory()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (Item eqItem in itemList)
            {
                string CompleteEq = eqItem.Eqbool ? "E" : " ";
                Console.Write($"-  {CompleteEq}  장비 이름:{eqItem.Name}   ㅣ");
                Console.Write($"장비 공격력:{eqItem.Atk}   ㅣ");
                Console.Write($"장비 방어력:{eqItem.Def}   ㅣ");
                Console.WriteLine($"장비 설명:{eqItem.Characteristic}   ㅣ");
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameInfo();
                    break;
                case 1:
                    DisplayEquipment();
                    break;
            }

        }
        public static void DisplayEquipment()
        {
            int itemCount = 1;
            Console.Clear();

            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (Item eqItem in itemList)
            {
                string CompleteEq = eqItem.Eqbool ? "E" : " ";
                Console.Write($"- {itemCount} {CompleteEq}  장비 이름:{eqItem.Name}   ㅣ"); 
                Console.Write($"장비 공격력:{eqItem.Atk}   ㅣ"); 
                Console.Write($"장비 방어력:{eqItem.Def}   ㅣ"); 
                Console.WriteLine($"장비 설명:{eqItem.Characteristic}   ㅣ");
                itemCount++;
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("장착할장비 번호 입력해주세요");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");
            
            while (true)
            {
                int input = int.Parse(Console.ReadLine()) - 1;

                if (input >= 0)
                {
                    if (itemList.Count > input)
                    {
                        if (itemList[input].Eqbool == false)
                        {
                            itemList[input].Eqbool = true;
                            player.Def += itemList[input].Def;
                            player.Atk += itemList[input].Atk;
                        }
                        else
                        {
                            itemList[input].Eqbool = false;
                            player.Def -= itemList[input].Def;
                            player.Atk -= itemList[input].Atk;
                        }
                        DisplayEquipment();
                    }
                }
                else
                {
                    DisplayInvantory();
                }
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
        public static void GameDataSetting()
        {
            player = new Character("Chad", "전사", 01, 10, 5, 100, 1500);
            item = new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷 입니다.", 5, 0);
            itemList.Add(item);
            item = new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 0, 2);
            itemList.Add(item);
            item = new Item("청동 검", "날카로운 검 입니다.", 0, 5);
            itemList.Add(item);

        }
        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out int ret);
                if(parseSuccess)
                {
                    if(ret >= min && ret <= max)
                    {
                        return ret;
                    }
                }
                Console.WriteLine("잘못된 입력입니다.") ;
            }
        }
        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameInfo();
        }
    }
}