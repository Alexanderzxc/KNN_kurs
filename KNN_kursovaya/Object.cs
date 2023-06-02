using KNN_kursovaya;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Введите радиус опухоли, периметр опухоли, количество соседей");
double rad = Convert.ToDouble(Console.ReadLine());
double per = Convert.ToDouble(Console.ReadLine());
int k = Convert.ToInt32(Console.ReadLine());

Object ob = new Object(rad, per,k);

DataGo dataGo = new DataGo();
dataGo.get_data();

ob.GetDist(dataGo.Data);

ob.Predict();

ob.Answer();


public class Object
{
    private double radius, texture, k;

    private List<string[]> distance = new List<string[]>();

    private List<string> diagnoses = new List<string>();

    public Object(double radius, double texture, int k)
    {
        this.radius = radius;
        this.texture = texture;
        this.k = k;
    }

    public void Answer()
    {
        int count_B=0, count_M=0;
        foreach (string s in diagnoses)
        {
            if (s == "B")
            {
                count_B++;
            }
            else
            {
                count_M++;
            }
        }
        if (count_B > count_M)
        {
            Console.WriteLine("Ваш диагноз доброкачественная опухоль");
        }
        else
        {
            Console.WriteLine("Ваш диагноз злокачественная опухоль");
        }
    }

    public void Predict()
    {
        for (int j = 0; j < k; j++)
        {
            double min = 100;
            int index = 0;
            for (int i = 0; i < distance.Count; i++)
            {
                if (Convert.ToDouble(distance[i][1]) < min)
                {
                    min = Convert.ToDouble(distance[i][1]);
                    index = i;
                }
            }
            diagnoses.Add(distance[index][0]);
            distance.RemoveAt(index);
        }
    }

    public void GetDist(List<string[]> q)
    {
        double d_1, d_2;
        for (int i = 0; i < q.Count; i++) 
        {
            string[] doubles = new string[2];
            d_1 = Math.Pow(radius - Convert.ToDouble(q[i][1].Replace(".",",")), 2);
            d_2 = Math.Pow(texture - Convert.ToDouble(q[i][2].Replace(".",",")), 2);
            string b = Convert.ToString(Math.Sqrt(d_1 + d_2));
            for (int j = 0; j < 2; j++)
            {
                doubles[0] = q[i][0];
                doubles[1] = b;
            }
            distance.Add(doubles);
        }
    }

}