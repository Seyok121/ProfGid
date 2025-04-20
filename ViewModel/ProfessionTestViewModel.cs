using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ProfGid.Model;

namespace ProfGid.ViewModel
{
    public class ProfessionTestViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<string, int> _results = new();
        private int _currentQuestionIndex = 0;

        private Answer _selectedAnswer;
        public Answer SelectedAnswer
        {
            get => _selectedAnswer;
            set
            {
                if (_selectedAnswer != null)
                    _selectedAnswer.IsSelected = false;

                _selectedAnswer = value;

                if (_selectedAnswer != null)
                    _selectedAnswer.IsSelected = true;

                IsAnswerSelected = _selectedAnswer != null;
                OnPropertyChanged();
                ((Command)NextCommand).ChangeCanExecute();
                ((Command)FinishCommand).ChangeCanExecute();
            }
        }

        private bool _isAnswerSelected;
        public bool IsAnswerSelected
        {
            get => _isAnswerSelected;
            set
            {
                _isAnswerSelected = value;
                OnPropertyChanged();
                ((Command)NextCommand).ChangeCanExecute();
                ((Command)FinishCommand).ChangeCanExecute();
            }
        }

        public ObservableCollection<Answer> CurrentAnswers => new ObservableCollection<Answer>(CurrentQuestion.Answers);

        public ObservableCollection<Question> Questions { get; }
        public Question CurrentQuestion => Questions[CurrentQuestionIndex];

