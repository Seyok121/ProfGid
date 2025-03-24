using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfGid.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ProfGid.ViewModel
{
    class ProfessionTestViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Question> Questions { get; }
        public Dictionary<string, int> Results { get; } = new();

        private int currentQuestionIndex;
        public int CurrentQuestionIndex
        {
            get { return currentQuestionIndex; }
            set
            {
                currentQuestionIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentQuestion));
                OnPropertyChanged(nameof(IsNotLastQuestion));
                OnPropertyChanged(nameof(IsLastQuestion));
            }
        }

        public Question CurrentQuestion => Questions[CurrentQuestionIndex];
        public bool IsNotLastQuestion => CurrentQuestionIndex < Questions.Count - 1;
        public bool IsLastQuestion => !IsNotLastQuestion;
        public ICommand NextCommand { get; }
        public ICommand FinishCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProfessionTestViewModel()
        {
            Questions = new ObservableCollection<Question>(LoadQuestions());
            InitializeResults();

            NextCommand = new Command(() => CurrentQuestionIndex++);
            FinishCommand = new Command(FinishTest);
        }
        private List<Question> LoadQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Text = "Какой тип задач вам интереснее?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Анализировать риски и угрозы", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Работать с цифрами и отчетами", ProfessionName = "Экономика и бухгалтерский учет" },
                        new Answer { Text = "Создавать программный код", ProfessionName = "Информационные системы и программирование" }
                    }
                },
                new Question
                {
                    Text = "Что вам ближе?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Черчение и работа с картами", ProfessionName = "Землеустройство" },
                        new Answer { Text = "Разработка визуальных концепций", ProfessionName = "Дизайн" },
                        new Answer { Text = "Общение с клиентами", ProfessionName = "Торговое дело" }
                    }
                },
                new Question
                {
                    Text = "Какой школьный предмет нравился больше?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Информатика", ProfessionName = "Программирование/Безопасность" },
                        new Answer { Text = "Право", ProfessionName = "Юриспруденция" },
                        new Answer { Text = "Экономика", ProfessionName = "Финансы/Бухучет" }
                    }
                },
                new Question
                {
                    Text = "Какую работу вы бы предпочли?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Проверка IT-систем на уязвимости", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Составление договоров", ProfessionName = "Юриспруденция" },
                        new Answer { Text = "Визуализация данных", ProfessionName = "Дизайн" }
                    }
                },
                new Question
                {
                    Text = "Ваш идеальный рабочий день:",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Аудит финансовой отчетности", ProfessionName = "Экономика и бухгалтерский учет" },
                        new Answer { Text = "Разработка мобильного приложения", ProfessionName = "Информационные системы и программирование" },
                        new Answer { Text = "Обмер земельных участков", ProfessionName = "Землеустройство" }
                    }
                },
                new Question
                {
                    Text = "Что вам интереснее изучать?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Криптографические алгоритмы", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Тренды графического дизайна", ProfessionName = "Дизайн" },
                        new Answer { Text = "Техники продаж", ProfessionName = "Торговое дело" }
                    }
                },
                new Question
                {
                    Text = "Ваша сильная сторона:",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Внимание к деталям", ProfessionName = "Бухучет/Финансы" },
                        new Answer { Text = "Креативное мышление", ProfessionName = "Дизайн" },
                        new Answer { Text = "Техническая логика", ProfessionName = "Программирование/Безопасность" }
                    }
                },
                new Question
                {
                    Text = "Какой проект вас увлечет?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Оптимизация налогов", ProfessionName = "Финансы" },
                        new Answer { Text = "Дизайн интерфейса", ProfessionName = "Дизайн" },
                        new Answer { Text = "Настройка сетевой защиты", ProfessionName = "Обеспечение информационной безопасности" }
                    }
                },
                new Question
                {
                    Text = "Ваша рабочая среда:",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Офис с графиками и отчетами", ProfessionName = "Бухучет" },
                        new Answer { Text = "Полевые измерения", ProfessionName = "Землеустройство" },
                        new Answer { Text = "Торговый зал", ProfessionName = "Продавец" }
                    }
                },
                new Question
                {
                    Text = "Что важнее в работе?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Стабильность и порядок", ProfessionName = "Экономика и бухгалтерский учет" },
                        new Answer { Text = "Возможность творчества", ProfessionName = "Дизайн" },
                        new Answer { Text = "Решение нестандартных задач", ProfessionName = "Информационные системы и программирование" }
                    }
                },
            };
        }

        private void InitializeResults()
        {
            foreach (var question in Questions)
            {
                foreach (var answer in question.Answers)
                {
                    if (!Results.ContainsKey(answer.ProfessionName))
                    {
                        Results[answer.ProfessionName] = 0;
                    }
                }
            }
        }
        public void AddScore(string profession)
        {
            Results[profession]++;
        }

        private async void FinishTest()
        {
            var topProfession = Results.OrderByDescending(x => x.Value).First();
            await Shell.Current.GoToAsync($"results?profession={topProfession.Key}&score={topProfession.Value}");
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
