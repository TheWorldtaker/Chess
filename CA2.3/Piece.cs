using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2._3
{
    public struct PP
    {
        public string name;
        public sbyte pos;
        public string color;
        public bool stat;
        public sbyte id;
        public short cost;
    }
    public class Piece
    {
        public void Move(string name, sbyte ep,ref bool Ok_pm)
        {
            sbyte[] pm_king = { +11, +10, +9, +1, -1, -9, -10, -11 };
            sbyte[] pm_knigth = { };
            //проверка хода по соответствию фигуры
            switch (name)
            {
                case "W_KING":
                case "B_KING":
                    for (int j = 0; j < pm_king.Length; j++)
                    {
                        if (ep == pm_king[j])
                        {
                            Ok_pm = true;
                            break;
                        }
                        else if (j == pm_king.Length)
                        {
                            Console.WriteLine("Фигура так не ходит!");
                            Ok_pm = false;
                        }
                    }
                    break;
                case "W_KNIGHT":
                case "B_KNIGHT":
                    for (int j = 0; j < pm_knigth.Length; j++)
                    {
                        if (ep == pm_knigth[j])
                        {
                            Ok_pm = true;
                            break;
                        }
                        else if (j == pm_knigth.Length)
                        {
                            Console.WriteLine("Фигура так не ходит!");
                            Ok_pm = false;
                        }
                    }
                    break;
                    //Move1.Move(tes[i].name, ep, pm_king, Ok_pm);
            }
        }
        //проверка на выход за пределы доски и далее для проверки съедания и прохода
        public void ob(ref sbyte f_pos, sbyte tes_id, sbyte ep, ref sbyte[] a, sbyte f_ep, ref bool bp,int tesL,string tescolor,PP[] tes)
        {
            bool gp = true;
            sbyte f_pos1 = f_pos;
            //желаемая позиция
            f_pos1 += ep;
            for (int k = 0; k < a.Length; k++)
            {
                //проверка на выход за пределы доски
                if (k == f_pos1 - 1 && a[k] != 0)
                {
                    for (int w = 0; w < tesL; w++)
                    {
                        if (a[k] != 1 && tes[w].pos == f_pos1)
                        {
                            if (tes[w].color != tescolor)
                            {
                                gp = true;
                                break;
                            }
                            else if (tes[w].color == tescolor)
                            {
                                Console.WriteLine("На этой позиции находится своя фигура! Ход не возможен!");
                                gp = false;
                                bp = true;
                                break;
                            }
                        }
                    }
                    if (gp)
                    {
                        f_pos += ep;
                        a[k] = tes_id;
                        a[f_ep - 1] = 1;
                        break;
                    }
                }
                else if (k == f_pos1 - 1 && a[k] == 0)
                {
                    Console.WriteLine("Выход за границу поля!");
                    bp = true;
                    break;
                }
                if (bp == true) break;
            }
        }
        //Piece Move Board
        /*public void PMB(string name, sbyte ep, sbyte tespos, sbyte[] pm_king, bool Ok_pm)
        {
            sbyte f_pos = tespos;
            f_pos += ep;
            for (int k = 0; k < a.Length; k++)
            {
                //проверка на выход за пределы доски
                if (k == f_pos - 1 && a[k] != 0)
                {
                    tes[i].pos += ep;
                    a[k] = tes[i].id;
                    a[f_ep - 1] = 1;
                    break;
                }
                else if (k == f_pos - 1 && a[k] == 0)
                {
                    Console.WriteLine("Выход за границу поля!");
                    //break;
                    goto link1;
                }
            }*/
    }
}
