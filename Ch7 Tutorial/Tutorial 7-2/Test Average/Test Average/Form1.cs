﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        private const int SIZE = 40;
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            int[] scores = new int[SIZE];
            int highestScore = 0;
            int lowest = 0;
            double average = 0.0;
            int median = 0;
            GetScoresFromFile(scores);

            //for (int i = 0; i < scores.Length; i++)
            //{
            //    testScoresListBox.Items.Add(scores[i]);
            //}
            foreach(int value in scores)
            {
                testScoresListBox.Items.Add(value);
            }

            highestScore = Highest(scores);
            highScoreLabel.Text = highestScore.ToString();

            lowest = Lowest(scores);
            lowScoreLabel.Text = lowest.ToString();

            average = Average(scores);
            averageScoreLabel.Text = average.ToString();

            median = Median(scores);
            medianScoreLabel.Text = median.ToString();

        }

        private int Median(int[] scores)
        {
            Array.Sort(scores);
            for(int i = 0; i < scores.Length; i++)
                sortedScoresListBox.Items.Add("["+ i + "] :" + scores[i]);
            return scores[scores.Length/2];
        }

        private double Average(int[] scores)
        {
            int sum = 0;
            for (int i = 0;  i < scores.Length;  i++)
            {
                sum += scores[i];  // sum = sum + score[i]
            }
            //MessageBox.Show("SUM = " + sum);
            return (double)sum / scores.Length;  //casting
        }
        private int Lowest(int[] scores)
        {
            int lowest = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < lowest)
                {
                    lowest = scores[i];
                }
            }
            return lowest;
        }

        private int Highest(int[] scores)
        {
            int highest = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            return highest;
        }

        private void GetScoresFromFile(int[] scores)
        {
            StreamReader inputFile = null;
            int index = 0;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                inputFile = File.OpenText(openFile.FileName);

                while (!inputFile.EndOfStream && index < scores.Length )
                {
                    scores[index] = int.Parse(inputFile.ReadLine());
                    index++;
                }
            }
            else
            {
                MessageBox.Show("已取消");
            }
            inputFile.Close();
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
