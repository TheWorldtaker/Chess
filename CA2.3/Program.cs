using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2._3
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[,] b = new int[8, 8];
            sbyte[] a =
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 1-10
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 11-20
                0, 1, 1, 3, -2, 1, 1, 1, 1, 0, // 21-30
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0, // 31-40
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0, // 41-50
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0, // 51-60
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0, // 61-70
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0, // 71-80
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0, // 81-90
                0, 1, 1, 3, 2, 1, 1, 1, 1, 0, // 91-100
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 101-110
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0  // 111-120
            };
            //string u = "Введено";



            //постановка фигуры на поле
            

            PP[] tes = new PP[5];
            tes[0].name = "W_KING";
            tes[0].pos = 95;
            tes[0].color = "WHITE";
            tes[0].stat = true;
            tes[0].id = 2;
            tes[0].cost = 0;


            tes[1].name = "B_KING";
            tes[1].pos = 25;
            tes[1].color = "BLACK";
            tes[1].stat = true;
            tes[1].id = -2;
            tes[1].cost = 0;

            tes[2].name = "W_KNIGHT";
            tes[2].pos = 94;
            tes[2].color = "WHITE";
            tes[2].stat = true;
            tes[2].id = 3;
            tes[2].cost = 2;

            tes[3].name = "B_KNIGHT";
            tes[3].pos = 23;
            tes[3].color = "BLACK";
            tes[3].stat = true;
            tes[3].id = 3;
            tes[3].cost = 2;




            /*Piece W_KING = new Piece();
            W_KING.pos = 95;
            W_KING.color = "WHITE";
            W_KING.stat = true;
            W_KING.id = 2;*/


            //var sp = from Piece1 in Piece where Piece.pos = 23 select Piece1;

            //флаг для переключения очереди ходов между цветами
            bool color_move = true;

            link1:
            byte l = 0;
            //ввод позиции фигуры
            Console.WriteLine("Введите позицию фигуры");
            sbyte f_ep = sbyte.Parse(Console.ReadLine());

            //ep - это желаемая позиция на которую необходимо поставить фигуру
            sbyte ep = 21;
            Console.WriteLine("Введите позицию на которую сделать ход");
            int CC = Int32.Parse(Console.ReadLine());
            ep = Convert.ToSByte(CC);


            //флаг - есть ли такая фигура на указанной позиции
            bool correct = false;
            //флаг - позиции в поле или за полем
            bool bp = false;
            //флаг - по правилам ли ходит фигура
            bool Ok_pm = false;
            Piece Move1 = new Piece();
            //поиск фигуры по позиции
            for (int i = 0; i < tes.Length; i++)
            {
                if (tes[i].pos == f_ep)
                {
                    correct = true;
                    if (color_move == true && tes[i].color == "WHITE")
                    {
                        ep -= tes[i].pos;
                        //проверка хода по соответствию фигуры
                        Move1.Move(tes[i].name, ep,ref Ok_pm);
                        if (Ok_pm == false)
                        {
                            Console.WriteLine("Фигура так не ходит!");
                            goto link1;
                        }
                        else if (Ok_pm == true)
                        {
                            //проверка на выход за пределы доски
                            Move1.ob(ref tes[i].pos, tes[i].id,ep,ref a,f_ep,ref bp,tes.Length, tes[i].color, tes);
                            if (bp == true)
                            {
                                color_move = true;
                                goto link1;
                            }
                        }
                        color_move = false;
                    }
                    else if (color_move == false && tes[i].color == "BLACK")
                    {
                        ep -= tes[i].pos;
                        //проверка хода по соответствию фигуры
                        Move1.Move(tes[i].name, ep,ref Ok_pm);
                        if (Ok_pm == false)
                        {
                            Console.WriteLine("Фигура так не ходит!");
                            goto link1;
                        }
                        else if (Ok_pm == true)
                        {
                            //проверка на выход за пределы доски
                            Move1.ob(ref tes[i].pos, tes[i].id, ep, ref a, f_ep, ref bp, tes.Length, tes[i].color, tes);
                            if (bp == true)
                            {
                                color_move = false;
                                goto link1;
                            }
                        }
                            color_move = true;
                    }
                    else
                    {
                        Console.WriteLine("Сейчас ходит не этот цвет фигур!");
                        goto link1;
                    }
                    break;
                }
                else if (i > tes.Length)
                {
                    Console.WriteLine("Не верная фигура!");
                    break;
                }
            }
            //if (u == "Введено")
            if (correct == true && Ok_pm == true)
            {
                //вывод доски в консоль
                //byte l = 0;
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(a[l++]);
                        Console.Write("  ");
                    }
                    Console.WriteLine();
                }
                goto link1;
            }
            else
            {
                Console.WriteLine("Были введены не верные значения");
                goto link1;
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
