﻿namespace ProfGid.View;
[QueryProperty(nameof(ProfessionName), "profession")]
public partial class ProfessionDetailsPage : ContentPage
{
    private string _professionName;
    public string ProfessionName
    {
        get => _professionName;
        set
        {
            _professionName = Uri.UnescapeDataString(value ?? string.Empty);
            OnPropertyChanged();
            LoadProfessionData();
        }
    }

    public ProfessionDetailsPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    private async void HomeButton_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
    private async void SpecialitiesButton_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//SpecialitiesPage");
    }
    private async void PhoneButton_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactsPage");
    }

    private void LoadProfessionData()
    {
        ProfessionNameLabel.Text = ProfessionName;

        var descriptions = new Dictionary<string, string>
        {
            {"Обеспечение информационной безопасности автоматизированных систем",
            "🔒 Специалист по кибербезопасности | Защита от хакерских атак\n\n" +
            "• Настройка firewall и систем мониторинга\n" +
            "• Анализ уязвимостей и расследование инцидентов\n" +
            "• Работа с Kali Linux, SIEM-системами\n\n" +
            "💼 Карьера: от junior-специалиста до руководителя SOC\n" +
            "💰 Зарплата: 90-150 тыс. руб.\n" +
            "🎓 Ключевые дисциплины: криптография, сетевые технологии"},

            {"Информационные системы и программирование",
            "💻 Fullstack-разработчик | Создание цифровых решений\n\n" +
            "• Разработка web/mobile приложений\n" +
            "• Работа с базами данных и API\n" +
            "• Языки: C#, Java, Python, JavaScript\n\n" +
            "🚀 Перспективы: Team Lead, DevOps, Data Scientist\n" +
            "💵 Доход: 80-180 тыс. руб.\n" +
            "🏆 Востребовано в: IT-компаниях, банках, стартапах"},

            {"Экономика и бухгалтерский учёт (по отраслям)",
            "📊 Финансовый специалист | Управление денежными потоками\n\n" +
            "• Ведение налогового и управленческого учета\n" +
            "• Анализ финансовой отчетности\n" +
            "• Программы: 1С, SAP, Excel\n\n" +
            "📈 Карьерный рост: главный бухгалтер → финансовый директор\n" +
            "💶 Зарплата: 50-120 тыс. руб.\n" +
            "🏛 Трудоустройство: любые коммерческие предприятия"},

            {"Дизайн (по отраслям)",
            "🎨 Креативный специалист | Визуальные коммуникации\n\n" +
            "• Создание логотипов и фирменного стиля\n" +
            "• Разработка UI/UX интерфейсов\n" +
            "• Инструменты: Figma, Adobe Creative Cloud\n\n" +
            "✨ Направления: графический, веб-, промышленный дизайн\n" +
            "💎 Доход: 60-130 тыс. руб.\n" +
            "🖌 Проектная работа возможна на фрилансе"},

            {"Землеустройство",
            "🌍 Кадастровый инженер | Работа с земельными ресурсами\n\n" +
            "• Межевание земельных участков\n" +
            "• Кадастровая оценка недвижимости\n" +
            "• Подготовка технических планов\n\n" +
            "🏡 Работодатели: Росреестр, строительные компании\n" +
            "💳 Зарплата: 50-90 тыс. руб.\n" +
            "📐 Оборудование: геодезические приборы, ГИС-системы"},

            {"Юриспруденция",
            "⚖ Корпоративный юрист | Правовая защита бизнеса\n\n" +
            "• Составление договоров и претензий\n" +
            "• Судебное представительство\n" +
                "• Правовой аудит компаний\n\n" +
            "👨‍⚖️ Специализации: налоговое, трудовое, уголовное право\n" +
            "💼 Доход: 70-200 тыс. руб.\n" +
            "🏢 Места работы: юридические фирмы, госструктуры"},

            {"Торговое дело",
            "🛍 Менеджер по продажам | Коммерция и маркетинг\n\n" +
            "• Ведение переговоров с клиентами\n" +
            "• Анализ рынка и конкурентов\n" +
            "• Разработка стратегий продвижения\n\n" +
            "📈 Карьера: от менеджера до директора по продажам\n" +
            "💵 Зарплата: 60-150 тыс. руб. + бонусы\n" +
            "🏆 Лучшие в профессии получают % от сделок"},

            {"Продавец",
            "🛒 Консультант по продажам | Работа с покупателями\n\n" +
            "• Выкладка товаров и оформление витрин\n" +
            "• Консультирование клиентов\n" +
            "• Работа с кассовым оборудованием\n\n" +
            "🔄 Возможен гибкий график работы\n" +
            "💴 Доход: 30-80 тыс. руб. + премии\n" +
            "🛍 Перспективы: управляющий магазином"},

            {"Финансы",
            "💹 Финансовый аналитик | Инвестиции и бюджетирование\n\n" +
            "• Оценка инвестиционных проектов\n" +
            "• Управление портфелем активов\n" +
            "• Прогнозирование рыночных трендов\n\n" +
            "📊 Инструменты: Bloomberg Terminal, Excel\n" +
            "💎 Зарплата: 100-250 тыс. руб.\n" +
            "🏦 ТОП-работодатели: Сбербанк, ВТБ, Альфа-Банк"}
        };

        if (descriptions.TryGetValue(ProfessionName, out var description))
        {
            ProfessionDescriptionLabel.Text = description;
        }
        else
        {
            ProfessionDescriptionLabel.Text = "Описание для этой специальности пока недоступно";
        }
    }
}