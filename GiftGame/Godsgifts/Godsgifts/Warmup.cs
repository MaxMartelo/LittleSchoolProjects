namespace Godsgifts;

public class Warmup
{
    public static bool ReverseFile(string file)
    {
        
        if (!File.Exists(file))
            return false;
        else
        {
            StreamReader toRead = new StreamReader(file);
            string[] copy = File.ReadAllLines(file);
            toRead.Close();

            int len = copy.Length;
            for (int i = 0; i < len; i++)
            {
                string tmp = "";
                for (int j = copy[i].Length - 1; j >= 0; j--)
                {
                    tmp += copy[i][j];
                }

                copy[i] = tmp;
            }
            
            using (StreamWriter newFile = new StreamWriter("newFile.txt"))
            {
                
                for (int i = len - 1; i >= 0; i--)
                {
                     newFile.WriteLine(copy[i]);
                }
                
            }
            return true;
        }

    }

    public static bool MixFiles(string file1, string file2)
    {
        if (!File.Exists(file1) || !File.Exists(file2))
            return false;
        else
        {
            StreamReader toRead1 = new StreamReader(file1);
            string[] copyF1 = File.ReadAllLines(file1); 
            int len1 = copyF1.Length;
            toRead1.Close();

            StreamReader toRead2 = new StreamReader(file2);
            string[] copyF2 = File.ReadAllLines(file2); 
            int len2 = copyF2.Length;
            toRead2.Close();
            
            
            using (StreamWriter newFile = new StreamWriter("newFile.txt"))
            {
                if (len1 > len2)
                {
                    int i = 0;
                    for (; i < len2; i++)
                    {
                        newFile.WriteLine(copyF1[i]);
                        newFile.WriteLine(copyF2[i]);
                    }

                    for (; i < len1; i++)
                    {
                        newFile.WriteLine(copyF1[i]);
                    }
                }

                else if (len2 > len1)
                {
                    int i = 0;
                    for (; i < len1; i++)
                    {
                        newFile.WriteLine(copyF1[i]);
                        newFile.WriteLine(copyF2[i]);
                    }

                    for (; i < len2; i++)
                    {
                        newFile.WriteLine(copyF2[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < len1; i++)
                    {
                        newFile.WriteLine(copyF1[i]);
                        newFile.WriteLine(copyF2[i]);
                    }
                }
            }
            return true;
        }
        
    }

}