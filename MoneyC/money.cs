using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
class Money
{
    public string inputstr;
    public char[] a;
    public void input()
    {
        inputstr = Interaction.InputBox("Введите все оценки", "Ввод оценок");
        a = inputstr.ToCharArray();
        

    }
}

class moneymain
{
    static void Main()
    {
       string a;
        a = Interaction.InputBox("Напишите 'averenge' если хотите узнать средний балл или 'money' что бы узнать количество денег", "Что вы хотите?");
        if (a == "money")
        {
            Money A = new Money();
            A.input();

        }

        else if(a == "averenge")
        {

        }
        else
        {
            MessageBox.Show("Error1 введено неверное значение", "Ошибка!");
        }
    }
}