        public int CurrentQuestionIndex
        {
            get => _currentQuestionIndex;
            set
            {
                _currentQuestionIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentQuestion));
                OnPropertyChanged(nameof(CurrentAnswers));
                OnPropertyChanged(nameof(IsNotLastQuestion));
                OnPropertyChanged(nameof(IsLastQuestion));
            }
        }

        public bool IsNotLastQuestion => CurrentQuestionIndex < Questions.Count - 1;
        public bool IsLastQuestion => !IsNotLastQuestion;

        public ICommand NextCommand { get; }
        public ICommand FinishCommand { get; }
        public ICommand ReturnToMainCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProfessionTestViewModel()
        {
            Questions = new ObservableCollection<Question>(LoadQuestions());
            InitializeResults();

            NextCommand = new Command(
                execute: () => ExecuteNextCommand(),
                canExecute: () => IsAnswerSelected);

            FinishCommand = new Command(
                execute: ExecuteFinishCommand,
                canExecute: () => IsAnswerSelected);
            ReturnToMainCommand = new Command(async () =>
            {
                await ResetAndReturnToMain();
            });
        }

        private List<Question> LoadQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Text = "Какой вид деятельности вам больше нравится?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Анализ защищенности компьютерных систем", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Работа с финансовыми отчетами", ProfessionName = "Экономика и бухгалтерский учет" },
                        new Answer { Text = "Написание программного кода", ProfessionName = "Информационные системы и программирование" },
                        new Answer { Text = "Создание визуальных концепций", ProfessionName = "Дизайн" }
                    }
                },
                new Question
                {
                    Text = "Какой школьный предмет вам нравился больше всего?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Информатика ", ProfessionName = "Информационные системы и программирование" },
                        new Answer { Text = "Экономика ", ProfessionName = "Экономика и бухгалтерский учёт" },
                        new Answer { Text = "Черчение", ProfessionName = "Землеустройство" },
                        new Answer { Text = "Право", ProfessionName = "Юриспруденция" }
                    }
                },
                new Question
                {
                    Text = "Какой тип задач вас увлекает?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Поиск уязвимостей в системах", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Оптимизация бюджетов", ProfessionName = "Финансы" },
                        new Answer { Text = "Общение с клиентами", ProfessionName = "Торговое дело" },
                        new Answer { Text = "Разработка интерфейсов", ProfessionName = "Дизайн" }
                    }
                },
                new Question
                {
                    Text = "Ваш идеальный рабочий день:",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Аудит IT-инфраструктуры", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Составление баланса", ProfessionName = "Экономика и бухгалтерский учёт" },
                        new Answer { Text = "Полевые измерения участков", ProfessionName = "Землеустройство" },
                        new Answer { Text = "Консультирование покупателей", ProfessionName = "Продавец" }
                    }
                },
                new Question
                {
                    Text = "Что вам ближе?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Криптография", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Налоговое планирование", ProfessionName = "Финансы" },
                        new Answer { Text = "Ведение переговоров", ProfessionName = "Торговое дело" },
                        new Answer { Text = "Работа с графическими редакторами", ProfessionName = "Дизайн" }
                    }
                },
                new Question
                {
                    Text = "Ваша сильная сторона:",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Аналитическое мышление", ProfessionName = "Информационные системы и программирование" },
                        new Answer { Text = "Внимание к деталям", ProfessionName = "Экономика и бухгалтерский учёт" },
                        new Answer { Text = "Коммуникабельность", ProfessionName = "Торговое дело" },
                        new Answer { Text = "Креативность", ProfessionName = "Дизайн" }
                    }
                },
                new Question
                {
                    Text = "Какой проект вас заинтересует?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Настройка firewall", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Автоматизация учета", ProfessionName = "Экономика и бухгалтерский учёт" },
                        new Answer { Text = "Оформление земельного кадастра", ProfessionName = "Землеустройство" },
                        new Answer { Text = "Разработка фирменного стиля", ProfessionName = "Дизайн" }
                    }
                },
                new Question
                {
                    Text = "Предпочитаемая рабочая среда:",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Серверная", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Офис с документами", ProfessionName = "Юриспруденция" },
                        new Answer { Text = "Торговый зал", ProfessionName = "Продавец" },
                        new Answer { Text = "Студия с графическими планшетами", ProfessionName = "Дизайн" }
                    }
                },
                new Question
                {
                    Text = "Что важнее в работе?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Защита данных", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "Точность расчетов", ProfessionName = "Финансы" },
                        new Answer { Text = "Умение договариваться", ProfessionName = "Торговое дело" },
                        new Answer { Text = "Визуальная гармония", ProfessionName = "Дизайн" }
                    }
                },
                new Question
                {
                    Text = "Как вы принимаете решения?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "На основе анализа рисков", ProfessionName = "Обеспечение информационной безопасности" },
                        new Answer { Text = "По четким алгоритмам", ProfessionName = "Экономика и бухгалтерский учёт" },
                        new Answer { Text = "Учитывая мнение клиента", ProfessionName = "Торговое дело" },
                        new Answer { Text = "Ориентируясь на эстетику", ProfessionName = "Дизайн" }
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
                    if (!_results.ContainsKey(answer.ProfessionName))
                    {
                        _results[answer.ProfessionName] = 0;
                    }
                }
            }
        }

        public void AddScore(string profession)
        {
            if (_results.ContainsKey(profession))
            {
                _results[profession]++;
            }
        }
        public (string Profession, int Score) GetResult()
        {
            var result = _results.OrderByDescending(x => x.Value).First();
            return (result.Key, result.Value);
        }

        private void ExecuteNextCommand()
        {
            if (CurrentQuestionIndex < Questions.Count - 1)
            {
                CurrentQuestionIndex++;
                SelectedAnswer = null;
            }
        }

        private async void ExecuteFinishCommand()
        {
            var (profession, score) = GetResult();
            await Shell.Current.GoToAsync(
                $"//ProfessionTestResultPage?profession={Uri.EscapeDataString(profession)}");
            ResetTestData();
        }
        private async Task ResetAndReturnToMain()
        {
            ResetTestData();
            await Shell.Current.GoToAsync("//MainPage");
        }

        public void ResetTestData()
        {
            _results.Clear();
            InitializeResults(); // Восстанавливаем структуру
            CurrentQuestionIndex = 0;
            SelectedAnswer = null;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}