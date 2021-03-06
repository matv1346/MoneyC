using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
public class Money
{

    public string inputstr;                                                  // Ввод всех оценок
    public char[] allmarks;
    public int[] marks = new int[6];                                        // Массив для храниния обработанных оценок и результата
    protected int[] allmarksInt;                                            // Массив для проверки првильности ввода
    public bool stateTclose = false;
    public Money()
    {
        inputstr = "2345";
       

    }
    public void input()
    {
       mylabel1:
        inputstr = Interaction.InputBox("Введите все оценки, для выхода введите 'exit' ", "Ввод оценок");// Вводим оценки
        allmarks = inputstr.ToCharArray();                                   // И конвертируем их в массив символов
        allmarksInt = Array.ConvertAll(allmarks, c => (int)Char.GetNumericValue(c)); // заполняем массив инт конвертируя чар
            try                                                                  // try
                {
                    for (int i = 0; i < inputstr.Length; i++)
                    {
                        if (allmarksInt[i] > 5 || allmarksInt[i] <= 1 || allmarksInt[i] == '\0')
                        {
                            throw new Exception("Вводите только числа 2,3,4,5");       //Генерируется исключение
                        }
                    }

                }

            catch (Exception e)
        {      
            if (inputstr == "exit") { stateTclose = true; }
                else
                {
                    MessageBox.Show(e.Message);
                goto mylabel1;
                }
        }
        
           
    }

    public void math(string h) {
        inputstr = h;                                                         //нужно для юнит теста
        allmarks = inputstr.ToCharArray();                                    //
        for (int i = 0; i < inputstr.Length; i++)
        {
            switch (allmarks[i])                                        //Ищем количество каждой оценки
            {
                case '5':
                    marks[5]++;
                    break;
                case '4':
                    marks[4]++;
                    break;
                case '3':
                    marks[3]++;
                    break;
                case '2':
                    marks[2]++;
                    break;
            }
        }
        marks[0] = (marks[2]*(-100)) + (marks[3]*(-50)) + (marks[4]*50) + (marks[5]*100); // считаем результат
        string result = Convert.ToString(marks[0]);                                       // конвертируем результат в чар для вывода в мессадж бох
        MessageBox.Show(result, "Your result: ");
    }

   
   

}

class Averenge : Money
{
    public Averenge()
    {
       
    }
    
    
    protected double[] allsum = new double[3];
    public void math()
    {
        for (int i = 0; i < inputstr.Length; i++)       //Складываем все оценки
        {
            allsum[0]+=allmarksInt[i];
        }
        allsum[1] = inputstr.Length;
        allsum[2] = allsum[0]/allsum[1];               //считаем их среднее арифметич
        string result = Convert.ToString(allsum[2]);
        MessageBox.Show(result, "Ваш средний балл");
    }

}

class moneymain
{
    
    static void Main()
    {
        mylabel2:
       string a;
        a = Interaction.InputBox("Напишите 'averenge' если хотите узнать средний балл или 'money' что бы узнать количество денег. Введите 'exit' для выхода", "Что вы хотите?");
        while (true)
        {
            if (a == "money")
            {
                Money money = new Money();
                money.input();
                if(money.stateTclose == true) { break; }
                money.math(money.inputstr);                 //A.inputstr возвращает значение inputstr в функцию math() для юнит теста
            }

            else if (a == "averenge")
            {
                Averenge AV = new Averenge();
                AV.input();
                AV.math();
            }
            else if (a == "exit"){break;}
            else 
            {
                MessageBox.Show("Error1 введено неверное значение", "Ошибка!");
                goto mylabel2;
               
            }
            
            
        }

    }


}