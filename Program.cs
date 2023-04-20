using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_7_7
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        class MyOrder
        {

            abstract class Delivery
            {
                public string AddressOfDelivery { get; set; }
                public string DeliveryName;
                public string CourierName;

                public Delivery(string DeliveryName, string CourierName, string AddressOfDelivery)
                {
                    this.DeliveryName = DeliveryName;
                    this.CourierName = CourierName;
                    this.AddressOfDelivery = AddressOfDelivery;
                }

                public abstract void OrderDelivery();
            }

            class HomeDelivery : Delivery
            {
                public string NameOfClient;
                public string AddressOfHome;

                public HomeDelivery(string DeliveryName, string CourierName, string AddressOfDelivery, string NameOfClient, string AddressOfHome) : base(DeliveryName, CourierName, AddressOfDelivery)
                {
                    this.NameOfClient = NameOfClient;
                    this.AddressOfHome = AddressOfHome;
                }

                public override void OrderDelivery()
                {
                    Console.WriteLine("Доставка выполнена по адресу" + AddressOfHome + ", Имя заказчика" + NameOfClient);
                }
            }

            class PickPointDelivery : Delivery
            {
                public DateTime TimeOfGetting;
                public string NameOfClient;
                public PickPointDelivery(string DeliveryName, string CourierName, string AddressOfDelivery, DateTime TimeOfGetting, string NameOfClient) : base(DeliveryName, CourierName, AddressOfDelivery)
                {
                    this.TimeOfGetting = TimeOfGetting;
                    this.NameOfClient = NameOfClient;
                }

                public override void OrderDelivery()
                {
                    Console.WriteLine("Доставка выполнена курьером" + NameOfClient + ", время доставки" + TimeOfGetting);
                    Console.WriteLine();
                }
            }

            class Menu
            {
                public string Name;              
            }

            class ShopDelivery : Delivery
            {
                private Menu[] ListMenu;

                public ShopDelivery(Menu[] ListMenu, string AddressOfDelivery, string DeliveryName, string CourierName) : base(DeliveryName, CourierName, AddressOfDelivery)
                {
                    this.ListMenu = ListMenu;
                }

                public Menu this[int index]
                {
                    get
                    {
                        if (index >= 0 && index < ListMenu.Length)
                        {
                            return ListMenu[index];
                        }
                        else
                        {
                            return null;
                        }
                    }
                    private set
                    {
                        if (index >= 0 && index < ListMenu.Length)
                        {
                            ListMenu[index] = value;
                        }
                    }
                }

                public Menu this[string name]
                {
                    get
                    {
                        for (int i = 0; i < ListMenu.Length; i++)
                        {
                            if (ListMenu[i].Name == name)
                            {
                                return ListMenu[i];
                            }
                        }
                        return null;
                    }
                }

                public override void OrderDelivery()
                {
                    Console.WriteLine("Список меню ресторана" + DeliveryName);
                }
            }

            class Order<TDelivery, TStruct> where TDelivery : Delivery
            {
                public TDelivery Delivery;
                public int Number;
                public string Description;

                public void DisplayAddress()
                {
                    Console.WriteLine(Delivery.AddressOfDelivery);
                }
                public string Name;
                public int PhoneNumber;
            }

            static class Kurier
            {
                public static string PhoneNumber;

                static Kurier()
                {
                    PhoneNumber = "7473282921";
                }
            }

            class Lottery
            {
                string[] lot = { "Car", "Travel", "Potato" };

                public virtual void SelectNumber()
                {
                    Console.WriteLine("Выберите выигрышный номер от 0,1,2");
                    string number = Console.ReadLine();
                    for (int i = 0; i < lot.Length; i++)
                    {
                        if (number == lot[i])
                        {
                            Console.WriteLine("Поздравляем с выигрышем " + lot[i]);
                        }
                    }
                }
            }

            class Win : Lottery
            {
                public override void SelectNumber()
                {
                    Console.WriteLine("Для следующего приза Вам необходимо выаолнить покупку на сумму 50.000 Р");
                }
            }

        }
    }
}
