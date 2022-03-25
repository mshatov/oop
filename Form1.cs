using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz
{
    public partial class Form1 : Form
    {
        //ArrayList a1 = new ArrayList();
        //List<string> arr = new List<string>();

        List<List<string>> questions = new List<List<string>>()
        {   
            new List<string> { "Какое национальное животное Австралии?", "0010", "Коала", "Утконос", "Красный кенгуру", "Медведь" },
            new List<string> { "Сколько дней нужно, чтобы Земля совершила оборот вокруг Солнца?", "0100", "380", "365", "360", "381" },
            new List<string> { "В какой из следующих империй не было письменности", "001", "Ацтеков", "Римлян", "Инков" },
            new List<string> { "В какой стране самая длинная береговая линия в мире?", "01", "Россия", "Канада" },
            new List<string> { "Что делает команда git branch?", "0011", "Выводит изменения между локальной и удаленной версией текущей ветки",
                                                                         "Переключается на ветку, имя которой указано в качестве аргумента",
                                                                         "Выводит список веток текущего репозитория",
                                                                         "Создает новую ветку с именем, которое указано в качестве аргумента" },
        };

        Dictionary<int, string> answers = new Dictionary<int, string>();
        int totalQuestions;
        int currentQuestion = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void initAnswers(int n)
        {
            for (int i = 0; i < n; i++)
            {
                answers.Add(i, "0");
            }
        }


        private void addRadio(int n)
        {
            for (int i = 0; i < questions[n][1].Length; i++)
            {
                RadioButton btn = new RadioButton() {
                    Text = questions[n][2 + i],
                    Location = new Point(80, 40 * i + 200),
                    AutoSize = true
                };
                this.Controls.Add(btn);
                
            }
        }

        private void addCheck(int n)
        {
            for (int i = 0; i < questions[n][1].Length; i++)
            {
                CheckBox chb = new CheckBox()
                {
                    Text = questions[n][2 + i],
                    Location = new Point(80, 40 * i + 200),
                    Width = 500
                };
                this.Controls.Add(chb);

            }
        }

        private bool isMultipleAnswer (int n)
        {
            string selector = questions[n][1];
            int sum = 0;

            for (int i = 0; i < selector.Length; i++)
            {
                int current = (int)Char.GetNumericValue(selector[i]);
                sum += current;
            }

            return sum != 1;
        }

        private void addControls(int n)
        {
            if (isMultipleAnswer(n))
            {
                addCheck(n);
            }
            else
            {
                addRadio(n);
            }
        }

        public void removeControls(int n)
        {
            if (isMultipleAnswer(n))
            {
                foreach (Control checkBox in Controls.OfType<CheckBox>().ToList())
                {
                    Controls.Remove(checkBox);
                }
            }
            else
            {
                foreach (Control radioButton in Controls.OfType<RadioButton>().ToList())
                {
                    Controls.Remove(radioButton);
                }
            }

        }

        private bool isAnswered(int n)
        {
            return !(answers[n] == "0");
        }

        private void setAnswers(int n)
        {
            int i = 0;
            foreach (Control selector in Controls.OfType<CheckBox>().ToList())
            {
                CheckBox checkBox = (CheckBox)selector;
                if (answers[n][i] == '1')
                {
                    checkBox.Checked = true;
                }
                i++;
            }
            foreach (Control selector in Controls.OfType<RadioButton>().ToList())
            {
                RadioButton radioButton = (RadioButton)selector;
                if (answers[n][i] == '1')
                {
                    radioButton.Checked = true;
                }
                i++;
            }
        }

        private void askQuestion(int n)
        {
            btnPrev.Enabled = !(n == 0);
            btnNext.Enabled = !(n == totalQuestions - 1);

            lblCurrent.Text = Convert.ToString(n + 1);
            txtQuestion.Text = questions[n][0];
            addControls(n);

            if (isAnswered(n)) setAnswers(n);
        }

        private void writeAnswer(int n)
        {
            string answer = "";
            foreach (Control selector in Controls.OfType<RadioButton>().ToList())
            {
                RadioButton radioButton = (RadioButton)selector;
                answer += radioButton.Checked ? "1" : "0";
            }
            foreach (Control selector in Controls.OfType<CheckBox>().ToList())
            {
                CheckBox checkBox = (CheckBox)selector;
                answer += checkBox.Checked ? "1" : "0";
            }

            answers[n] = answer;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            totalQuestions = questions.Count;
            lblTotal.Text = Convert.ToString(totalQuestions);
            initAnswers(totalQuestions);
            askQuestion(currentQuestion);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            writeAnswer(currentQuestion);
            removeControls(currentQuestion);
            currentQuestion++;
            askQuestion(currentQuestion);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            writeAnswer(currentQuestion);
            removeControls(currentQuestion);
            currentQuestion--;
            askQuestion(currentQuestion);
        }

        private void checkAnswers()
        {
            int score = 0;
            for (int i = 0; i < answers.Count; i++)
            {
                string current = answers[i];
                score += current == questions[i][1] ? 1 : 0;
            }
            MessageBox.Show("Правильных ответов: " + Convert.ToString(score), "Результаты теста");
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            writeAnswer(currentQuestion);
            checkAnswers();
        }
    }
}
