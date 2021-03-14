using System;
class Matrix
{
    int[,] mat = new int[5, 5];
    public Matrix()
    {
        mat = new int[5, 5];
        Random rnd = new Random();

        for (int i = 0; i < 5; ++i)
            for (int j = 0; j < 5; ++j)
                this.mat[i, j] = rnd.Next(-100, 100);
    }
    public int this[int i, int j]
    {
        get { return mat[i, j]; }
        set { mat[i, j] = value; }
    }

    //Вывод матрицы
    public void Output()
    {
        for (int i = 0; i < 5; ++i)
        {
            for (int j = 0; j < 5; ++j)
            {
                Console.Write(mat[i, j] + "  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public override string ToString()
    {
        string strMatrix = "";
        for (int i = 0; i < 5; i++)
        {
            string str = "";
            for (int j = 0; j < 4; j++)
            {
                str += mat[i, j].ToString() + "  ";
            }
            str += mat[i, 4].ToString();
            if (i != 4 && i == 0)
                strMatrix += str + "\n";
            else if (i != 4 && i != 0)
                strMatrix += " " + str + "\n";
            else
                strMatrix += " " + str + "\n";
        }
        return strMatrix;
    }

    public override bool Equals(object obj)
    {
        return (obj is Matrix) && this.Equals((Matrix)obj);
    }

    public bool Equals(Matrix m)
    {
        return mat == m.mat;
    }

    public override int GetHashCode()
    {
        return mat.GetHashCode();
    }

    //Сложение
    public static Matrix operator +(Matrix left, Matrix right)
    {
        Matrix Value = new Matrix();
        for (int i = 0; i < 5; ++i)
            for (int j = 0; j < 5; ++j)
                Value[i, j] = left[i, j] + right[i, j];
        return Value;
    }

    //Вычитание
    public static Matrix operator -(Matrix left, Matrix right)
    {
        Matrix Value = new Matrix();
        for (int i = 0; i < 5; ++i)
            for (int j = 0; j < 5; ++j)
                Value[i, j] = left[i, j] - right[i, j];
        return Value;
    }

    //Умножение
    public static Matrix operator *(Matrix left, Matrix right)
    {
        Matrix Value = new Matrix();
        for (int i = 0; i < 5; ++i)
            for (int j = 0; j < 5; ++j)
            {
                Value[i, j] = 0;
                for (int k = 0; k < 5; ++k)
                    Value[i, j] += left[i, k] * right[k, j];
            }
        return Value;
    }

    //Неравенство
    public static bool operator !=(Matrix left, Matrix right)
    {
        bool Value = false;
        for (int i = 0; i < 5; ++i)
            for (int j = 0; j < 5; ++j)
                if (left[i, j] != right[i, j]) Value = true;
        return Value;
    }

    //Равенство
    public static bool operator ==(Matrix left, Matrix right)
    {
        bool Value = false;
        for (int i = 0; i < 5; ++i)
            for (int j = 0; j < 5; ++j)
                if (left[i, j] != right[i, j]) Value = true;
        return Value;
    }
}


class Program
{
    static void Main()
    {
        Matrix one = new Matrix();
        one.Output();
        Matrix two = new Matrix();
        Console.WriteLine(two.ToString());
        _ = new Matrix();
        Matrix three = one * two;
        Console.WriteLine(three.ToString());
        if (one != two) Console.WriteLine("Da");
    }
}


