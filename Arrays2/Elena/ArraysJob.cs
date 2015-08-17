using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2.Elena
{
    class ArraysJob : IArraysJob
    {
        public bool JaggedArrayExchange(int[][] inputArray)
        {
            int firstLineLenth = inputArray[0].Length;
            bool thereIsLine=false;

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (firstLineLenth == inputArray[i].Length)

                {
                    int numberSerchLine=i;
                    int[] chengeArrey = new int[firstLineLenth];
                    for (int j = 0; j < firstLineLenth; j++)
                    {
                        chengeArrey[j] = inputArray[0][j];
                        inputArray[0][j] = inputArray[numberSerchLine][j];
                        inputArray[numberSerchLine][j] = chengeArrey[j];

                    }
                    thereIsLine = true;
                    break;
                }
            }

                return thereIsLine;
        }

        public int[][] LifeCalculations(int[][] inputArray)
        {
            int sum;
            int[][] newAray=new int[5][];
            for(int i=0; i<inputArray.Length;i++)
            {
                for(int j=0; j<inputArray[i].Length; j++)
                {
                    sum=0;
                    try 
                    {sum+=inputArray[i-1][j-1];}
                    catch
                    {sum+=0;}

                    try 
                    {sum+=inputArray[i-1][j];}
                    catch
                    {sum+=0;}
                    
                    try 
                    {sum+=inputArray[i-1][j+1];}
                    catch
                    {sum+=0;}

                    try 
                    {sum+=inputArray[i][j-1];}
                    catch
                    {sum+=0;}

                    try 
                    {sum+=inputArray[i][j+1];}
                    catch
                    {sum+=0;}

                    try 
                    {sum+=inputArray[i+1][j-1];}
                    catch
                    {sum+=0;}

                    try 
                    {sum+=inputArray[i+1][j];}
                    catch
                    {sum+=0;}

                    try 
                    {sum+=inputArray[i+1][j+1];}
                    catch
                    {sum+=0;}
                    
                    if(inputArray[i][j]==1&&(sum>3||sum<2))
                    {
                        newAray[i][j]=0;
                    }

                    else if(inputArray[i][j]==0&&sum==3)
                    {
                        newAray[i][j]=1;
                    }
                    else 
                    {
                        newAray[i][j]=inputArray[i][j];
                    }

                }
            }



            return newAray;
        }

        public int CalculateEqualPairs(int[] inputArray)
        {
            int countOfCouple=0;

            for (int i = 0; i < inputArray.Length-1; i++)
            {
                if (inputArray[i] == inputArray[i + 1])
                {
                    countOfCouple++;
                }
            }

                return countOfCouple;
        }
    }
}
